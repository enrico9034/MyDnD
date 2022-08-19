
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
            lua.CheckRequirements(null).Should().BeTrue();
            lua.Dispose();
        }

        [Test]
        public void CheckFalse()
        {
            var lua = new LuaScript("lua/Check_false.lua");
            lua.CheckRequirements(null).Should().BeFalse();
            lua.Dispose();
        }
    }
}