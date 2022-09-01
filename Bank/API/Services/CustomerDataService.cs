using API.Model;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly ApplicationDbContext dbContext;

        public CustomerDataService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<CustomerDataModel>> List()
        {
            var data = await (from Customer in dbContext.Customers
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
                                 StateID=Customer.StateID,
                                StateOfResidenceID = Customer.StateOfResidenceID
                              }).ToListAsync();
            return data;
        }
    }
}
