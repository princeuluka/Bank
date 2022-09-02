using API.Model;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICustomerDataService customerDataService;
        public TransactionService(ApplicationDbContext dbContext, ICustomerDataService customerDataService)
        {
            this.dbContext = dbContext;
            this.customerDataService = customerDataService;
        }
        public async Task<Guid> NewTransaction(TransactionsModel transaction)
        {
            var tran = new Transactions()
            {
                Amount = transaction.Amount,
                BeneficiaryAccountNumber = transaction.BeneficiaryAccountNumber,
                BeneficiaryAccountName = GetCustomerNameAsync(transaction.BeneficiaryAccountNumber).ToString(),
                Narration = transaction.Narration,
                TransactionDate = transaction.TransactionDate,
                SenderAccountNumber = transaction.SenderAccountNumber,
                SenderAccountName = GetCustomerNameAsync(transaction.SenderAccountNumber).ToString(),
                TransactionType = (DataAccess.Entities.Enums.TransactionType)transaction.TransactionType
            };
            await dbContext.Transactions.AddAsync(tran);
            await dbContext.SaveChangesAsync();

            return tran.TransactionID;
        }

        public async Task<string> GetCustomerNameAsync(long actNo)
        {
            var data = await dbContext.Accounts
                .Include(c => c.Customer)
               .FirstOrDefaultAsync(n => n.AccountNumber == actNo);

            string cusName = data.Customer.FirstName + " " + data.Customer.MiddleName + " " + data.Customer.LastName;

            return cusName;
        }

        public async Task<List<TransactionsModel>> GetAllTransactions()
        {
           var data = await(from Trans in dbContext.Transactions
                            select new TransactionsModel()
                            {
                                Amount = Trans.Amount,
                                BeneficiaryAccountNumber = Trans.BeneficiaryAccountNumber,
                                Narration = Trans.Narration,
                                SenderAccountNumber = Trans.SenderAccountNumber,
                                TransactionDate = Trans.TransactionDate,
                                TransactionID =Trans.TransactionID,
                                TransactionType = (Model.Enums.TransactionType)Trans.TransactionType
                            }).ToListAsync();
            return data;
        }
    }
}
