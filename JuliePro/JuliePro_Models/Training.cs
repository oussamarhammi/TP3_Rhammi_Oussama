using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    [Table("Training")]
    public class Training
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "NameNotEmptyValidation")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "NameLengthValidation")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "CategoryNotEmptyValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "CategoryLengthValidation")]
        public string Category { get; set; }

        public virtual ICollection<ScheduledSession> ScheduledSessions { get; set; }

        public virtual ICollection<TrainingEquipment> TrainingEquipments { get; set; }
    }
}
