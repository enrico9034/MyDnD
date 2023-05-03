using FileSystemConfigurationSupplier;
using FluentAssertions;
using NUnit.Framework;

namespace DnD.Core.JsonMiddleware.Tests;

public class BasicPaladin
{
    [Test]
    public void Lv2()
    {
        var model = new CharacterModel()
        {
            BaseValues = new[]
            {
                new TValue()
                {
                    Target = "Stats.Dexterity",
                    Value = 16
                },
                new TValue()
                {
                    Target = "Stats.Level",
                    Value = 2
                }
            },
            FixedValues = Array.Empty<TValue>(),
            Modificators = new[]
            {
                new Modificator()
                {
                    Mod = "Paladin",
                    Path = "Classes"
                },
                new Modificator()
                {
                    Mod = "Paladin",
                    Path = "Classes"
                }
            }
        };


        dynamic character = ModelApplicator.ResolveFromModel(model, new LuaScriptSupplier(new LuaScriptDispatcherAdaptor()));
        
        (character.AC as double?).Should().Be(15, "16 => +3, 10 + 3 = 13 + Paladin + Paladin lv2");
    }
    
}