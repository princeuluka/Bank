using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class CustomerDataModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int StateOfResidenceID { get; set; }
        [ForeignKey("StateOfResidenceID")]
        public StateModel StateOfResidence { get; set; }

        public int LgaOfResidenceID { get; set; }
        [ForeignKey("LgaOfResidenceID")]
        public LGAModel LgaOfResidence { get; set; }

        public string Adress { get; set; }

        public int StateOfOriginID { get; set; }
        [ForeignKey("StateOfOriginID")]
        public StateModel StateOfOrigin { get; set; }

        public int LgaOfOriginID { get; set; }

        [ForeignKey("LgaOfOriginID")]
        public LGAModel LgaOfOrigin { get; set; }


    }
}
