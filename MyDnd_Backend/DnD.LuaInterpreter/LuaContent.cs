namespace DnD.LuaInterpreter;

public abstract class LuaContent : IEquatable<LuaContent>
{
    public abstract string Content { get; }

    public bool Equals(LuaContent? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Content == other.Content;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((LuaContent)obj);
    }

    public override int GetHashCode()
    {
        return Content.GetHashCode();
    }

    public static LuaContent Empty => EmptyLuaContent.instance;
}



public class EmptyLuaContent : LuaContent
{
    public static EmptyLuaContent instance
    {
        get
        {
            if (instance == default)
                instance = new EmptyLuaContent();
            return instance;
        }
        set => instance = value;
    }

    public override string Content => "";
}