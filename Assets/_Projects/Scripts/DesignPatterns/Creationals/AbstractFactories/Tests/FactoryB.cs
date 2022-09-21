namespace DesignPatterns.Creationals.AbstractFactories
{
    public class FactoryB : AbstractFactory
    {
        public override IProductOne InstantiateProductOne()
        {
            return new ProductOneB();
        }

        public override IProductTwo InstantiateProductTwo()
        {
            return new ProductTwoB();
        }
    }
}
