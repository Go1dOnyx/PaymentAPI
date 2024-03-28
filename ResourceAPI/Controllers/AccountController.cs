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
        public async Task<ActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState + " - Invalid");
            }

            var user = await _paymentsContext.Users.FirstOrDefaultAsync(u => (u.Username == model.UserEmail || u.Email == model.UserEmail) && u.Password == model.Password);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Unauthorized("Invalid Username or Password");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState + " - Invalid");
            }
            else
            {
                if (model != null)
                {
                    await _paymentsContext.AddAsync(model);
                    await _paymentsContext.SaveChangesAsync();

                    return Ok(model);
                }
                else
                {
                    return BadRequest("Could not successfully create new user");
                }
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState + "Invalid");
            }

            var getUser = await _paymentsContext.Users.FirstOrDefaultAsync(u => u.Username == model.Username || u.Email == model.Email);

            if (getUser == null)
            {
                return NotFound("User not found");
            }

            getUser.Username = model.Username!;
            getUser.Email = model.Email!;
            getUser.Password = getUser.Password;
            getUser.FirstName = getUser.FirstName;
            getUser.MiddleName = getUser.MiddleName;
            getUser.LastName = getUser.LastName;
            getUser.Status = getUser.Status;

            await _paymentsContext.SaveChangesAsync();

            return Ok("User was updated");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int id) 
        {
           var user = await _paymentsContext.Users.FindAsync(id);

           _paymentsContext.Remove(user);
           await  _paymentsContext.SaveChangesAsync();

           return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute]int id) 
        {
            try
            {
                var user = await _paymentsContext.Users.FindAsync(id);

                if (user == null) 
                {
                    return NotFound($"Could not find user: {user?.UserId}");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers() 
        {
            var results = await _paymentsContext.Users.ToListAsync();

            return results;
        }
    }
}