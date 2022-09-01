using API.Model;
using DataAccess.Data;
using DataAccess.Entities;

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
        public async Task NewTransaction(TransactionsModel transaction)
        {
            var senderCustomerData = customerDataService.GetCustomerDataByAccountNo(transaction.SenderAccountNumber);
            var beneficiaryCustomerData = new CustomerAccountModel();

                
            //   //beneficiaryCustomerData =  customerDataService.GetCustomerDataByAccountNo(transaction.BeneficiaryAccountNumber);


          

            //var tran = new Transactions()
            //{
            //    Amount = transaction.Amount,
            //    BeneficiaryAccountNumber = transaction.BeneficiaryAccountNumber,
            //    BeneficiaryAccountName = beneficiaryCustomerData.
            //}
        }
    }
}
