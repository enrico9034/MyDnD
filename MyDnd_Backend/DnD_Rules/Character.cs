using System.ComponentModel;
using System.Dynamic;
using DnD.LuaObjects;

namespace DnD;

/// <summary>
/// This is the translation of a player sheet from the DnD 5e rules.
/// </summary>

public class Character : DynamicObject
{
    internal object _lock = new object();
    public dynamic Stats = new ExpandoObject();
    
    public Dictionary<string, Func<dynamic, dynamic>> Stash = new();

    public Character()
    {
        LuaScriptDispatcher.GetScripts("Stats", this);
    }
    
    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        lock (_lock)
        {
            result = default;
            var targetLogic = LuaScriptDispatcher.GetScripts(binder.Name, this);
            if (!targetLogic.Any())
                return false;
            
            result = targetLogic[0].DoLogic();
            if (Stash.TryGetValue(binder.Name, out var modificator))
                result = modificator(result);
            
            return true;
        }
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        lock (_lock)
        {
            if (value is null)
                throw new NullReferenceException();
            if (!(value is Func<dynamic, dynamic> modificator))
                return true;
            Stash[binder.Name] = (x) => modificator(x)[0];
            return true;
        }
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        lock (_lock)
        {
            args = args ?? Array.Empty<object>();
            result = default;
            var targetLogic =
                LuaScriptDispatcher.GetScripts(binder.Name + "/" + args[0].ToString(), this);
            
            if (!targetLogic.Any()) return false;
            
            foreach (var logic in targetLogic)
            {
                if (logic.CheckRequirements())
                    logic.DoLogic();
            }
            return true;
        }
    }
}