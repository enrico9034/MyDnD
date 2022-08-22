namespace DnD.Classes;

public class Classes : List<Class>
{
    private Character _targetCharacter;
    public Classes(Character targetCharacter)
    {
        _targetCharacter = targetCharacter;
    }
    public void Add<TClassType>() where TClassType : Class
    {
        var other = Activator.CreateInstance(typeof(TClassType), new []{_targetCharacter}) as Class;
        if (other == null)
          throw new InvalidOperationException("Class not found");
        base.Add(other);
        other.Level = 1;
    }
}