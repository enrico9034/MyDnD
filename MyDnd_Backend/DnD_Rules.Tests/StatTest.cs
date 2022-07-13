using DnD.Stats;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Rules.Tests
{
    public class StatTest
    {
        [Test]
        public void ModifierTest()
        {
            var stat = new Stat();
            
            int expectedModifier = -5;
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 == 0)
                    expectedModifier++;
                
                stat.Value = i;
                stat.Modifier.Should().Be(expectedModifier);
            }
        }

        [Test]
        public void StatLimitsTest()
        {
            var stat = new Stat();
            stat.Value = 0;
            stat.Value.Should().Be(1);
            stat.Value = 21;
            stat.Value.Should().Be(20);
        }
    }
}
