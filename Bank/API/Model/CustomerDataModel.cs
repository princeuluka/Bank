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
        public string StateOfResidenceID { get; set; }
        public int LgaOfResidenceID { get; set; }
        public string Adress { get; set; }

        [ForeignKey("StateOfOriginID")]
        public int StateOfOriginID { get; set; }
        public StateModel StateOfOrigin { get; set; }

        [ForeignKey("LgaOfOriginID")]
        public int LgaOfOriginID { get; set; }
        public LGAModel LgaOfOrigin { get; set; }


    }
}
