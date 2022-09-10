using DnD.MagicSystems;

namespace DnD.CustomExceptions;

public class PowerSystemTypeNotMatching<TDesideratedType, TGivedType> : PowerSystemTypeNotMatching
    where TDesideratedType : ISystemType 
    where TGivedType : ISystemType
{
    public override string ToString()
    {
        return $"Given Type ({typeof(TGivedType)}) is not matching the required ({typeof(TDesideratedType)}) type";
    }
}

public class PowerSystemTypeNotMatching : DnDExceptions
{
    
}