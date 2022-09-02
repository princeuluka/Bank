using API.Model;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;     
        }

        [Route("api/CustomerData/NewTransaction")]
        [HttpPost]
        public async Task<IActionResult> NewTransaction(TransactionsModel data)
        {
            var id = await transactionService.NewTransaction(data);
            return Ok(id);
        }

        [Route("api/CustomerData/AllTransaction")]
        [HttpGet]
        public async Task<IActionResult> AllTransactions()
        {
            var data = await transactionService.GetAllTransactions();
            return Ok(data);
        }
    }
}
