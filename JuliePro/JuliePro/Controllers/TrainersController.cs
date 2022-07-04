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
    public class TrainersController : Controller
    {
        private readonly ITrainersService _trainersSvc;

        public TrainersController(ITrainersService trainersSvc)
        {
            _trainersSvc = trainersSvc;
        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {
            return View(await _trainersSvc.GetIndexVM());
        }



        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !(await _trainersSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _trainersSvc.GetDisplayVM(ControllerAction.Details, (int)id));
        }

        // GET: Trainers/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {    
            if (id != null && !(await _trainersSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View(await _trainersSvc.GetUpsertVM(id == null ? ControllerAction.Create : ControllerAction.Edit, id));
        }

        // POST: Trainers/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GenericControllerUpsertVM<Trainer> vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Entity.Id");
            }

            if (!ModelState.IsValid)
            {
                return View(_trainersSvc.GetUpsertVM(vm.IsCreate ? ControllerAction.Create : ControllerAction.Edit, vm.Entity));
            }

            if (vm.IsCreate)
            {
                await _trainersSvc.AddAsync(vm.Entity);
            }
            else
            {
                if (!(await _trainersSvc.ExistsAsync(vm.Entity.Id)))
                {
                    return NotFound();
                }

                await _trainersSvc.UpdateAsync(vm.Entity);
            }



            return RedirectToAction(nameof(Index));
        }

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !(await _trainersSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _trainersSvc.GetDisplayVM(ControllerAction.Delete, (int)id));
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _trainersSvc.DeleteAsync<Trainer>(id);

            return RedirectToAction(nameof(Index));
        }
    }
}