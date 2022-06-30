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
    public class CustomersController : Controller
    {
        private readonly ICustomersService _customersSvc;

        public CustomersController(ICustomersService customersSvc)
        {
            _customersSvc = customersSvc;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _customersSvc.GetIndexVM());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !(await _customersSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _customersSvc.GetDisplayVM(ControllerAction.Details, (int)id));
        }

        // GET: Customers/Upsert/5
        public async Task<IActionResult> Upsert(int? id)
        {    
            if (id != null && !(await _customersSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View(await _customersSvc.GetUpsertVM(id == null ? ControllerAction.Create : ControllerAction.Edit, id));
        }

        // POST: Customers/Upsert
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(GenericControllerUpsertVM<Customer> vm)
        {
            if(vm.IsCreate)
            {
                ModelState.Remove("Entity.Id");
            }

            if (!ModelState.IsValid)
            {
                return View(_customersSvc.GetUpsertVM(vm.IsCreate ? ControllerAction.Create : ControllerAction.Edit, vm.Entity));
            }

            if (vm.IsCreate)
            {
                await _customersSvc.AddAsync(vm.Entity);
            }
            else
            {
                if (!(await _customersSvc.ExistsAsync(vm.Entity.Id)))
                {
                    return NotFound();
                }

                await _customersSvc.UpdateAsync(vm.Entity);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !(await _customersSvc.ExistsAsync((int)id)))
            {
                return NotFound();
            }

            return View("Display", await _customersSvc.GetDisplayVM(ControllerAction.Delete, (int)id));
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customersSvc.DeleteAsync<Customer>(id);

            return RedirectToAction(nameof(Index));
        }
    }
}