using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Structurals.Facades
{
    public static class RestaurantFacade
    {
        public static bool Order(Meal meal)
        {
            return Restaurant.TakeOrder(meal);
        }
    }

    public static class Restaurant
    {
        public static bool TakeOrder(Meal meal)
        {
            return Kitchen.RequestMeal(meal);
        }
    }

    public static class Kitchen
    {
        public static List<Ingredient> Ingredients = new();

        public static bool RequestMeal(Meal meal)
        {
            return ChefExtensions.RequestMeal(meal);
        }
    }

    public static class ChefExtensions
    {
        public static Queue<Chef> AvailableChefs = new();

        public static bool RequestMeal(Meal meal)
        {
            if (AvailableChefs.Count == 0)
            {
                return false;
            }

            Chef chef = AvailableChefs.Dequeue();

            return chef != null && chef.RequestMeal(meal);
        }
    }

    public class Chef
    {
        public Chef()
        {
            ChefExtensions.AvailableChefs.Enqueue(this);
        }

        public bool RequestMeal(Meal meal)
        {
            foreach (Ingredient item in meal.Ingredients)
            {
                Ingredient ingredientInKitchen = Kitchen.Ingredients.FirstOrDefault(x => x.Name == item.Name);

                if (ingredientInKitchen == null)
                {
                    return false;
                }

                if (ingredientInKitchen.EnoughForMeals <= 0)
                {
                    return false;
                }
            }

            foreach (Ingredient item in meal.Ingredients)
            {
                Ingredient ingredientInKitchen = Kitchen.Ingredients.FirstOrDefault(x => x.Name == item.Name);

                ingredientInKitchen.EnoughForMeals--;
            }

            return true;
        }
    }

    public class Ingredient
    {
        public string Name;
        public int EnoughForMeals;
    }

    public class Meal
    {
        public List<Ingredient> Ingredients = new List<Ingredient>();
    }
}
