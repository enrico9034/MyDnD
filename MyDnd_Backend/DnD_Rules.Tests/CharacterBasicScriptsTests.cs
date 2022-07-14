using DnD;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var character = new Character();
            character.Stats.Dexterity.Value = 15;

            character.StatsChanged();

            character.AC.Value.Should().Be(12, "15 => +2, 10 + 2 = 12");

        }
        
        [Test]
        public void HealthTest()
        {
            var character = new Character();
            character.Stats.Constitution.Value = 9;

            character.StatsChanged();

            character.HP.Value.Should().Be(9, "9 => -1, 10 - 1 = 9");

        }
    }
}
