using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerData
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int StateOfResidenceID { get; set; }
        public State StateOfResidence { get; set; }

        public int LgaOfResidenceID { get; set; }
        public LGA  LgaOfResidence { get; set; }

        public string Adress { get; set; }

        public int StateOfOriginID { get; set; }
        public State StateOfOrigin { get; set; }

        public int LgaOfOriginID { get; set; }
        public LGA LgaOfOrigin { get; set; }





    }
}
