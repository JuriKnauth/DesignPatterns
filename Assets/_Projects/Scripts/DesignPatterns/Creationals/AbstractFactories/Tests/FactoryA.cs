namespace DesignPatterns.Creationals.AbstractFactories
{
    public class FactoryA : AbstractFactory
    {
        public override IProductOne InstantiateProductOne()
        {
            return new ProductOneA();
        }

        public override IProductTwo InstantiateProductTwo()
        {
            return new ProductTwoA();
        }
    }
}
