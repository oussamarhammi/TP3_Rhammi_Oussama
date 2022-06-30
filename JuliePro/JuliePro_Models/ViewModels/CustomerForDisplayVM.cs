using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class CustomerForDisplayVM : BaseEntityForDisplayVM
    {
        public CustomerForDisplayVM() 
            : base()
        { }
        public CustomerForDisplayVM(Customer customer) 
            : base()
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            Photo = customer.Photo;
            BirthDate = customer.BirthDate;
            StartWeight = customer.StartWeight;
            Trainer = customer.Trainer.Name;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime? BirthDate { get; set; }
        public double? StartWeight { get; set; }
        public string Trainer { get; set; }
    }
}