namespace DesignPatterns.Creationals.AbstractFactories
{
    public abstract class ProductTwo : IProductTwo
    {
        public virtual ProductEnum ProductEnum => ProductEnum._unassigned;
    }
}
