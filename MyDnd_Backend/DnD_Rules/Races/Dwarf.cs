namespace DnD.Races;

public class Dwarf : Race
{
    public override Races RaceType => Races.Dwarf;

    public Dwarf(Character character) : base(character)
    {
    }
}