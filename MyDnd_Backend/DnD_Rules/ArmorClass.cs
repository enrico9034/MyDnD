﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{

    public class ArmorClass : ScriptableValue<int>
    {
        public override string luaScript => "AC.lua";
    }
}
