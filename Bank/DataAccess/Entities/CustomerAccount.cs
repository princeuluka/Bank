using DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CustomerAccount
    {
        public int ID { get; set; }

        public double AvailableBalance { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public CustomerData Customer { get; set; }

        public AccountType AccountType { get; set; }
    }
}
