using System.Drawing;
using System.Dynamic;
using System.Reflection;
using DnD.Core.ScriptSuppliers;
using FastMember;
using Microsoft.CSharp.RuntimeBinder;

namespace DnD.Core.JsonMiddleware;

public static class ModelApplicator
{
    public static Character ResolveFromModel(CharacterModel characterModel, IScriptSupplier scriptSupplier)
    {
        Character character = new Character(scriptSupplier);
        var accessor = ObjectAccessor.Create(character);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            
        foreach (var tValue in characterModel.BaseValues)
        {
            var target = tValue.Target.Replace("Stats.", "");
            var isSkill = tValue.Target.Contains("Stats");
            
            if(isSkill)
                accessor = ObjectAccessor.Create(character.Stats);

            accessor[target] = tValue.Value;
        }
          
        foreach (var mod in characterModel.Modificators)
        {
            if (mod.Value.HasValue)
            {
                accessor[mod.Mod] = mod.Value;
                continue;
            }

            var binder = Microsoft.CSharp.RuntimeBinder.Binder
                .InvokeMember(
                    CSharpBinderFlags.None,
                    mod.Path,
                    new[] { typeof(string) },
                    typeof(DnD.Core.JsonMiddleware.ModelApplicator),
                    new[]
                    {
                        Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                    }
                );
            (character as DynamicObject).TryInvokeMember((System.Dynamic.InvokeMemberBinder)binder, new[] { mod.Mod }, out var result);
        }
        
        foreach (var tValue in characterModel.BaseValues)
        {
            var target = tValue.Target.Replace("Stats.", "");
            var isSkill = tValue.Target.Contains("Stats");
            
            if(isSkill)
                accessor = ObjectAccessor.Create(character.Stats);

            accessor[target] = tValue.Value;
        }
        
        return character;
    }
}