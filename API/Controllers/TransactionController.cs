using API.Model;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;     
        }

        [Route("api/Transactions/NewTransaction")]
        [HttpPost]
        public async Task<IActionResult> NewTransaction(TransactionsModel data)
        {
            var id = await transactionService.NewTransaction(data);
            return Ok(id);
        }

        [Route("api/Transactions/AllTransaction")]
        [HttpGet]
        public async Task<IActionResult> AllTransactions()
        {
            var data = await transactionService.GetAllTransactions();
            return Ok(data);
        }

        [Route("api/Transactions/GetTransactionByID")]
        [HttpGet]
        public async Task<IActionResult> GetTransactionById(Guid Id)
        {
            var data = await transactionService.GetTransactionDataByID(Id);
            return Ok(data);

        }
    }
}
