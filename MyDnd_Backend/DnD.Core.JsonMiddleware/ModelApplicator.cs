using System.Drawing;
using DnD.Core.ScriptSuppliers;

namespace DnD.Core.JsonMiddleware;

public static class ModelApplicator
{
    public static Character ResolveFromModel(CharacterModel characterModel, IScriptSupplier scriptSupplier)
    {
        var character = new Character(scriptSupplier);
        var characterType = typeof(Character);
            
        foreach (var tValue in characterModel.BaseValues)
        {
            var propertyInfo = characterType.GetProperty(tValue.Target);
            propertyInfo.SetValue(character, tValue.Value);
        }

        foreach (var mod in characterModel.Modificators)
        {
            if (mod.Value.HasValue)
            {
                var propertyInfo = characterType.GetProperty(mod.Mod);
                propertyInfo.SetValue(character, mod.Value);
                continue;
            }

            var methodInfo = characterType.GetMethod(mod.Path);
            methodInfo.Invoke(character, new [] { mod.Mod });
        }
        
        foreach (var tValue in characterModel.FixedValues)
        {
            var propertyInfo = characterType.GetProperty(tValue.Target);
            propertyInfo.SetValue(character, tValue.Value);
        }
        
        return character;
    }
}