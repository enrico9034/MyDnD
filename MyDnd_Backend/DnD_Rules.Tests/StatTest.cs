

namespace DnD_Rules.Tests
{
    public class StatTest
    {
        [Test]
        public void ModifierTest()
        {
            
             int expectedModifier = -5;
             var lua = new NLua.Lua();
             lua.DoFile("Lua/Util.lua");
             var method = lua["GetModificator"] as NLua.LuaFunction;
             for (long i = 1; i <= 20; i++)
             {
                 if (i % 2 == 0)
                     expectedModifier++;
                 
                 
                 (method.Call(i)[0] as long?).Should().Be(expectedModifier);
             }
        }
    }
}
