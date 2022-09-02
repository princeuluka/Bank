using API.Model;

namespace API.Services
{
    public interface ITransactionService
    {
        Task <Guid>NewTransaction(TransactionsModel transaction);

        Task<List<TransactionsModel>> GetAllTransactions();
    }
}
