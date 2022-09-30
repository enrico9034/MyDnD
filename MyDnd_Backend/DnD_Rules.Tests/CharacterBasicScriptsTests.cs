

using System.Dynamic;
using Microsoft.CSharp;
using Microsoft.CSharp.RuntimeBinder;

namespace DnD_Rules.Tests
{
    
    public class CharacterBasicScriptsTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void ArmorClassTest()
        {
            dynamic character =(IDynamicMetaObjectProvider)new Character();
            character.Stats.Dexterity = 15;

            //character.StatsChanged();
            double dex = character.Stats.Dexterity;
            dex.Should().Be(15);
            double ac = character.AC;
            ac.Should().Be(12, "15 => +2, 10 + 2 = 12");

        }
        
         [Test]
         public void HealthTest()
         {
             dynamic character = new Character();
             character.Stats.Constitution = 9;
             
             //character.StatsChanged();
        
             (character.HP as double?).Should().Be(9, "9 => -1, 10 - 1 = 9");
        
             character.Race("Dwarf");
             
             (character.HP as double?).Should().Be(10, "Dwarf => Const + 2 = 11, 11 => + 0, 10 + 0 = 10");
         }
        
         [Test]
         public void DwarfLevel2Test()
         {
             dynamic character = new Character();
             character.Stats.Constitution = 9;
             character.Stats.Dexterity = 9;
             //character.StatsChanged();

             var hp = character.HP as double?;
             hp.Should().Be(9, "9 => -1, 10 - 1 = 9");
        
             character.Race("Dwarf");
             
             (character.HP as double?).Should().Be(10, "Dwarf => Const + 2 = 11, 11 => + 0, 10 + 0 = 10");

             (character.AC as double?).Should().Be(9);
             
             character.Class("Paladin");

             (character.AC as double?).Should().Be(10);
        
         }
    }
}
