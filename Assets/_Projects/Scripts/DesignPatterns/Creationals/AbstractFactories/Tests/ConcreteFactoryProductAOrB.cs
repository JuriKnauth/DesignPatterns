namespace DesignPatterns.Creationals.AbstractFactories
{
    public class ConcreteFactoryProductAOrB
    {
        public AbstractFactory AbstractFactory { get; set; }

        public void Setup()
        {
            switch (AbstractFactorySettings.ProductEnum)
            {
                case ProductEnum._unassigned:
                    AbstractFactory = new FactoryA();
                    break;
                case ProductEnum.A:
                    AbstractFactory = new FactoryA();
                    break;
                case ProductEnum.B:
                    AbstractFactory = new FactoryB();
                    break;
                default:
                    AbstractFactory = new FactoryA();
                    break;
            }
        }
    }
}
