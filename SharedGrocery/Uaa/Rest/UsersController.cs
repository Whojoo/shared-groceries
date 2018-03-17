﻿using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
 using SharedGrocery.Uaa.Service;

namespace SharedGrocery.Uaa.Rest
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_userService.GetUser(id));
        }
    }
}