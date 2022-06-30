using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class TrainingForListVM
    {
        public TrainingForListVM()
        { }
        public TrainingForListVM(Training training)
        {
            Id = training.Id;
            Name = training.Name;
            Category = training.Category;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}