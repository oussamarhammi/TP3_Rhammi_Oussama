using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class CategoryForDisplayVM : BaseEntityForDisplayVM
    {
        public CategoryForDisplayVM() 
            : base()
        { }
        public CategoryForDisplayVM(Category category) 
            : base()
        {
            Id = category.Id;
            CategoryName = category.CategoryName;
        }

        public string CategoryName { get; set; }
    }
}