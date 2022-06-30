using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class TrainerForDisplayVM : BaseEntityForDisplayVM
    {
        public TrainerForDisplayVM() 
            : base()
        { }
        public TrainerForDisplayVM(Trainer trainer) 
            : base()
        {
            Id = trainer.Id;
            FirstName = trainer.FirstName;
            LastName = trainer.LastName;
            Biography = trainer.Biography;
            Email = trainer.Email;
            Photo = trainer.Photo;
            Speciality = trainer.Speciality.Name;
            Active = trainer.Active;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Speciality { get; set; }
        public bool Active { get; set; }
    }
}