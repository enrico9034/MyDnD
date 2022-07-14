namespace DnD.Stats;

public class Stat
{
    protected int _value = 1;

    public delegate void StatsChangedEventHandler();
    public event StatsChangedEventHandler StatChangedEvent;

    public int Value
    {
        get => _value;
        set
        {
            if (value < 1)
                value = 1;
            if (value > 20)
                value = 20;
            _value = value;

            if (StatChangedEvent != null) StatChangedEvent();
        }
    }

    public int Modifier
    {
        get
        {
            var partial = (double)(Value - 10) / 2;
            if(partial > 0)
                return (int)Math.Floor(Math.Abs(partial));
            return -1 * (int)Math.Ceiling(Math.Abs(partial));
        }
    }
}
