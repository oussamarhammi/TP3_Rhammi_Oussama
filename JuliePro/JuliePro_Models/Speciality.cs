using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    [Table("Speciality")]
    public class Speciality
    {
        public int Id { get; set; }

        [Display(Name = "SpecialityName")]
        [Required(ErrorMessage = "RequiredValidation")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "MinMaxLengthValidation")]
        public string Name { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
