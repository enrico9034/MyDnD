using System.ComponentModel;
using System.Dynamic;
using DnD.LuaObjects;
using NLua;

namespace DnD;

/// <summary>
/// This is the translation of a player sheet from the DnD 5e rules.
/// </summary>
public class Character : DynamicObject
{
    public Dictionary<string, dynamic> Stats = new ();

    public Character()
    {
        LuaScriptDispatcher.GetScripts("Stats", this);
    }
    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        result = default;
        var targetLogic = LuaScriptDispatcher.GetScripts(binder.Name, this);
        if (!targetLogic.Any())
            return false;
        
        result = targetLogic[0].DoLogic();
        return true;
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        return base.TryInvokeMember(binder, args, out result);
    }

}