using UnityEngine;

namespace DesignPatterns.Structurals.Decorators
{
    public class AllUpperCaseNameDisplayerDecorator : NameDisplayerDecorator
    {
        public override string GetName()
        {
            return NameDisplayer.GetName().ToUpper();
        }
    }
}
