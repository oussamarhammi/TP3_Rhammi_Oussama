using JuliePro_DataAccess.Data;
using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Core.Interfaces;
using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JuliePro_Core
{
    public class CustomersService : BaseService, ICustomersService
    {
        public CustomersService(JulieProDbContext db) : base(typeof(Customer), db) { }

        public async override Task<bool> ExistsAsync(int id)
        {
            return await _db.Customers.AnyAsync(c => c.Id == id);
        }

        public async Task<GenericControllerIndexVM<CustomerForListVM>> GetIndexVM()
        {
            return GetIndexVM(
                        await _db.Customers
                                .Include(c => c.Trainer)
                                    .Select(c => new CustomerForListVM(c))
                                        .ToListAsync()
            );
        }

        public async Task<GenericControllerDisplayVM<CustomerForDisplayVM>> GetDisplayVM(ControllerAction action, int id)
        {
            return GetDisplayVM(
                        action,
                        await _db.Customers
                                .Include(c => c.Trainer)
                                        .Where(c => c.Id == id)
                                            .Select(c => new CustomerForDisplayVM(c))
                                                .FirstOrDefaultAsync()
            );        
        }

        public async Task<GenericControllerUpsertVM<Customer>> GetUpsertVM(ControllerAction action, int? id)
        {
            return GetUpsertVM(action, action == ControllerAction.Create ? null : await _db.Customers.FindAsync((int)id));                
        }

        public GenericControllerUpsertVM<Customer> GetUpsertVM(ControllerAction action, Customer customer)
        {
            return GetUpsertVM(
                        action,
                        new Dictionary<string, SelectList­>(){{ "ListForTrainer_Id", new SelectList(_db.Trainers, "Id", "Email") }},
                        customer,
                        customer?.Id
            );
        }
    }
}