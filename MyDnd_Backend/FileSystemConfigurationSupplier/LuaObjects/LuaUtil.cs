
namespace DnD.Core.Lua;

public class LuaUtil
{
    private readonly Character _targetCharacter;

    public LuaUtil(Character targetCharacter)
    {
        _targetCharacter = targetCharacter;
    }
    /*
    #region Stat Functions
    private void ModifyStat<TTargetStat>(int amout) where TTargetStat : Stat
    {
        if(_targetCharacter.IsRecalculatingStats())
            return;
        _targetCharacter.Stats.GetStat<TTargetStat>().Value += amout;
    }
    
    public void ModifyDex(int amount)
    {
        ModifyStat<Dexterity>(amount);
    }
    
    public void ModifyStr(int amount)
    {
        ModifyStat<Strength>(amount);
    }
    
    public void ModifyCon(int amount)
    {
        ModifyStat<Constitution>(amount);
    }
    
    public void ModifyInt(int amount)
    {
        ModifyStat<Intelligence>(amount);
    }
    
    public void ModifyWis(int amount)
    {
        ModifyStat<Wisdom>(amount);
    }
    
    public void ModifyCha(int amount)
    {
        ModifyStat<Charisma>(amount);
    }
    #endregion
    
    public int GetPlayerLevel()
    { 
        return _targetCharacter.Level;
    }

    public void EnablePowerSystem(ISystemType systemType)
    {
        _targetCharacter.PowerSystem.ApplySystem(systemType);
    }
    */
}