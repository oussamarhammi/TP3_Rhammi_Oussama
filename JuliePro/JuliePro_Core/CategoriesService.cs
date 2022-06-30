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
    public class CategoriesService : BaseService, ICategoriesService
    {
        public CategoriesService(JulieProDbContext db) : base(typeof(Category), db) { }

        public async override Task<bool> ExistsAsync(int id)
        {
            return await _db.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<GenericControllerIndexVM<CategoryForListVM>> GetIndexVM()
        {
            return GetIndexVM(
                        await _db.Categories
                                
                                    .Select(c => new CategoryForListVM(c))
                                        .ToListAsync()
            );
        }

        public async Task<GenericControllerDisplayVM<CategoryForDisplayVM>> GetDisplayVM(ControllerAction action, int id)
        {
            return GetDisplayVM(
                        action,
                        await _db.Categories
                                
                                        .Where(c => c.Id == id)
                                            .Select(c => new CategoryForDisplayVM(c))
                                                .FirstOrDefaultAsync()
            );        
        }

        public async Task<GenericControllerUpsertVM<Category>> GetUpsertVM(ControllerAction action, int? id)
        {
            return GetUpsertVM(action, action == ControllerAction.Create ? null : await _db.Categories.FindAsync((int)id));                
        }

        public GenericControllerUpsertVM<Category> GetUpsertVM(ControllerAction action, Category category)
        {
            return GetUpsertVM(
                        action,
                        new Dictionary<string, SelectList­>(){},
                        category,
                        category?.Id
            );
        }
    }
}