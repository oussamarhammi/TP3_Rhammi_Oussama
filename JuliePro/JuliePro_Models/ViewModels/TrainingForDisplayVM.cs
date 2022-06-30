using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class TrainingForDisplayVM : BaseEntityForDisplayVM
    {
        public TrainingForDisplayVM() 
            : base()
        { }
        public TrainingForDisplayVM(Training training) 
            : base()
        {
            Id = training.Id;
            Name = training.Name;
            Category = training.Category;
        }

        public string Name { get; set; }
        public string Category { get; set; }
    }
}