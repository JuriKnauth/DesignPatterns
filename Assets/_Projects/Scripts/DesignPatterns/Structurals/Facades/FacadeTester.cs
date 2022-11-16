using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Structurals.Facades
{
    public class FacadeTester : MonoBehaviour
    {
        private void Start()
        {
            Kitchen.Ingredients = new List<Ingredient>()
            {
                new Ingredient()
                {
                    Name = "Potatoes",
                    EnoughForMeals = 3,
                },
                new Ingredient()
                {
                    Name = "Bread",
                    EnoughForMeals = 2,
                },
            };

            new Chef();
            new Chef();
            new Chef();

            bool canOrder = RestaurantFacade.Order
                (
                    new Meal()
                    {
                        Ingredients = new List<Ingredient>()
                        {
                            new Ingredient()
                            {
                                Name = "Potatoes"
                            }
                        }
                    }
                );
            Debug.Log(canOrder);

            canOrder = RestaurantFacade.Order
            (
                new Meal()
                {
                    Ingredients = new List<Ingredient>()
                    {
                                    new Ingredient()
                                    {
                                        Name = "Apple"
                                    }
                    }
                }
            );
            Debug.Log(canOrder);

            canOrder = RestaurantFacade.Order
            (
                new Meal()
                {
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "Potatoes"
                        },
                        new Ingredient()
                        {
                            Name = "Bread"
                        }
                    }
                }
            );
            Debug.Log(canOrder);
            canOrder = RestaurantFacade.Order
(
            new Meal()
            {
                Ingredients = new List<Ingredient>()
                {
                                new Ingredient()
                                {
                                    Name = "Potatoes"
                                },
                                new Ingredient()
                                {
                                    Name = "Bread"
                                }
                }
            }
            );
            Debug.Log(canOrder);
        }
    }
}
