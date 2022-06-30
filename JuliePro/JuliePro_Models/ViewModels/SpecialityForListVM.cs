using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class SpecialityForListVM
    {
        public SpecialityForListVM()
        { }
        public SpecialityForListVM(Speciality speciality)
        {
            Id = speciality.Id;
            Name = speciality.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}