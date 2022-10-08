using DesignPatterns.Creationals.Singeltons;
using UnityEngine;

namespace DesignPatterns.Creationals.AbstractFactories
{
    public class AbstractFactorySettings : SingeltonMonoBehaviour<AbstractFactorySettings>
    {
        [SerializeField] private ProductEnum _productEnum;

        protected void Awake()
        {
            _instance = this;
        }

        public static ProductEnum ProductEnum => _instance._productEnum;
    }
}