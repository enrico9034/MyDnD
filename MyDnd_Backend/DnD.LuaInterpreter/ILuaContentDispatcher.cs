namespace DnD.LuaInterpreter;

public interface ILuaContentDispatcher
{
    public LuaContent[] GetLuaContent(string contentName); // TODO(DG) : Add a cusom input class

    public LuaContent GetLuaInitContent();

    public LuaContent GetLuaUtilContent();
}