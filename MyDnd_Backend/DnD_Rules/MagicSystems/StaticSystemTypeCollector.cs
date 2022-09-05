using System.Reflection;

namespace DnD.MagicSystems;

public static class StaticSystemTypeCollector
{
    public static Dictionary<string, ISystemType> SystemTypes;

    static StaticSystemTypeCollector()
    {
        SystemTypes = new Dictionary<string, ISystemType>();

        var targets = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(ISystemType))).ToList();;
        
        foreach (var target in targets)
        {
            var instance = Activator.CreateInstance(target) as ISystemType;
            SystemTypes.Add(instance.SystemName, instance);
        }

    }
}