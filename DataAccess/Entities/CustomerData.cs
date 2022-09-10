using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CustomerData 
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StateOfResidenceID { get; set; }
        public int LgaOfResidenceID { get; set; }
        public string Adress { get; set; }

        [ForeignKey("StateID")]
        public int StateID { get; set; }
        public State State { get; set; }

        [ForeignKey("LgaID")]
        public int LgaID { get; set; }
        public LGA Lga { get; set; }





    }
}
