using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMenuItemService
    {
        Task<List<MenuItem>> GetAllMenuItemsAsync(Guid menuId);
        Task<MenuItem> AddMenuItemAsync(Guid menuId, MenuItem item);
    }
}