using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    [Table("Trainer")]
    public class Trainer
    {

        public int Id { get; set; }

        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "RequiredValidation")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "MinMaxLengthValidation")]
        public string LastName { get; set; }

        [Display(Name = "Biography")]
        public string Biography { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "RequiredValidation")]
        [DataType(DataType.EmailAddress, ErrorMessage = "EmailTypeVerification")]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        [StringLength(40, ErrorMessage = "MaxVerification")]
        public string Photo { get; set; }

        [ForeignKey("Speciality")]
        public int Speciality_Id { get; set; }
        public virtual Speciality Speciality { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; } = false;

        public virtual ICollection<Customer> Customers { get; set; }

        public virtual ICollection<TrainerCertification> TrainerCertification { get; set; }


        public string Name => FirstName + " " + LastName;
    }
}
