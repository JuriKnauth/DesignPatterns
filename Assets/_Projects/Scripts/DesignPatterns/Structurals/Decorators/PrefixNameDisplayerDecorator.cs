namespace DesignPatterns.Structurals.Decorators
{
    public class PrefixNameDisplayerDecorator : NameDisplayerDecorator
    {
        public override string GetName()
        {
            return $"Name: {NameDisplayer.GetName()}";
        }
    }
}