namespace DesignPatterns.Creationals.AbstractFactories
{
    public class ConcreteFactoryProductAOrB
    {
        public AbstractFactory AbstractFactory { get; set; }

        public void Setup()
        {
            AbstractFactory = AbstractFactorySettings.ProductEnum switch
            {
                ProductEnum._unassigned => new FactoryA(),
                ProductEnum.A => new FactoryA(),
                ProductEnum.B => new FactoryB(),
                _ => new FactoryA(),
            };
        }
    }
}