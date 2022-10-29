using UnityEngine;

namespace DesignPatterns.Structurals.Decorators
{
    public class TestDecorators : MonoBehaviour
    {
        public void Start()
        {
            INameDisplayer[] nameDisplayers = new INameDisplayer[]
            {
                new PrefixNameDisplayerDecorator
                (
                    new AllUpperCaseNameDisplayerDecorator
                    (
                        new NameDisplayer()
                    )
                ),
                new PrefixNameDisplayerDecorator
                (
                    new AllLowerCaseNameDisplayerDecorator
                    (
                        new NameDisplayer()
                    )
                ),
                new NameDisplayer()
            };

            foreach (INameDisplayer nameDisplayer in nameDisplayers)
            {
                nameDisplayer.Display();
            }
        }
    }
}