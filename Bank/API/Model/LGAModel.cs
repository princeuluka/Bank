using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class LGAModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int StateID { get; set; }
        [ForeignKey("StateID")]
        public StateModel State { get; set; }
    }
}
