using API.Data.Base;
using API.Model;
using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CustomerDataService : EntityBaseRepositoryy<CustomerDataModel>, ICustomerDataService
    {
        private readonly ApplicationDbContext dbContext;

        public CustomerDataService(ApplicationDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddNewAccountAsync(CustomerDataModel Customer)
        {
            var newAccount = new CustomerData()
            {
                Adress = Customer.Adress,
                DateOfBirth = Customer.DateOfBirth,
                FirstName = Customer.FirstName,
                MiddleName = Customer.MiddleName,
                LastName = Customer.LastName,
                LgaID = Customer.LgaID,
                LgaOfResidenceID = Customer.LgaOfResidenceID,
                StateID = Customer.StateID,
                StateOfResidenceID = Customer.StateOfResidenceID
            };
            await dbContext.Customers.AddAsync(newAccount);
            await dbContext.SaveChangesAsync();

            var accountData = new CustomerAccount()
            {
                AccountNumber = CreateAccountNumber(),
                AvailableBalance = 0.00,
                AccountType = AccountType.Savings,
                CustomerID = newAccount.ID
               
            };

        
        await dbContext.Accounts.AddAsync(accountData);

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<CustomerDataModel>> GetAllCustomers()
        {
            var data = await(from Customer in dbContext.Customers
                             select new CustomerDataModel()
                             {
                                 ID = Customer.ID,
                                 Adress = Customer.Adress,
                                 DateOfBirth = Customer.DateOfBirth,
                                 FirstName = Customer.FirstName,
                                 MiddleName = Customer.MiddleName,
                                 LastName = Customer.LastName,
                                 LgaID = Customer.LgaID,
                                 LgaOfResidenceID = Customer.LgaOfResidenceID,
                                 StateID = Customer.StateID,
                                 StateOfResidenceID = Customer.StateOfResidenceID
                             }).ToListAsync();
            return data;
        }

        public async Task<List<LGAModel>> GetAllLga()
        {
            var data = await(from Lga in dbContext.LGAs
                             select new LGAModel()
                             {
                                LgaID = Lga.LgaID,
                                Name = Lga.Name,
                                StateID = Lga.StateID
                             }).ToListAsync();
            return data;
        }

        public async Task<List<StateModel>> GetAllStates()
        {
            var data = await (from state in dbContext.States
                              select new StateModel()
                              {
                                 Name = state.Name,
                                 StateID = state.StateID
                              }).ToListAsync();
            return data;
        }

        public async Task UpdateAccountAsync(CustomerDataModel Customer)
        {
            var data = await dbContext.Customers.FirstOrDefaultAsync(n => n.ID == Customer.ID);
            if (data != null)
            {
                data.Adress = Customer.Adress;
                data.DateOfBirth = Customer.DateOfBirth;
                data.FirstName = Customer.FirstName;
                data.MiddleName = Customer.MiddleName;
                data.LastName = Customer.LastName;
                data.LgaID = Customer.LgaID;
                data.LgaOfResidenceID = Customer.LgaOfResidenceID;
                data.StateID = Customer.StateID;
                data.StateOfResidenceID = Customer.StateOfResidenceID;
                await dbContext.SaveChangesAsync();
            }

        }


        private long CreateAccountNumber()
        {
            Random random = new Random();
            long newAccountNumber;
            do
            {
                newAccountNumber = random.Next(32000000, 33000000);
            } while (AccountNumberChecker(newAccountNumber));
 
             return newAccountNumber;
        }

        private   bool AccountNumberChecker(long number)
        {
            var data =   dbContext.Accounts.FirstOrDefaultAsync(n => n.AccountNumber == number);
            if (data != null)
            {
                return false;
            }
            else
            {
                return true;
            }     
        }

        public async Task<CustomerAccountModel> GetCustomerDataByAccountNo(long actNo)
        {
            var Data = await dbContext.Accounts
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(n => n.AccountNumber == actNo);

            var data1 = new CustomerAccountModel()
            {
                AccountNumber = Data.AccountNumber,
                AccountType = (Model.Enums.AccountType)Data.AccountType,
                AvailableBalance = Data.AvailableBalance,
                //Customer = Data.Customer,
                CustomerID = Data.CustomerID

            };

            return data1;
        }
    }
}
