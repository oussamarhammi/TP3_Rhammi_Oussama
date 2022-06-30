using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro_Core.Interfaces
{
    public interface IBaseService
    {
        Task<bool> ExistsAsync(int id);
        IQueryable<TEntity> GetAllAsync<TEntity>() where TEntity : class;
        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task<int> DeleteAsync<TEntity>(int id) where TEntity : class;
        GenericControllerIndexVM<TEntityForListVM> GetIndexVM<TEntityForListVM>(ICollection<TEntityForListVM> list) where TEntityForListVM : class;
        GenericControllerDisplayVM<TEntityForDisplayVM> GetDisplayVM<TEntityForDisplayVM>(ControllerAction action, TEntityForDisplayVM entity) where TEntityForDisplayVM : BaseEntityForDisplayVM;
        GenericControllerUpsertVM<TEntity> GetUpsertVM<TEntity>(ControllerAction action, Dictionary<string, SelectList­> selectLists, TEntity entity, int? entityId = null) where TEntity : class;
    }
}
