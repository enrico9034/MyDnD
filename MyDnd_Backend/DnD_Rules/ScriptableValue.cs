﻿using DnD.LuaObjects;

namespace DnD
{
    public abstract class ScriptableValue<TType>
    {
        public TType Value { get; internal set; }
        
        public abstract string luaScript { get; }

        public void Calculate()
        {
            var script = LuaScriptDispatcher.GetScript(luaScript);
            Value = script.DoLogic<TType>();
        }
        
        public ScriptableValue(Character targetCharacter) //TODO (DG): Refactor Name
        {
            targetCharacter.ReCalculateStatsEvent += (_, _) => Calculate();
        }
    }
}
