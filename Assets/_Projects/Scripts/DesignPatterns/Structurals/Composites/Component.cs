using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DesignPatterns.Structurals.Composites
{
    public abstract class Component : MonoBehaviour
    {
        private GUID _guid = new();

        public int Value { get; set; }

        public virtual void Add(Component component)
        {
        }

        public virtual void Remove(Component component)
        {
        }

        public virtual List<Component> GetChildren()
        {
            return new List<Component>() { this };
        }

        public virtual IEnumerator<Component> GetNext()
        {
            yield return this;
        }

        public virtual int Sum()
        {
            return Value;
        }
    }
}