using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.LuaObjects
{
    public static class LuaScriptDispatcher
    {

        private static Dictionary<string, LuaScript> _scripts = new ();

        static LuaScriptDispatcher()
        {
            var scripts = ScanForScripts();
            FillScriptCache(scripts);
        }

        private static void FillScriptCache(IEnumerable<string> scripts)
        {
            foreach(var script in scripts)
            {
                _scripts[script] = new LuaScript(script); //TODO (DG): Check if the string contains also the folder
            }
        }

        private static IEnumerable<string> ScanForScripts()
        {
            return Directory.GetFiles(LuaMagicWords.LuaFolder)
                .Where(file => file.EndsWith(".lua"));
        }

        public static LuaScript GetScript(string script)
        {
            _scripts[script].Init();
            return _scripts[script];
        }
    }
}
