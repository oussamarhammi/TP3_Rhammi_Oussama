using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    [Table("Objective")]
    public class Objective
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "MinMaxLengthValidation")]
        public string Name { get; set; }

        [Display(Name = "LostWeight")]
        [Range(2, 10, ErrorMessage = "MinMaxValidation")]
        public double? LostWeight { get; set; }

        [Display(Name = "DistanceKm")]
        [Range(2, 45, ErrorMessage = "MinMaxValidation")]
        public double? DistanceKm { get; set; }

        [Display(Name = "AchievedDate")]
        [DataType(DataType.Date)]
        public DateTime? AchievedDate { get; set; }

        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
