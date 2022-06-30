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
    public class TrainingsService : BaseService, ITrainingsService
    {
        public TrainingsService(JulieProDbContext db) : base(typeof(Training), db) { }

        public async override Task<bool> ExistsAsync(int id)
        {
            return await _db.Trainings.AnyAsync(t => t.Id == id);
        }

        public async Task<GenericControllerIndexVM<TrainingForListVM>> GetIndexVM()
        {
            return GetIndexVM(
                        await _db.Trainings
                                
                                    .Select(t => new TrainingForListVM(t))
                                        .ToListAsync()
            );
        }

        public async Task<GenericControllerDisplayVM<TrainingForDisplayVM>> GetDisplayVM(ControllerAction action, int id)
        {
            return GetDisplayVM(
                        action,
                        await _db.Trainings
                                
                                        .Where(t => t.Id == id)
                                            .Select(t => new TrainingForDisplayVM(t))
                                                .FirstOrDefaultAsync()
            );        
        }

        public async Task<GenericControllerUpsertVM<Training>> GetUpsertVM(ControllerAction action, int? id)
        {
            return GetUpsertVM(action, action == ControllerAction.Create ? null : await _db.Trainings.FindAsync((int)id));                
        }

        public GenericControllerUpsertVM<Training> GetUpsertVM(ControllerAction action, Training training)
        {
            return GetUpsertVM(
                        action,
                        new Dictionary<string, SelectList­>(){},
                        training,
                        training?.Id
            );
        }
    }
}