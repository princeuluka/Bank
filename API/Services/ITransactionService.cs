using API.Model;

namespace API.Services
{
    public interface ITransactionService
    {
        Task NewTransaction(TransactionsModel transaction);

        
    }
}
