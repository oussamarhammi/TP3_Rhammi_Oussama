using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using System.Threading.Tasks;

namespace JuliePro_Core.Interfaces
{
    public interface ICategoriesService : IBaseService
    {
        Task<GenericControllerIndexVM<CategoryForListVM>> GetIndexVM();
        Task<GenericControllerDisplayVM<CategoryForDisplayVM>> GetDisplayVM(ControllerAction action, int id);
        Task<GenericControllerUpsertVM<Category>> GetUpsertVM(ControllerAction action, int? id);
        GenericControllerUpsertVM<Category> GetUpsertVM(ControllerAction action, Category category);
    }
}