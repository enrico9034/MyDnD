using System.ComponentModel;
using System.Dynamic;
using DnD.Core.ScriptSuppliers;

namespace DnD.Core;

/// <summary>
/// This is the translation of a player sheet from the DnD.Core 5e rules.
/// </summary>

public class Character : DynamicObject
{
    internal object _lock = new object();
    public dynamic Stats = new ExpandoObject();
    
    public Dictionary<string, Func<dynamic, dynamic>> Stash = new();
    private IScriptSupplier _scriptSupplier;
    
    public Character(IScriptSupplier scriptSupplier)
    {
        scriptSupplier.SetCharacterInstance(this);
        _scriptSupplier = scriptSupplier;
        _scriptSupplier.GetInitScript().DoScript();
    }
    
    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        lock (_lock)
        {
            result = default;
            var targetLogic = _scriptSupplier.GetScript(binder.Name);
                
            result = targetLogic.DoScript();
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
            Func<dynamic, dynamic> previousStashedFunc = (x) => x;
            if (Stash.ContainsKey(binder.Name))
                previousStashedFunc = Stash[binder.Name];
            Stash[binder.Name] = (x) => modificator(previousStashedFunc(x))[0];
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
                _scriptSupplier.GetScriptCollection(binder.Name + "/" + args[0]);
            if (!targetLogic.Scripts().Any()) return false;
            
            foreach (var logic in targetLogic.Scripts())
            {
                if (!logic.AreRequirementMet())
                    continue;
                Console.WriteLine(binder.Name + "/" + args[0]);
                result = logic.DoScript();
            }
            return true;
        }
    }

    ~Character()
    {
        _scriptSupplier.Dispose();
    }
}