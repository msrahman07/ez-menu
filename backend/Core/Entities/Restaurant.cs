using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class Restaurant : IdentityUser
    {
        public string RestaurantName { get; set; } = null!;
        public string? Description { get; set; }   
    }
}