namespace DnD.MagicSystems.Ki;

public class KiPoint : ISystemConsumable<Ki>
{
    private bool _isConsumed = false;
    public bool IsConsumed()
    {
        return _isConsumed;
    }

    public void Consume()
    {
        _isConsumed = true;
    }
}