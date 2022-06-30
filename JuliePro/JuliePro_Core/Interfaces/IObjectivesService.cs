using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using System.Threading.Tasks;

namespace JuliePro_Core.Interfaces
{
    public interface IObjectivesService : IBaseService
    {
        Task<GenericControllerIndexVM<ObjectiveForListVM>> GetIndexVM();
        Task<GenericControllerDisplayVM<ObjectiveForDisplayVM>> GetDisplayVM(ControllerAction action, int id);
        Task<GenericControllerUpsertVM<Objective>> GetUpsertVM(ControllerAction action, int? id);
        GenericControllerUpsertVM<Objective> GetUpsertVM(ControllerAction action, Objective objective);
    }
}