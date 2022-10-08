using UnityEngine;

namespace DesignPatterns.Structurals.Decorators
{
    public class TestDecorators : MonoBehaviour
    {
        public void Start()
        {
            INameDisplayer[] nameDisplayers = new INameDisplayer[]
            {
                new PrefixNameDisplayerDecorator()
                {
                    NameDisplayer = new AllUpperCaseNameDisplayerDecorator()
                    {
                        NameDisplayer = new NameDisplayer()
                    }
                },
                new PrefixNameDisplayerDecorator()
                {
                    NameDisplayer = new AllLowerCaseNameDisplayerDecorator()
                    {
                        NameDisplayer = new NameDisplayer()
                    }
                },
                new NameDisplayer()
            };

            foreach (INameDisplayer nameDisplayer in nameDisplayers)
            {
                nameDisplayer.Display();
            }
        }
    }
}
