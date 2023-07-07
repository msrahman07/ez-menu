using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRestaurantService
    {
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task<Restaurant> GetRestaurantByID(Restaurant restaurant);
    }
}