using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Menu : BaseEntity
    {
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}