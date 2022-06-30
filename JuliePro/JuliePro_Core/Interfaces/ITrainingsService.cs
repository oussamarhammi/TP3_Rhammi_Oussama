using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using System.Threading.Tasks;

namespace JuliePro_Core.Interfaces
{
    public interface ITrainingsService : IBaseService
    {
        Task<GenericControllerIndexVM<TrainingForListVM>> GetIndexVM();
        Task<GenericControllerDisplayVM<TrainingForDisplayVM>> GetDisplayVM(ControllerAction action, int id);
        Task<GenericControllerUpsertVM<Training>> GetUpsertVM(ControllerAction action, int? id);
        GenericControllerUpsertVM<Training> GetUpsertVM(ControllerAction action, Training training);
    }
}