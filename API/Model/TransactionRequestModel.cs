namespace API.Model
{
    public class TransactionRequestModel
    {
        public List<CustomerAccountModel> CustomerAccount {get; set;}

        public List<CustomerDataModel> customerDatas { get; set; }
    }
}
