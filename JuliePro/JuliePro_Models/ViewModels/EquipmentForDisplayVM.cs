using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class EquipmentForDisplayVM : BaseEntityForDisplayVM
    {
        public EquipmentForDisplayVM() 
            : base()
        { }
        public EquipmentForDisplayVM(Equipment equipment) 
            : base()
        {
            Id = equipment.Id;
            Name = equipment.Name;
        }

        public string Name { get; set; }
    }
}