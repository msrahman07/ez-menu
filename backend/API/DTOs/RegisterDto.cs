using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDto
    {
        public string RestaurantName { get; set; } = null!;
        public string? Description { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}