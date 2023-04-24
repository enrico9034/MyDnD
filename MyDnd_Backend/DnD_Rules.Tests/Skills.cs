
namespace DnD_Rules.Tests;
[NonParallelizable]
public class Skills
{
    [Test]
    public void AcrobaticsTest()
    {
        dynamic character = new Character(UtilBuilder.GetLuaSupplier());
        character.Stats.Dexterity = 15;
        character.Stats.Strength = 15;

        character.Classes("Paladin");
    
        (character.Skills.Acrobatics as double?).Should().Be(2, "15 => +2");
        (character.Skills.Athletics as double?).Should().Be(2, "15 => +2");

        character.Stats.Dexterity = 16;
            
        (character.Skills.Acrobatics as double?).Should().Be(3, "16 => +3");
    
        character.Skills.IsProficient("Acrobatics", true);
        var acr = character.Skills.Acrobatics;
        (acr as double?).Should().Be(5, "16 => +3 + proficiency");
        
        character.Skills.IsProficient("Athletics", true);
        (character.Skills.Athletics as double?).Should().Be(4, "16 => +2 + proficiency");
        
        character.Stats.Level = 20;
        
        (character.Skills.Acrobatics as double?).Should().Be(9, "16 => +3 + proficiency");
        (character.Skills.Athletics as double?).Should().Be(8, "16 => +2 + proficiency");

    }
}