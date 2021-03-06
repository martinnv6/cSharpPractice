﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NetCoreJwtAuth.Services;
using NetCoreJwtAuth.Entities;

namespace NetCoreJwtAuth.Controllers
{        
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Key);

            if (user == null)
                return BadRequest(new { message = "Key is incorrect" });

            return Ok(user);
        }

        [Authorize(Roles = Role.SystemA)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(string key)
        {
            var user = _userService.GetById(key);

            if (user == null)
            {
                return NotFound();
            }

            // only allow admins to access other user records
            var currentUserId = User.Identity.Name;
            if (key != currentUserId && !User.IsInRole(Role.SystemA))
            {
                return Forbid();
            }

            return Ok(user);
        }
    }
}