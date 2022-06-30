using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JuliePro_Models
{
    public class Certification
    {
      
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "TitleNotEmptyValidation")]
        [StringLength(45, MinimumLength = 15, ErrorMessage = "NameLengthValidation")]
     
        public string Title { get; set; }

        [Display(Name = "CertificationCenter")]
        [StringLength(30, ErrorMessage = "NameLengthValidation")]
   
        public string CertificationCenter { get; set; }

        public virtual ICollection<TrainerCertification> TrainerCertification { get; set; }
    }
}
