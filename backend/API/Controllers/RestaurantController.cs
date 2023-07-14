using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RestaurantController : ControllerBase
    {
        private readonly UserManager<Restaurant> userManager;
        private readonly SignInManager<Restaurant> signInManager;
        private readonly TokenService tokenService;

        public RestaurantController(UserManager<Restaurant> userManager,
            SignInManager<Restaurant> signInManager,
            TokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<RestaurantDto>> RestaurantLogin(LoginDto loginDto)
        {
            var restaurant = await userManager.FindByEmailAsync(loginDto.Email);

            if (restaurant == null) return Unauthorized();

            var result = await signInManager.CheckPasswordSignInAsync(restaurant, loginDto.Password, false);

            if (result.Succeeded)
            {
                return CreateRestaurantObject(restaurant);
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<RestaurantDto>> RestaurantRegister(RegisterDto registerDto)
        {
            if (await userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email taken");
            }

            var restaurant = new Restaurant
            {
                RestaurantName = registerDto.RestaurantName,
                Email = registerDto.Email,
                Description = registerDto.Description
            };

            var result = await userManager.CreateAsync(restaurant, registerDto.Password);

            if (result.Succeeded)
            {
                return CreateRestaurantObject(restaurant);
            }

            return BadRequest("Problem registering user");
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<RestaurantDto>> GetCurrentRestaurant()
        {
            var restaurant = await userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email)!);

            return CreateRestaurantObject(restaurant!);
        }

        private RestaurantDto CreateRestaurantObject(Restaurant restaurant)
        {
            return new RestaurantDto
            {
                RestaurantName = restaurant.RestaurantName,
                Email = restaurant.Email!,
                Token = tokenService.CreateToken(restaurant)
            };
        }
    }
}