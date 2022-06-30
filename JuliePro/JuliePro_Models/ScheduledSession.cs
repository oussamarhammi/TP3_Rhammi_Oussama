using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    [Table("ScheduledSession")]
    public class ScheduledSession
    {
        public int Id { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "RequiredValidation")]
        public string Description { get; set; }

        [Display(Name = "Detail")]
        public string Detail { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "RequiredValidation")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name = "DurationMin")]
        [Required(ErrorMessage = "RequiredValidation")]
        [Range(20, 90, ErrorMessage = "MinMaxValidation")]
        public int? DurationMin { get; set; }

        public bool? WithTrainer { get; set; }

        public bool? Complete { get; set; }

        [ForeignKey("Training")]
        public int Training_Id { get; set; }
        public virtual Training Training { get; set; }

        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
