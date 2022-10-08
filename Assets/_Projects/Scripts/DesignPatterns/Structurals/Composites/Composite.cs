using System.Collections.Generic;

namespace DesignPatterns.Structurals.Composites
{
    public class Composite : Component
    {
        public List<Component> Children { get; set; }

        public override void Add(Component component)
        {
            Children.Add(component);
        }

        public override void Remove(Component component)
        {
            Children.Remove(component);
        }

        public virtual List<Component> GetChildren()
        {
            List<Component> children = new List<Component>(Children.Count + 1) { this };
            children.AddRange(Children);
            return children;
        }

        public override IEnumerator<Component> GetNext()
        {
            foreach (Component child in Children)
            {
                yield return child;
            }
        }

        public override int Sum()
        {
            int value = Value;

            foreach (Component child in Children)
            {
                value += child.Sum();
            }

            return value;
        }
    }
}
