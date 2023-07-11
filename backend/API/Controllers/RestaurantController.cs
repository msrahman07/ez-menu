using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RestaurantController : ControllerBase
    {
        private readonly UserManager<Restaurant> userManager;
        private readonly SignInManager<Restaurant> signInManager;

        public RestaurantController(UserManager<Restaurant> userManager, SignInManager<Restaurant> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<RestaurantDto>> RestaurantLogin(LoginDto loginDto)
        {
            var restaurant = await userManager.FindByEmailAsync(loginDto.Email);

            if(restaurant == null) return Unauthorized();

            var result = await signInManager.CheckPasswordSignInAsync(restaurant, loginDto.Password, false);

            if(result.Succeeded) 
            {
                return new RestaurantDto
                {
                    RestaurantName = restaurant.RestaurantName,
                    Email = restaurant.Email!,
                    Token = "This will be a token"
                };
            }

            return Unauthorized();
        }
    }
}