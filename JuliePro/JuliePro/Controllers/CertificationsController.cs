using JuliePro_Core.Interfaces;
using JuliePro_Models;
using JuliePro_Models.ViewModels;
using JuliePro_Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Controllers
{
    public class CertificationsController : Controller
    {
        private readonly ICertificationsService _certificationsSvc;

        public CertificationsController(ICertificationsService certificationsSvc)
        {
            _certificationsSvc = certificationsSvc;
        }

        // GET: Certifications
        public async Task<IActionResult> Index()
        {
            return View(await _certificationsSvc.GetIndexVM());
        }

        // GET: Certifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !(await _certificationsSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _certificationsSvc.GetDisplayVM(ControllerAction.Details, (int)id));
        }

        // GET: Certifications/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {    
            if (id != null && !(await _certificationsSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View(await _certificationsSvc.GetUpsertVM(id == null ? ControllerAction.Create : ControllerAction.Edit, id));
        }

        // POST: Certifications/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GenericControllerUpsertVM<Certification> vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Entity.Id");
            }

            if (!ModelState.IsValid)
            {
                return View(_certificationsSvc.GetUpsertVM(vm.IsCreate ? ControllerAction.Create : ControllerAction.Edit, vm.Entity));
            }

            if (vm.IsCreate)
            {
                await _certificationsSvc.AddAsync(vm.Entity);
            }
            else
            {
                if (!(await _certificationsSvc.ExistsAsync(vm.Entity.Id)))
                {
                    return NotFound();
                }

                await _certificationsSvc.UpdateAsync(vm.Entity);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Certifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !(await _certificationsSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _certificationsSvc.GetDisplayVM(ControllerAction.Delete, (int)id));
        }

        // POST: Certifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _certificationsSvc.DeleteAsync<Certification>(id);

            return RedirectToAction(nameof(Index));
        }
    }
}