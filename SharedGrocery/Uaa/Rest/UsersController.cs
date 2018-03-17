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

        /// <summary>
        /// Find a user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}