using API.Data;
using API.Model;
using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

           
            var senderActName = GetCustomerNameAsync(transaction.SenderAccountNumber).ToString();

            var benefiActName = GetCustomerNameAsync(transaction.BeneficiaryAccountNumber).ToString();

            if (benefiActName == "System.Threading.Tasks.Task`1[System.String]")
            {
                return  Guid.Empty;
            }
            else if (senderActName == "System.Threading.Tasks.Task`1[System.String]")
            {
                return Guid.Empty;
                
            }
            else
            {
                var tran = new Transactions()
                {
                    Amount = transaction.Amount,
                    BeneficiaryAccountNumber = transaction.BeneficiaryAccountNumber,
                    BeneficiaryAccountName = senderActName,
                    Narration = transaction.Narration,
                    TransactionDate = DateTime.Now,
                    SenderAccountNumber = transaction.SenderAccountNumber,
                    SenderAccountName = benefiActName,
                    TransactionType = (DataAccess.Entities.Enums.TransactionType)transaction.TransactionType
                };
                await dbContext.Transactions.AddAsync(tran);
                await dbContext.SaveChangesAsync();

                return tran.TransactionID;
            }
        }

        public async Task<string> GetCustomerNameAsync(long actNo)
        {
            //CustomerAccount account = new CustomerAccount();
          
                var AccountData =  dbContext.Accounts.FirstOrDefault(n => n.AccountNumber == actNo);
                if (AccountData != null)
                {
                var CusId = AccountData.CustomerID;

                var Customer = dbContext.Customers.FirstOrDefault(n => n.ID == AccountData.CustomerID);

                return Customer.LastName + " " + Customer.FirstName + " " + Customer.MiddleName;
                 }
            else
            {
                return "No Matching Account Details.....";

            }

        }

        public async Task<List<TransactionsModel>> GetAllTransactions()
        {
           // var data = await dbContext.Transactions.Include(n => n.).Include(m => m.Lga).ToListAsync();


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

        public async Task<TransactionsModel> GetTransactionDataByID(Guid id)
        {
            var Data = await dbContext.Transactions
               .FirstOrDefaultAsync(n => n.TransactionID == id);

            var result = new TransactionsModel()
            {
                Amount = Data.Amount,
                BeneficiaryAccountNumber = Data.BeneficiaryAccountNumber,
                BeneficiaryAccountName = Data.BeneficiaryAccountName,
                Narration = Data.Narration,
                SenderAccountNumber = Data.SenderAccountNumber,
                SenderAccountName = Data.SenderAccountName,
                TransactionDate = Data.TransactionDate,
                TransactionType = (Model.Enums.TransactionType)Data.TransactionType,
                TransactionID = Data.TransactionID
            };

            return result;
        }
    }
}
