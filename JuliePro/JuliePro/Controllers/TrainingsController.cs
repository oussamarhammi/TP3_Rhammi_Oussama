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
    public class TrainingsController : Controller
    {
        private readonly ITrainingsService _trainingsSvc;

        public TrainingsController(ITrainingsService trainingsSvc)
        {
            _trainingsSvc = trainingsSvc;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            return View(await _trainingsSvc.GetIndexVM());
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !(await _trainingsSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _trainingsSvc.GetDisplayVM(ControllerAction.Details, (int)id));
        }

        // GET: Trainings/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {    
            if (id != null && !(await _trainingsSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View(await _trainingsSvc.GetUpsertVM(id == null ? ControllerAction.Create : ControllerAction.Edit, id));
        }

        // POST: Trainings/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GenericControllerUpsertVM<Training> vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Entity.Id");
            }

            if (!ModelState.IsValid)
            {
                return View(_trainingsSvc.GetUpsertVM(vm.IsCreate ? ControllerAction.Create : ControllerAction.Edit, vm.Entity));
            }

            if (vm.IsCreate)
            {
                await _trainingsSvc.AddAsync(vm.Entity);
            }
            else
            {
                if (!(await _trainingsSvc.ExistsAsync(vm.Entity.Id)))
                {
                    return NotFound();
                }

                await _trainingsSvc.UpdateAsync(vm.Entity);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !(await _trainingsSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _trainingsSvc.GetDisplayVM(ControllerAction.Delete, (int)id));
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _trainingsSvc.DeleteAsync<Training>(id);

            return RedirectToAction(nameof(Index));
        }
    }
}