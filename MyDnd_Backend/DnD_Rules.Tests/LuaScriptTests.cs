using DnD;

namespace DnD_Rules.Tests
{
    public class LuaScriptTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckTrue()
        {
            var lua = new LuaScript("lua/Check_true.lua");
            Assert.IsTrue(lua.CheckRequirements());
            lua.Dispose();
        }

        [Test]
        public void CheckFalse()
        {
            var lua = new LuaScript("lua/Check_false.lua");
            Assert.IsFalse(lua.CheckRequirements());
            lua.Dispose();
        }
    }
}