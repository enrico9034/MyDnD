using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Stats
{
    public class Stats
    {
        public Intelligence Intelligence { get; } = new();

        public Strength Strength { get; } = new();

        public Dexterity Dexterity { get; } = new();

        public Constitution Constitution { get; } = new();

        public Wisdom Wisdom { get; } = new();

        public Charisma Charisma { get; } = new();


    }
}
