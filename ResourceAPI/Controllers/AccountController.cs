using Microsoft.AspNetCore.Mvc;
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
        private UserRepository _userRepository;
        public AccountController(PaymentsContext dbContext, UserRepository userRepo) 
        {
            _paymentsContext = dbContext;
            _userRepository = new UserRepository(_paymentsContext);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            return View();
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
}
