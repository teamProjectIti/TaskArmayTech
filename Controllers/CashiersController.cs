using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArmyTechTask;
using ArmyTechTask.Models;
using ArmyTechTask.interfaces;

namespace ArmyTechTask.Controllers
{
    public class CashiersController : Controller
    {
        private readonly IRepositeryCashier repositeryCashier;
        private readonly IRepositeryBranch repositeryBranch;

        public CashiersController(IRepositeryCashier repositeryCashier, IRepositeryBranch repositeryBranch)
        {
            this.repositeryCashier = repositeryCashier;
            this.repositeryBranch = repositeryBranch;
        }

        // GET: Cashiers
        public async Task<IActionResult> Index()
        {
            var armyTechTaskContext = await repositeryCashier.GetAll();
            return View(armyTechTaskContext);
        }

        // GET: Cashiers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashier = await repositeryCashier.GetById(id);
            if (cashier == null)
            {
                return NotFound();
            }

            return View(cashier);
        }

        // GET: Cashiers/Create
        public async Task<ActionResult> Create()
        {
            ViewData["BranchId"] = new SelectList(await repositeryBranch.GetAll(), "Id", "BranchName");
            return View();
        }

        // POST: Cashiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CashierName,BranchId")] Cashier cashier)
        {
            if (ModelState.IsValid)
            {
                await repositeryCashier.Add(cashier);
                repositeryCashier.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(await repositeryBranch.GetAll(), "Id", "BranchName", cashier.BranchId);
            return View(cashier);
        }

        // GET: Cashiers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashier = await repositeryCashier.GetById(id);

            if (cashier == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(await repositeryBranch.GetAll(), "Id", "BranchName", cashier.BranchId);
            return View(cashier);
        }

        // POST: Cashiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CashierName,BranchId")] Cashier cashier)
        {
            if (id != cashier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repositeryCashier.update(cashier);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["BranchId"] = new SelectList(await repositeryBranch.GetAll(), "Id", "BranchName", cashier.BranchId);
            return View(cashier);
        }

        // GET: Cashiers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashier = await repositeryCashier.GetById(id);
            if (cashier == null)
            {
                return NotFound();
            }

            return View(cashier);
        }

        // POST: Cashiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashier = await repositeryCashier.GetById(id);
            repositeryCashier.Delete(cashier);
            repositeryCashier.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
