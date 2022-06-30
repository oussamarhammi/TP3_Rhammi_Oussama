using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class TrainerForListVM
    {
        public TrainerForListVM()
        { }
        public TrainerForListVM(Trainer trainer)
        {
            Id = trainer.Id;
            FirstName = trainer.FirstName;
            LastName = trainer.LastName;
            Email = trainer.Email;
            Speciality = trainer.Speciality.Name;
            Active = trainer.Active;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Speciality { get; set; }
        public bool Active { get; set; }
    }
}