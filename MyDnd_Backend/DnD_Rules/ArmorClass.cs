using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{

    public class ArmorClass : ScriptableValue<Int64>
    {
        public ArmorClass(Character targetCharacter) : base(targetCharacter)
        {
        }

        public override string luaScript => "AC.lua";
    }
}
