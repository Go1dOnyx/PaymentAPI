using Microsoft.AspNetCore.Mvc;
using ResourceAPI.EF.DbContexts;
using ResourceAPI.EF.Models;
using ResourceAPI.EF.Repositories;
using System.Runtime.CompilerServices;

namespace ResourceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly PaymentsContext _paymentsContext;
        private UserRepository _userRepository;
        public AccountController(PaymentsContext dbContext, UserRepository userRepo) 
        {
            _paymentsContext = dbContext;
            _userRepository = userRepo;
        }

        [HttpPost(Name = "CreateAccount")]
        public IActionResult PostUser()
        {
            return View();
        }
        public IActionResult PutUser() 
        {
            return View();
        }
        public IActionResult DeleteUser() 
        {
            return View();
        }
        public IActionResult GetUser() 
        {
            return View();
        }
        public IActionResult GetAllUsers() 
        {
            return View();
        }
    }
}
