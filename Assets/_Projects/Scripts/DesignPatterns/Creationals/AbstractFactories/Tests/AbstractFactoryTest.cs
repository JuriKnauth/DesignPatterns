﻿using System.Collections;
using UnityEngine;

namespace DesignPatterns.Creationals.AbstractFactories
{
    public class AbstractFactoryTest : MonoBehaviour
    {
        private ConcreteFactoryProductAOrB _concreteFactoryProductAOrB;

        private void Start()
        {
            SetConcreteFactory();
            CreateProducts(_concreteFactoryProductAOrB);
        }

        private void SetConcreteFactory()
        {
            _concreteFactoryProductAOrB = new();
            _concreteFactoryProductAOrB.Setup();
        }

        private static void CreateProducts(ConcreteFactoryProductAOrB concreteFactoryProductAOrB)
        {
            var productOne = concreteFactoryProductAOrB.AbstractFactory.InstantiateProductOne();
            var productTwo = concreteFactoryProductAOrB.AbstractFactory.InstantiateProductTwo();

            Debug.Log($"{productOne} {productOne.GetType()})");
            Debug.Log($"{productTwo} {productTwo.GetType()})");
        }

        [ContextMenu(nameof(CreateProductsInEditor))]
        private void CreateProductsInEditor()
        {
            SetConcreteFactory();
            CreateProducts(_concreteFactoryProductAOrB);
        }
    }
}