using UnityEngine;

namespace DesignPatterns.Structurals.Decorators
{
    public class AllLowerCaseNameDisplayerDecorator : NameDisplayerDecorator
    {
        public override string GetName()
        {
            return NameDisplayer.GetName().ToLower();
        }
    }
}
