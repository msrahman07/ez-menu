using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMenuService
    {
        Task<Menu> AddMenuAsync();
        Task<Menu> GetMenuById();
    }
}