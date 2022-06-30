using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class ObjectiveForListVM
    {
        public ObjectiveForListVM()
        { }
        public ObjectiveForListVM(Objective objective)
        {
            Id = objective.Id;
            Name = objective.Name;
            LostWeight = objective.LostWeight;
            DistanceKm = objective.DistanceKm;
            AchievedDate = objective.AchievedDate;
            Customer = objective.Customer.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? LostWeight { get; set; }
        public double? DistanceKm { get; set; }
        public DateTime? AchievedDate { get; set; }
        public string Customer { get; set; }
    }
}