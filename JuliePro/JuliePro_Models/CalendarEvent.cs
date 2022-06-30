using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Models
{
    [Table("CalendarEvent")]
    public class CalendarEvent
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "RequiredValidation")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "RequiredValidation")]
        [StringLength(25, MinimumLength = 10, ErrorMessage = "MinMaxLengthValidation")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public virtual Category Category { get; set; }
    }
}
