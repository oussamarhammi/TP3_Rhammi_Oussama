using System;
using JuliePro_Models;

namespace JuliePro_Models.ViewModels
{
    public class CustomerForListVM
    {
        public CustomerForListVM()
        { }
        public CustomerForListVM(Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            BirthDate = customer.BirthDate;
            Trainer = customer.Trainer.Name;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Trainer { get; set; }
    }
}