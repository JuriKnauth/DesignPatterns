namespace DesignPatterns.Structurals.Decorators
{
    public class AllUpperCaseNameDisplayerDecorator : NameDisplayerDecorator
    {
        public AllUpperCaseNameDisplayerDecorator(INameDisplayer nameDisplayer) : base()
        {
            NameDisplayer = nameDisplayer;
        }

        public override string GetName()
        {
            return NameDisplayer.GetName().ToUpper();
        }
    }
}