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

        [HttpPost]
        public async Task<IActionResult> NewTransaction(TransactionsModel data)
        {
            await transactionService.NewTransaction(data);
            return Ok();
        }
    }
}
