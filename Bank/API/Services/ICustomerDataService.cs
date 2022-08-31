using API.Model;

namespace API.Services
{
    public interface ICustomerDataService
    {
        Task<List<CustomerDataModel>> List();
    }
}
