using UnityEngine;

namespace DesignPatterns.Creationals.Prototypes
{
    public class PrototypeTest : MonoBehaviour
    {
        private void Start()
        {
            Prototype prototype = new(new string[] { "Red" });

            IPrototype iPrototypeCopy = prototype.Clone(prototype);

            if (iPrototypeCopy is Prototype prototypeCopy && prototypeCopy.Settings != null && prototypeCopy.Settings.Length > 0)
            {
                for (int i = 0; i < prototypeCopy.Settings.Length; i++)
                {
                    Debug.Log(prototypeCopy.Settings[i]);
                }
            }
        }
    }
}