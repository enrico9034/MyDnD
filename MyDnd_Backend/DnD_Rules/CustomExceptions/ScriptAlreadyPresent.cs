using DnD.Core.ScriptSuppliers;

namespace DnD.Core.CustomExceptions;

public class ScriptAlreadyPresentException : DnDExceptions
{
    public IScript ScriptDuplicated;
    
    public ScriptAlreadyPresentException(IScript scriptDuplicate) : base()
    {
        ScriptDuplicated = scriptDuplicate;
    }
    
}