using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class SpecialityForDisplayVM : BaseEntityForDisplayVM
    {
        public SpecialityForDisplayVM() 
            : base()
        { }
        public SpecialityForDisplayVM(Speciality speciality) 
            : base()
        {
            Id = speciality.Id;
            Name = speciality.Name;
        }

        public string Name { get; set; }
    }
}