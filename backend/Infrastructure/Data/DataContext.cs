using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;
        public DbSet<MenuItemSize> MenuItemSizes { get; set; } = null!;

    }
}