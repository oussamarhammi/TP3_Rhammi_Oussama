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
    public class TrainersService : BaseService, ITrainersService
    {
        public TrainersService(JulieProDbContext db) : base(typeof(Trainer), db) { }

        public async override Task<bool> ExistsAsync(int id)
        {
            return await _db.Trainers.AnyAsync(t => t.Id == id);
        }

        public List<Trainer> GetAllActive()
        {
            return _db.Trainers.Where(a => a.Active == true).ToList();
        }

        public async Task<GenericControllerIndexVM<TrainerForListVM>> GetIndexVM()
        {
            return GetIndexVM(
                        await _db.Trainers
                                .Include(t => t.Speciality)
                                    .Select(t => new TrainerForListVM(t))
                                        .ToListAsync()
            );
        }

        public async Task<GenericControllerDisplayVM<TrainerForDisplayVM>> GetDisplayVM(ControllerAction action, int id)
        {
            return GetDisplayVM(
                        action,
                        await _db.Trainers
                                .Include(t => t.Speciality)
                                        .Where(t => t.Id == id)
                                            .Select(t => new TrainerForDisplayVM(t))
                                                .FirstOrDefaultAsync()
            );        
        }

        public async Task<GenericControllerUpsertVM<Trainer>> GetUpsertVM(ControllerAction action, int? id)
        {
            return GetUpsertVM(action, action == ControllerAction.Create ? null : await _db.Trainers.FindAsync((int)id));                
        }

        public GenericControllerUpsertVM<Trainer> GetUpsertVM(ControllerAction action, Trainer trainer)
        {
            return GetUpsertVM(
                        action,
                        new Dictionary<string, SelectList­>(){{ "ListForSpeciality_Id", new SelectList(_db.Specialities, "Id", "Name") }},
                        trainer,
                        trainer?.Id
            );
        }

    }
}