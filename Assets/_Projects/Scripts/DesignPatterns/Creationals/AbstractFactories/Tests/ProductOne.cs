namespace DesignPatterns.Creationals.AbstractFactories
{
    public abstract class ProductOne : IProductOne
    {
        public virtual ProductEnum ProductEnum => ProductEnum._unassigned;
    }
}
