using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Luigi's", Cuisine=CuisineType.Pizza, Location="Nashville"},
                new Restaurant { Id=2, Name= "Mom's Thai", Cuisine=CuisineType.Thai, Location="Watertown"},
                new Restaurant { Id=3, Name= "Don Pedro's", Cuisine=CuisineType.Mexican, Location="Nashville"},
            };

        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
