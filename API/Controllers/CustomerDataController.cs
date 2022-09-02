using API.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    [ApiController]
    public class CustomerDataController : ControllerBase
    {
        private readonly ICustomerDataService customerDataService;
        public CustomerDataController(ICustomerDataService customerDataService)
        {
            this.customerDataService = customerDataService;
        }
        [Route("api/CustomerData/AllCustomers")]
        [HttpGet]
        public async Task<IActionResult> AllCustomers()
        {
            var data = await customerDataService.GetAllAsync(n => n.State, p => p.Lga);
            return Ok(data);
        }

        [Route("api/CustomerData/AddNewCustomer")]
        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(CustomerDataModel data)
        {
            await customerDataService.AddNewAccountAsync(data);
            return Ok();
        }

        [Route("api/CustomerData/UpdateCustomer")]
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerDataModel data)
        {
            await customerDataService.UpdateAccountAsync(data);
            return Ok();
        }
    }
}
