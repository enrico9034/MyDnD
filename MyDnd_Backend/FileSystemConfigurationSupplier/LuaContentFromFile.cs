using DnD.LuaInterpreter;

namespace FileSystemConfigurationSupplier;

public class LuaContentFromFile : LuaContent
{
    public string _content;
    public override string Content => _content;

    public LuaContentFromFile(string fileName)
    {
        _content = File.ReadAllText(fileName);
    }
}