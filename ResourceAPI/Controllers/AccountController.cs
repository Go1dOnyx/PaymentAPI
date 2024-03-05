using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceAPI.EF.DbContexts;
using ResourceAPI.EF.Models;
using ResourceAPI.EF.Repositories;
using ResourceAPI.Models;
using System.Runtime.CompilerServices;

namespace ResourceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PaymentsContext _paymentsContext;
        public AccountController(PaymentsContext dbContext) 
        {
            _paymentsContext = dbContext;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _paymentsContext.Users.FirstOrDefaultAsync( u => u.Username == model.UserEmail || u.Email == model.UserEmail && u.Password == model.Password);
                if (user == null)
                {
                    return Ok("User is Aunthenticated");
                }
                else 
                {
                    return BadRequest("Invalid Username or Password");
                }
            }
            else 
            {
                return BadRequest("Invalid Username or Password");
            }
        }

        [HttpPost("register")]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPut("{id}")]
        public IActionResult Update() 
        {
            return View();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetUser() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            return View();
        }
    }

    public class async
    {
    }
}
