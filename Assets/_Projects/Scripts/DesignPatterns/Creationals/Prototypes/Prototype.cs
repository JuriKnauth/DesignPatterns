using UnityEngine;

namespace DesignPatterns.Creationals.Prototypes
{
    public class Prototype : IPrototype
    {
        [SerializeField] private string[] _settings;

        public string[] Settings => _settings;

        public Prototype(string[] settings = null)
        {
            _settings = settings;
        }

        public IPrototype Clone(IPrototype prototype)
        {
            if (prototype is Prototype toCopyPrototype)
            {
                return new Prototype()
                {
                    _settings = toCopyPrototype._settings
                };
            }

            return new Prototype();
        }
    }
}
