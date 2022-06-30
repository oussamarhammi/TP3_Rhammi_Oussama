using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using System.Threading.Tasks;

namespace JuliePro_Core.Interfaces
{
    public interface IEquipmentsService : IBaseService
    {
        Task<GenericControllerIndexVM<EquipmentForListVM>> GetIndexVM();
        Task<GenericControllerDisplayVM<EquipmentForDisplayVM>> GetDisplayVM(ControllerAction action, int id);
        Task<GenericControllerUpsertVM<Equipment>> GetUpsertVM(ControllerAction action, int? id);
        GenericControllerUpsertVM<Equipment> GetUpsertVM(ControllerAction action, Equipment equipment);
    }
}