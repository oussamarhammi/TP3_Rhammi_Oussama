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
    public class EquipmentsService : BaseService, IEquipmentsService
    {
        public EquipmentsService(JulieProDbContext db) : base(typeof(Equipment), db) { }

        public async override Task<bool> ExistsAsync(int id)
        {
            return await _db.Equipments.AnyAsync(e => e.Id == id);
        }

        public async Task<GenericControllerIndexVM<EquipmentForListVM>> GetIndexVM()
        {
            return GetIndexVM(
                        await _db.Equipments
                                
                                    .Select(e => new EquipmentForListVM(e))
                                        .ToListAsync()
            );
        }

        public async Task<GenericControllerDisplayVM<EquipmentForDisplayVM>> GetDisplayVM(ControllerAction action, int id)
        {
            return GetDisplayVM(
                        action,
                        await _db.Equipments
                                
                                        .Where(e => e.Id == id)
                                            .Select(e => new EquipmentForDisplayVM(e))
                                                .FirstOrDefaultAsync()
            );        
        }

        public async Task<GenericControllerUpsertVM<Equipment>> GetUpsertVM(ControllerAction action, int? id)
        {
            return GetUpsertVM(action, action == ControllerAction.Create ? null : await _db.Equipments.FindAsync((int)id));                
        }

        public GenericControllerUpsertVM<Equipment> GetUpsertVM(ControllerAction action, Equipment equipment)
        {
            return GetUpsertVM(
                        action,
                        new Dictionary<string, SelectList­>(){},
                        equipment,
                        equipment?.Id
            );
        }
    }
}