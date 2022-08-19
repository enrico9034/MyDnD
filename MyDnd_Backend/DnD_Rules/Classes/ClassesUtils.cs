namespace DnD.Classes;

public static class ClassesUtils
{
    public static void ApplyClasses(ICollection<Class> classesToApply)
    {
        foreach (var _class in classesToApply)
        {
            _class.Apply();
        }
    }
}