namespace DesignPatterns.Structurals.Decorators
{
    public class PrefixNameDisplayerDecorator : NameDisplayerDecorator
    {
        public PrefixNameDisplayerDecorator(INameDisplayer nameDisplayer) : base()
        {
            NameDisplayer = nameDisplayer;
        }

        public override string GetName()
        {
            return $"Name: {NameDisplayer.GetName()}";
        }
    }
}