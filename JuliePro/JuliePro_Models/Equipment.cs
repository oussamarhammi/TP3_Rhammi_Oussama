using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    [Table("Equipment")]
    public class Equipment
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "NameNotEmptyValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "NameLengthValidation")]
        public string Name { get; set; }

        public virtual ICollection<TrainingEquipment> TrainingEquipments { get; set; }
    }
}
