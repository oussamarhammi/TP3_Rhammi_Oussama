using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class EquipmentForListVM
    {
        public EquipmentForListVM()
        { }
        public EquipmentForListVM(Equipment equipment)
        {
            Id = equipment.Id;
            Name = equipment.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}