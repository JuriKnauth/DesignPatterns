using UnityEngine;

namespace DesignPatterns.Structurals.Decorators
{
    public class NameDisplayer : INameDisplayer
    {
        protected string Name = "Bob";

        public virtual string GetName()
        {
            return Name;
        }

        public virtual void Display()
        {
            Debug.Log(GetName());
        }
    }
}