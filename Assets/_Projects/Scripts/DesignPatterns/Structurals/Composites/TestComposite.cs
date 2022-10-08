using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Structurals.Composites
{
    public class TestComposite : MonoBehaviour
    {
        private void Start()
        {
            Component[] composites = new Component[]
            {
                new LeafComponent() { Value = 1 },
                new LeafComponent() { Value = 1 },
                new Composite()
                {
                    Value = 1,
                    Children = new List<Component>()
                    {
                        new LeafComponent() { Value = 1 },
                        new LeafComponent() { Value = 1 }
                    }
                },
                new Composite()
                {
                    Value = 1,
                    Children = new List<Component>()
                    {
                        new LeafComponent() { Value = 1 },
                        new LeafComponent() { Value = 1 },
                        new Composite()
                        {
                            Value = 1,
                            Children = new List<Component>()
                            {
                                new LeafComponent() { Value = 1 },
                                new LeafComponent() { Value = 1 }
                            }
                        }
                    }
                }
            };

            int sum = 0;

            foreach (Component component in composites)
            {
                sum += component.Sum();
            }

            Debug.Log(sum);
        }
    }
}
