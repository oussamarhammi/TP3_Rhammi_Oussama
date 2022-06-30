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
    public class ObjectivesController : Controller
    {
        private readonly IObjectivesService _objectivesSvc;

        public ObjectivesController(IObjectivesService objectivesSvc)
        {
            _objectivesSvc = objectivesSvc;
        }

        // GET: Objectives
        public async Task<IActionResult> Index()
        {
            return View(await _objectivesSvc.GetIndexVM());
        }

        // GET: Objectives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !(await _objectivesSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _objectivesSvc.GetDisplayVM(ControllerAction.Details, (int)id));
        }

        // GET: Objectives/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {    
            if (id != null && !(await _objectivesSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View(await _objectivesSvc.GetUpsertVM(id == null ? ControllerAction.Create : ControllerAction.Edit, id));
        }

        // POST: Objectives/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GenericControllerUpsertVM<Objective> vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Entity.Id");
            }

            if (!ModelState.IsValid)
            {
                return View(_objectivesSvc.GetUpsertVM(vm.IsCreate ? ControllerAction.Create : ControllerAction.Edit, vm.Entity));
            }

            if (vm.IsCreate)
            {
                await _objectivesSvc.AddAsync(vm.Entity);
            }
            else
            {
                if (!(await _objectivesSvc.ExistsAsync(vm.Entity.Id)))
                {
                    return NotFound();
                }

                await _objectivesSvc.UpdateAsync(vm.Entity);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Objectives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !(await _objectivesSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _objectivesSvc.GetDisplayVM(ControllerAction.Delete, (int)id));
        }

        // POST: Objectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _objectivesSvc.DeleteAsync<Objective>(id);

            return RedirectToAction(nameof(Index));
        }
    }
}