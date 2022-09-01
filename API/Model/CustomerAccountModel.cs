using API.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class CustomerAccountModel
    {
        public int ID { get; set; }

        public double AvailableBalance { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public CustomerDataModel Customer { get; set; }

        public AccountType AccountType { get; set; }

        public long AccountNumber { get; set; }

        //public static implicit operator CustomerAccountModel(CustomerAccountModel v) => throw new NotImplementedException();
    }
}
