using API.Model.Enums;

namespace API.Model
{
    public class TransactionsModel
    {
        public Guid TransactionID { get; set; }

        public TransactionType TransactionType { get; set; }

        public int SenderAccountNumber { get; set; }

        public int BeneficiaryAccountNumber { get; set; }

        public double Amount { get; set; }

       public DateTime TransactionDate { get; set; }

        public string Narration { get; set; }
        public string BeneficiaryAccountName { get; set; }
        public string SenderAccountName { get; set; }
    }
}
