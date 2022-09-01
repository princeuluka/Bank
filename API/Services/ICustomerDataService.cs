using API.Model;

namespace API.Services
{
    public interface ICustomerDataService
    {
        Task<List<CustomerDataModel>> GetAllCustomers();
        Task<List<StateModel>> GetAllStates();
        Task<List<LGAModel>> GetAllLga();
        Task AddNewAccountAsync(CustomerDataModel customer);
        Task UpdateAccountAsync(CustomerDataModel customer);

        Task<CustomerAccountModel> GetCustomerDataByAccountNo(long actNo);


    }
}
