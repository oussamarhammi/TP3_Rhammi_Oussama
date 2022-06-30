using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuliePro_Models
{
    [Table("Customer")]
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "FirstNameNotEmptyValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "FirstNameLengthValidation")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "LastNameNotEmptyValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "LastNameLengthValidation")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "EmailNotEmptyValidation")]
        [DataType(DataType.EmailAddress, ErrorMessage = "EmailTypeVerification")]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        [StringLength(40, ErrorMessage = "PhotoLengthValidation")]
        public string Photo { get; set; }

        [Display(Name = "BirthDate")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "StartWeight")]
        [Range(100, 400, ErrorMessage = "StartWeightRangeValidation")]
        public double? StartWeight { get; set; }

        public virtual ICollection<Objective> Objectives { get; set; }

        [ForeignKey("Trainer")]
        public int Trainer_Id { get; set; }
        public virtual Trainer Trainer { get; set; }

        public virtual ICollection<ScheduledSession> ScheduledSessions { get; set; }


        public string Name => FirstName + " " + LastName;
    }
}
