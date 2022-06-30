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
    public class SpecialitiesService : BaseService, ISpecialitiesService
    {
        public SpecialitiesService(JulieProDbContext db) : base(typeof(Speciality), db) { }

        public async override Task<bool> ExistsAsync(int id)
        {
            return await _db.Specialities.AnyAsync(s => s.Id == id);
        }

        public async Task<GenericControllerIndexVM<SpecialityForListVM>> GetIndexVM()
        {
            return GetIndexVM(
                        await _db.Specialities
                                
                                    .Select(s => new SpecialityForListVM(s))
                                        .ToListAsync()
            );
        }

        public async Task<GenericControllerDisplayVM<SpecialityForDisplayVM>> GetDisplayVM(ControllerAction action, int id)
        {
            return GetDisplayVM(
                        action,
                        await _db.Specialities
                                
                                        .Where(s => s.Id == id)
                                            .Select(s => new SpecialityForDisplayVM(s))
                                                .FirstOrDefaultAsync()
            );        
        }

        public async Task<GenericControllerUpsertVM<Speciality>> GetUpsertVM(ControllerAction action, int? id)
        {
            return GetUpsertVM(action, action == ControllerAction.Create ? null : await _db.Specialities.FindAsync((int)id));                
        }

        public GenericControllerUpsertVM<Speciality> GetUpsertVM(ControllerAction action, Speciality speciality)
        {
            return GetUpsertVM(
                        action,
                        new Dictionary<string, SelectList­>(){},
                        speciality,
                        speciality?.Id
            );
        }
    }
}