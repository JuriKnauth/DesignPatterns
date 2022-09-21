using System.Runtime.InteropServices.WindowsRuntime;

namespace DesignPatterns.Creationals.Prototypes
{
    public interface IPrototype
    {
        public IPrototype Clone(IPrototype prototype);
    }
}
