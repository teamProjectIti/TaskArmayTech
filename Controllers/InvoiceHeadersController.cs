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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ArmyTechTask.Controllers
{
    [Authorize]
    public class InvoiceHeadersController : Controller
    {
        private readonly IRepositeryInvoiceHeader repositery;
        private readonly IRepositeryCashier repositeryCashier;
        private readonly IRepositeryBranch repositeryBranch;

        public InvoiceHeadersController(IRepositeryInvoiceHeader repositery, IRepositeryCashier repositeryCashier, IRepositeryBranch repositeryBranch)
        {
            this.repositery = repositery;
            this.repositeryCashier = repositeryCashier;
            this.repositeryBranch = repositeryBranch;
        }

        // GET: InvoiceHeaders
        public async Task<IActionResult> Index()
        {
            var armyTechTaskContext = await repositery.GetAll();
            return View(armyTechTaskContext);
        }

        // GET: InvoiceHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceHeader = await repositery.GetById(id);
            if (invoiceHeader == null)
            {
                return NotFound();
            }

            return View(invoiceHeader);
        }

        // GET: InvoiceHeaders/Create
        public async Task<ActionResult> Create()
        {
            ViewData["BranchId"] = new SelectList(await repositeryBranch.GetAll(), "Id", "BranchName");
            ViewData["CashierId"] = new SelectList(await repositeryCashier.GetAll(), "Id", "CashierName");
            return View();
        }

        // POST: InvoiceHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( InvoiceHeader invoiceHeader)
        {
            if (ModelState.IsValid)
            {
              
                invoiceHeader.Invoicedate = DateTime.UtcNow;
                await repositery.Add(invoiceHeader);
                  repositery.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(await repositery.GetAll(), "Id", "BranchName", invoiceHeader.BranchId);
            ViewData["CashierId"] = new SelectList(await repositeryCashier.GetAll(), "Id", "CashierName", invoiceHeader.CashierId);
            return View(invoiceHeader);
        }

        // GET: InvoiceHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceHeader = await repositery.GetById(id);
            if (invoiceHeader == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(await repositeryBranch.GetAll(), "Id", "BranchName", invoiceHeader.BranchId);
            ViewData["CashierId"] = new SelectList(await repositeryCashier.GetAll(), "Id", "CashierName", invoiceHeader.CashierId);
            return View(invoiceHeader);
        }

        // POST: InvoiceHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CustomerName,Invoicedate,CashierId,BranchId")] InvoiceHeader invoiceHeader)
        {
            if (id != invoiceHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repositery.update(invoiceHeader);
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["BranchId"] = new SelectList(await repositeryBranch.GetAll(), "Id", "BranchName", invoiceHeader.BranchId);
            ViewData["CashierId"] = new SelectList(await repositeryCashier.GetAll(), "Id", "CashierName", invoiceHeader.CashierId);
            return View(invoiceHeader);
        }

        // GET: InvoiceHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceHeader = await repositery.GetById(id);
                if (invoiceHeader == null)
            {
                return NotFound();
            }

            return View(invoiceHeader);
        }

        // POST: InvoiceHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceHeader = await repositery.GetById(id);
            repositery.Delete(invoiceHeader);
            repositery.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
       
    }
}
