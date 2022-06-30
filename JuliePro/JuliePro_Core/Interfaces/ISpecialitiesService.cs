using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using System.Threading.Tasks;

namespace JuliePro_Core.Interfaces
{
    public interface ISpecialitiesService : IBaseService
    {
        Task<GenericControllerIndexVM<SpecialityForListVM>> GetIndexVM();
        Task<GenericControllerDisplayVM<SpecialityForDisplayVM>> GetDisplayVM(ControllerAction action, int id);
        Task<GenericControllerUpsertVM<Speciality>> GetUpsertVM(ControllerAction action, int? id);
        GenericControllerUpsertVM<Speciality> GetUpsertVM(ControllerAction action, Speciality speciality);
    }
}