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
    public class SpecialitiesController : Controller
    {
        private readonly ISpecialitiesService _specialitiesSvc;

        public SpecialitiesController(ISpecialitiesService specialitiesSvc)
        {
            _specialitiesSvc = specialitiesSvc;
        }

        // GET: Specialities
        public async Task<IActionResult> Index()
        {
            return View(await _specialitiesSvc.GetIndexVM());
        }

        // GET: Specialities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !(await _specialitiesSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _specialitiesSvc.GetDisplayVM(ControllerAction.Details, (int)id));
        }

        // GET: Specialities/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {    
            if (id != null && !(await _specialitiesSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View(await _specialitiesSvc.GetUpsertVM(id == null ? ControllerAction.Create : ControllerAction.Edit, id));
        }

        // POST: Specialities/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GenericControllerUpsertVM<Speciality> vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Entity.Id");
            }

            if (!ModelState.IsValid)
            {
                return View(_specialitiesSvc.GetUpsertVM(vm.IsCreate ? ControllerAction.Create : ControllerAction.Edit, vm.Entity));
            }

            if (vm.IsCreate)
            {
                await _specialitiesSvc.AddAsync(vm.Entity);
            }
            else
            {
                if (!(await _specialitiesSvc.ExistsAsync(vm.Entity.Id)))
                {
                    return NotFound();
                }

                await _specialitiesSvc.UpdateAsync(vm.Entity);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Specialities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !(await _specialitiesSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _specialitiesSvc.GetDisplayVM(ControllerAction.Delete, (int)id));
        }

        // POST: Specialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _specialitiesSvc.DeleteAsync<Speciality>(id);

            return RedirectToAction(nameof(Index));
        }
    }
}