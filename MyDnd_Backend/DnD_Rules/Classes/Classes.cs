namespace DnD.Classes;

public class Classes : List<Class>
{
    public new void Add(Class other)
    {
        base.Add(other);
        ClassesUtils.ApplyClasses(this);
    }
}