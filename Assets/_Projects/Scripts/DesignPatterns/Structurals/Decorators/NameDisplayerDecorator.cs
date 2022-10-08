using UnityEngine;

namespace DesignPatterns.Structurals.Decorators
{
    public class NameDisplayerDecorator : INameDisplayer
    {
        public INameDisplayer NameDisplayer { get; set; }

        public virtual string GetName()
        {
            return NameDisplayer.GetName();
        }

        public virtual void Display()
        {
            Debug.Log(GetName());
        }
    }
}