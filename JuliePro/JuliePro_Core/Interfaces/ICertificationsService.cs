using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using System.Threading.Tasks;

namespace JuliePro_Core.Interfaces
{
    public interface ICertificationsService : IBaseService
    {
        Task<GenericControllerIndexVM<CertificationForListVM>> GetIndexVM();
        Task<GenericControllerDisplayVM<CertificationForDisplayVM>> GetDisplayVM(ControllerAction action, int id);
        Task<GenericControllerUpsertVM<Certification>> GetUpsertVM(ControllerAction action, int? id);
        GenericControllerUpsertVM<Certification> GetUpsertVM(ControllerAction action, Certification certification);
    }
}