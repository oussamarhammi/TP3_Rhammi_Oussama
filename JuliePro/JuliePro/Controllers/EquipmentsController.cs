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
    public class EquipmentsController : Controller
    {
        private readonly IEquipmentsService _equipmentsSvc;

        public EquipmentsController(IEquipmentsService equipmentsSvc)
        {
            _equipmentsSvc = equipmentsSvc;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            return View(await _equipmentsSvc.GetIndexVM());
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !(await _equipmentsSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _equipmentsSvc.GetDisplayVM(ControllerAction.Details, (int)id));
        }

        // GET: Equipments/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {    
            if (id != null && !(await _equipmentsSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View(await _equipmentsSvc.GetUpsertVM(id == null ? ControllerAction.Create : ControllerAction.Edit, id));
        }

        // POST: Equipments/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GenericControllerUpsertVM<Equipment> vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Entity.Id");
            }

            if (!ModelState.IsValid)
            {
                return View(_equipmentsSvc.GetUpsertVM(vm.IsCreate ? ControllerAction.Create : ControllerAction.Edit, vm.Entity));
            }

            if (vm.IsCreate)
            {
                await _equipmentsSvc.AddAsync(vm.Entity);
            }
            else
            {
                if (!(await _equipmentsSvc.ExistsAsync(vm.Entity.Id)))
                {
                    return NotFound();
                }

                await _equipmentsSvc.UpdateAsync(vm.Entity);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !(await _equipmentsSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _equipmentsSvc.GetDisplayVM(ControllerAction.Delete, (int)id));
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _equipmentsSvc.DeleteAsync<Equipment>(id);

            return RedirectToAction(nameof(Index));
        }
    }
}