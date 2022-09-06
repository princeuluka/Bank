using DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public  class Transactions
    {
        [Key]
        public Guid TransactionID { get; set; }

        public TransactionType TransactionType { get; set; }

        public int SenderAccountNumber { get; set; }

        public string SenderAccountName { get; set; }

        public int BeneficiaryAccountNumber { get; set; }
        public string  BeneficiaryAccountName { get; set; }

        public double Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Narration { get; set; }

       
    }
}
