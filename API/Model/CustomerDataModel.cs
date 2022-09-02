using API.Data.Base;
using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class CustomerDataModel :IEntityBase
    {
        [Key]
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
        public StateModel State { get; set; }

        [ForeignKey("LgaID")]
        public int LgaID { get; set; }
        public LGAModel Lga { get; set; }

    }
}
