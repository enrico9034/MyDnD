namespace DnD.MagicSystems;

public interface ISystemConsumable<TSystemType>  where TSystemType : ISystemType
{
    bool IsConsumed();

    void Consume();
}
