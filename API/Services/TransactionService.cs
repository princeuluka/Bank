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


            var tran = new Transactions()
            {
                Amount = transaction.Amount,
                BeneficiaryAccountNumber = transaction.BeneficiaryAccountNumber,
                BeneficiaryAccountName =senderActName,
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

        public string GetCustomerNameAsync(long actNo)
        {
            var data = new List<CustomerData>();
            var data2 = new List<CustomerAccount>();
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BankApplication;Integrated Security=True;Pooling=False");
            var command = new SqlCommand();
            command = new SqlCommand("GetCustomerDetails", conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            param = command.Parameters.AddWithValue("@actNo", actNo);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            var result2 = new CustomerData();

            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    
                    result2.FirstName = reader.GetString(0);
                    result2.MiddleName = reader.GetString(1);
                    result2.LastName = reader.GetString(2);
                    data.Add(result2);
                }
                reader.Close();
            }
            else
            {
                return "No Matching Account Details.....";
            }

            return result2.FirstName + "" + result2.MiddleName+ "" + result2.LastName;
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

        public async Task<TransactionsModel> GetTransactionDataByID(Guid id)
        {
            var Data = await dbContext.Transactions
               .FirstOrDefaultAsync(n => n.TransactionID == id);

            var result = new TransactionsModel()
            {
                Amount = Data.Amount,
                BeneficiaryAccountNumber = Data.BeneficiaryAccountNumber,
                Narration = Data.Narration,
                SenderAccountNumber = Data.SenderAccountNumber,
                TransactionDate = Data.TransactionDate,
                TransactionType = (Model.Enums.TransactionType)Data.TransactionType,
                TransactionID = Data.TransactionID
            };

            return result;
        }
    }
}
