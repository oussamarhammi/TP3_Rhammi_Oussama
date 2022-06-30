using JuliePro_DataAccess.Data;
using JuliePro_Models.ViewModels;
using JuliePro_Core.Interfaces;
using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro_Core
{
    public abstract class BaseService : IBaseService
    {
        protected readonly JulieProDbContext _db;
        private readonly string _dbSetName;
        private readonly string _className;

        public BaseService(Type TEntityType, JulieProDbContext db)
        {
            _db = db;
            _dbSetName = _db.GetType().GetProperties().Where(p => p.PropertyType.GenericTypeArguments.First().Name == TEntityType.Name).FirstOrDefault()?.Name;
            _className = TEntityType.Name;
        }

        public abstract Task<bool> ExistsAsync(int id);

        public IQueryable<TEntity> GetAllAsync<TEntity>() where TEntity : class
        {
            return _db.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public async Task<int> AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _db.Add(entity);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                _db.Update(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<TEntity>(int id) where TEntity : class
        {
            TEntity entity = await GetByIdAsync<TEntity>(id);
            _db.Set<TEntity>().Remove(entity);
            return await _db.SaveChangesAsync();
        }

        public GenericControllerIndexVM<TEntityForListVM> GetIndexVM<TEntityForListVM>(ICollection<TEntityForListVM> list) where TEntityForListVM : class
        {
            return new GenericControllerIndexVM<TEntityForListVM>().Init<TEntityForListVM>(
                "List" + _dbSetName,
                "List" + _dbSetName,
                new List<PageLinks>() { PageLinks.Create },
                null,
                list
            );
        }

        public GenericControllerDisplayVM<TEntityForDisplayVM> GetDisplayVM<TEntityForDisplayVM>(ControllerAction action, TEntityForDisplayVM entity) where TEntityForDisplayVM : BaseEntityForDisplayVM
        {
            bool isDetails = action == ControllerAction.Details;
            List<PageLinks> pageLinks = new List<PageLinks>() { PageLinks.BackToList };

            if (isDetails)
                pageLinks.Add(PageLinks.Edit);

            return new GenericControllerDisplayVM<TEntityForDisplayVM>().Init(
                isDetails,
                _className,
                _className + (isDetails ? "" : "Delete"),
                pageLinks,
                (isDetails ? null : "Delete"),
                entity
            );
        }

        public GenericControllerUpsertVM<TEntity> GetUpsertVM<TEntity>(ControllerAction action, Dictionary<string, SelectList­> selectLists, TEntity entity, int? entityId = null) where TEntity : class
        {
            bool isCreate = action == ControllerAction.Create;

            return (GenericControllerUpsertVM<TEntity>)new GenericControllerUpsertVM<TEntity>().Init(
                isCreate,
                _className,
                _className,
                new List<PageLinks>() { PageLinks.BackToList },
                isCreate ? "Add" : "Update",
                selectLists,
                entity,
                entityId
            );
        }
    }
}
