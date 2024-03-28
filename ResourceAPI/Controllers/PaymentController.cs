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
    public class PaymentController : Controller
    {
        private readonly PaymentRepository _paymentRepository;
        public PaymentController(PaymentsContext dbContext) 
        {
            _paymentRepository = new PaymentRepository(dbContext);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]Payment payment)
        {
           var pay =  await _paymentRepository.Create(payment);

            if (ModelState.IsValid && pay != null) 
            {
                return Ok(pay);
            }

            return BadRequest($"State Invalid: {ModelState}");
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]Payment payment) 
        {
            var updatePay = await _paymentRepository.Update(payment);

            if (ModelState.IsValid && updatePay != null) 
            {
                return Ok(updatePay);
            }

            return BadRequest($"Update Invalid: {ModelState}");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int payId) 
        {
            if (await _paymentRepository.Delete(payId))
                return Ok("Deleted User Successfully");
            else
                return BadRequest($"PayId Invalid: {payId}");
        }
        [HttpGet]
        public async Task<List<Payment>> GetAll()
        {
            List<Payment> results = await _paymentRepository.GetAllPayments();

            return results;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int payId) 
        {
            var user = await _paymentRepository.GetPaymentById(payId);

            if (user != null) 
            {
                return Ok(user);
            }

            return BadRequest($"PayId Invalid: {payId}");
        }
        [HttpGet("getall/{id:int}")]
        public async Task<List<Payment>> GetAllFromUser(int userId) 
        {
            List<Payment> resultsForUser = await _paymentRepository.GetAllFromId(userId);

            return resultsForUser;
        }
    }
}
