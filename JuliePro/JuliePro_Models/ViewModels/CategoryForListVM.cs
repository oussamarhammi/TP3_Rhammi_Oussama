using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class CategoryForListVM
    {
        public CategoryForListVM()
        { }
        public CategoryForListVM(Category category)
        {
            Id = category.Id;
            CategoryName = category.CategoryName;
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}