using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class LGA
    {
        public int LgaID { get; set; }
        public string Name { get; set; }

        public int StateID { get; set; }
        [ForeignKey("StateID")]
        public State State { get; set; }
    }
}
