namespace DesignPatterns.Creationals.Prototypes
{
    public interface IPrototype
    {
        public IPrototype Clone(IPrototype prototype);
    }
}