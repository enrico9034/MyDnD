namespace DnD.Skills;

public class Skills
{
    public readonly Acrobatics Acrobatics;

    public Skills(Character targetCharacter)
    {
        Acrobatics = new Acrobatics(targetCharacter);
    }
}