using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public class ArmorClass
    {
        public int AC;

        public ArmorClass()
        {
            var logic = LuaObjects.LuaScriptDispatcher.GetScript("AC");
            if (logic.CheckRequirements())
                AC = logic.DoLogic<int>();
        }
        

    }
}
