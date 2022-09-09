namespace DnD.MagicSystems.Ki;

public class KiPointsStash : ISystemConsumableStash<Ki>
{
    private readonly IEnumerable<KiPoint> _availableKiPoints;

    public KiPointsStash()
    {
        _availableKiPoints = new KiPoint[] { };
    }
    public ISystemConsumable<Ki>[] GetStash(Func<ISystemConsumable<Ki>, bool> filter)
    {
        return _availableKiPoints.Where(filter).ToArray();
    }
}