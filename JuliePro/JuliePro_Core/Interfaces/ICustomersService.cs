using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using System.Threading.Tasks;

namespace JuliePro_Core.Interfaces
{
    public interface ICustomersService : IBaseService
    {
        Task<GenericControllerIndexVM<CustomerForListVM>> GetIndexVM();
        Task<GenericControllerDisplayVM<CustomerForDisplayVM>> GetDisplayVM(ControllerAction action, int id);
        Task<GenericControllerUpsertVM<Customer>> GetUpsertVM(ControllerAction action, int? id);
        GenericControllerUpsertVM<Customer> GetUpsertVM(ControllerAction action, Customer customer);
    }
}