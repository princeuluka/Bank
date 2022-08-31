using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class BvnVerificationRepo
    {
        public int ID { get; set; }
        public string BVN { get; set; }
        public string CustomerId { get; set; }
        public string TicketId { get; set; }
        public string Operator { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public string IpAddress { get; set; }
        public string Branch { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
    }
}
