using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Rules.LuaObjects
{
    public class LuaScriptDispatcher
    {

        private static Dictionary<string, LuaScript> _scripts = new ();

        public LuaScriptDispatcher()
        {
            var scripts = ScanForScripts();
            FillScriptCache(scripts);
        }

        private void FillScriptCache(IEnumerable<string> scripts)
        {
            foreach(var script in scripts)
            {
                _scripts[script] = new LuaScript(script); //TODO (DG): Check if the string contains also the folder
            }
        }

        private IEnumerable<string> ScanForScripts()
        {
            return Directory.GetFiles(LuaMagicWords.LuaFolder)
                .Where(file => file.EndsWith(".lua"));
        }

        public LuaScript GetScript(string script)
        {
            _scripts[script].Init();
            return _scripts[script];
        }
    }
}
