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
    public class CertificationsService : BaseService, ICertificationsService
    {
        public CertificationsService(JulieProDbContext db) : base(typeof(Certification), db) { }

        public async override Task<bool> ExistsAsync(int id)
        {
            return await _db.Certifications.AnyAsync(c => c.Id == id);
        }

        public async Task<GenericControllerIndexVM<CertificationForListVM>> GetIndexVM()
        {
            return GetIndexVM(
                        await _db.Certifications
                                
                                    .Select(c => new CertificationForListVM(c))
                                        .ToListAsync()
            );
        }

        public async Task<GenericControllerDisplayVM<CertificationForDisplayVM>> GetDisplayVM(ControllerAction action, int id)
        {
            return GetDisplayVM(
                        action,
                        await _db.Certifications
                                
                                        .Where(c => c.Id == id)
                                            .Select(c => new CertificationForDisplayVM(c))
                                                .FirstOrDefaultAsync()
            );        
        }

        public async Task<GenericControllerUpsertVM<Certification>> GetUpsertVM(ControllerAction action, int? id)
        {
            return GetUpsertVM(action, action == ControllerAction.Create ? null : await _db.Certifications.FindAsync((int)id));                
        }

        public GenericControllerUpsertVM<Certification> GetUpsertVM(ControllerAction action, Certification certification)
        {
            return GetUpsertVM(
                        action,
                        new Dictionary<string, SelectList­>(){},
                        certification,
                        certification?.Id
            );
        }
    }
}