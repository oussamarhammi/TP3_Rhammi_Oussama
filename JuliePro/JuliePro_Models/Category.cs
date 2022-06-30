using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JuliePro_Models
{
    [Table("Category")]
    public class Category
    {
      
        public int Id { get; set; }

        [Display(Name = "CategoryName")]
        [Required(ErrorMessage = "RequiredValidation")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "MinMaxLengthValidation")]
    
        public string CategoryName { get; set; }

        public virtual ICollection<CalendarEvent> Events { get; set; }
    }
}
