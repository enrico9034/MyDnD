namespace DnD.MagicSystems;

public interface ISystemConsumable<TSystemType>  where TSystemType : SystemDescriptor
{
    bool IsConsumed();

    void Consume();
}
