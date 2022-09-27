

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
            character.Stats["Dexterity"] = 15;

            //character.StatsChanged();
            long dex = character.Stats["Dexterity"];
            dex.Should().Be(15);
            long ac = character.AC;
            ac.Should().Be(12, "15 => +2, 10 + 2 = 12");

        }
        
         [Test]
         public void HealthTest()
         {
             dynamic character = new Character();
             character.Stats["Constitution"] = 9;
             
             //character.StatsChanged();
        
             (character.HP as long?).Should().Be(9, "9 => -1, 10 - 1 = 9");
        
             // character.Race = Races.Dwarf;
             //
             // character.HP.Value.Should().Be(10, "Dwarf => Const + 2 = 11, 11 => + 0, 10 + 0 = 10");
        
        
         }
        
        // [Test]
        // public void DwarfLevel2Test()
        // {
        //     var character = new Character();
        //     character.Stats.Constitution.Value = 9;
        //     character.Stats.Dexterity.Value = 9;
        //     //character.StatsChanged();
        //
        //     character.HP.Value.Should().Be(9, "9 => -1, 10 - 1 = 9");
        //
        //     character.Race = Races.Dwarf;
        //     
        //     character.HP.Value.Should().Be(10, "Dwarf => Const + 2 = 11, 11 => + 0, 10 + 0 = 10");
        //     
        //     character.Classes.Add<Paladin>();
        //     character.Classes[0].Level = 2;
        //
        //     character.Stats.Dexterity.Value.Should().Be(11);
        //
        // }
    }
}
