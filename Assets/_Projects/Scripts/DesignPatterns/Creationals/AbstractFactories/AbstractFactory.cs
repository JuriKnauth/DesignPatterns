namespace DesignPatterns.Creationals.AbstractFactories
{
    public abstract class AbstractFactory
    {
        public abstract IProductOne InstantiateProductOne();

        public abstract IProductTwo InstantiateProductTwo();
    }
}