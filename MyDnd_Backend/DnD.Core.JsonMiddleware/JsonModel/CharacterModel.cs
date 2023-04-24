namespace DnD.Core.JsonMiddleware;

public class CharacterModel
{
    public TValue[] BaseValues { get; init; }
    public Modificator[] Modificators { get; init; }
    public TValue[] FixedValues { get; init; }
}

public class TValue
{
    public string Target { get; init; }
    public int Value { get; init; }
}

public class Modificator
{
    public string Mod { get; init; }
    public string Path { get; init; }

    public int? Value { get; set; } = null;
}