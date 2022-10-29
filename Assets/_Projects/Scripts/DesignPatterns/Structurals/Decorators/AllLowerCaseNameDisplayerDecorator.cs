namespace DesignPatterns.Structurals.Decorators
{
    public class AllLowerCaseNameDisplayerDecorator : NameDisplayerDecorator
    {
        public AllLowerCaseNameDisplayerDecorator(INameDisplayer nameDisplayer) : base()
        {
            NameDisplayer = nameDisplayer;
        }

        public override string GetName()
        {
            return NameDisplayer.GetName().ToLower();
        }
    }
}