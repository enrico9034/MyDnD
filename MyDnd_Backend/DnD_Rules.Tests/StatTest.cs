

using Neo.IronLua;

namespace DnD_Rules.Tests
{
    public class StatTest
    {
        [Test]
        public void ModifierTest()
        {
            
             int expectedModifier = -5;
             var lua = new Lua();
             var env = lua.CreateEnvironment();
             env.DoChunk("Lua/Util.lua", Array.Empty<KeyValuePair<string, object>>());
             for (long i = 1; i <= 20; i++)
             {
                 if (i % 2 == 0)
                     expectedModifier++;
                 
                 
                 (((dynamic)env).GetModificator(i)[0] as double?).Should().Be(expectedModifier);
             }
        }

        [Test]
        public void ProficiencyModificator()
        {
            dynamic character = new Character(UtilBuilder.GetLuaSupplier());

            (character.ProficiencyModificator as double?).Should().Be(2);

            character.Stats.Level = 10;
            
            (character.ProficiencyModificator as double?).Should().Be(4);

        }
    }
}
