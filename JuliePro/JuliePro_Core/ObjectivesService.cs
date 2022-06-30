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
    public class ObjectivesService : BaseService, IObjectivesService
    {
        public ObjectivesService(JulieProDbContext db) : base(typeof(Objective), db) { }

        public async override Task<bool> ExistsAsync(int id)
        {
            return await _db.Objectives.AnyAsync(o => o.Id == id);
        }

        public async Task<GenericControllerIndexVM<ObjectiveForListVM>> GetIndexVM()
        {
            return GetIndexVM(
                        await _db.Objectives
                                .Include(o => o.Customer)
                                    .Select(o => new ObjectiveForListVM(o))
                                        .ToListAsync()
            );
        }

        public async Task<GenericControllerDisplayVM<ObjectiveForDisplayVM>> GetDisplayVM(ControllerAction action, int id)
        {
            return GetDisplayVM(
                        action,
                        await _db.Objectives
                                .Include(o => o.Customer)
                                        .Where(o => o.Id == id)
                                            .Select(o => new ObjectiveForDisplayVM(o))
                                                .FirstOrDefaultAsync()
            );        
        }

        public async Task<GenericControllerUpsertVM<Objective>> GetUpsertVM(ControllerAction action, int? id)
        {
            return GetUpsertVM(action, action == ControllerAction.Create ? null : await _db.Objectives.FindAsync((int)id));                
        }

        public GenericControllerUpsertVM<Objective> GetUpsertVM(ControllerAction action, Objective objective)
        {
            return GetUpsertVM(
                        action,
                        new Dictionary<string, SelectList­>(){{ "ListForCustomer_Id", new SelectList(_db.Customers, "Id", "Email") }},
                        objective,
                        objective?.Id
            );
        }
    }
}