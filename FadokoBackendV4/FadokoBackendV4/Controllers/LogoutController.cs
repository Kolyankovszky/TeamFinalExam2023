﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FadokoBackendV4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        [HttpPost("{uId}")]

        public IActionResult Post(string uId)
        {
            if (Program.LoggedInUsers.ContainsKey(uId))
            {
                Program.LoggedInUsers.Remove(uId);
                return StatusCode(200, "Check out ok.");
            }
            else
            {
                return BadRequest("Logout error!");
            }
        }
    }
}
