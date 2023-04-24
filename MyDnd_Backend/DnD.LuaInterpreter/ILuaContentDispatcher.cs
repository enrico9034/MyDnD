using DnD.Core.ScriptSuppliers;

namespace DnD.LuaInterpreter;

public interface ILuaContentDispatcher
{
    public LuaContent[] GetLuaContent(ScriptRequestParam contentInput);

    public LuaContent GetLuaInitContent();

    public LuaContent GetLuaUtilContent();
}