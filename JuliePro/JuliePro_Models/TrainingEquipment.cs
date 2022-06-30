using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    [Table("TrainingEquipment")]
    public class TrainingEquipment
    {
        [ForeignKey("Training")]
        public int Training_Id { get; set; }

        [ForeignKey("Equipment")]
        public int Equipment_Id { get; set; }

        public virtual Training Training { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
