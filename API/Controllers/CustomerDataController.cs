using API.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDataController : ControllerBase
    {
        private readonly ICustomerDataService customerDataService;
        public CustomerDataController(ICustomerDataService customerDataService)
        {
            this.customerDataService = customerDataService;
        }

        [HttpGet]
        public async Task<IActionResult> AllCustomers()
        {
            var data = await customerDataService.GetAllCustomers();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(CustomerDataModel data)
        {
            await customerDataService.AddNewAccountAsync(data);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(CustomerDataModel data)
        {
            await customerDataService.UpdateAccountAsync(data);
            return Ok();
        }
    }
}
