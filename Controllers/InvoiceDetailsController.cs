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
    public class InvoiceDetailsController : Controller
    {
        private readonly IRepositeryInvoiceDetail repositeryInvoiceDetail;
        private readonly IRepositeryInvoiceHeader repositeryInvoiceHeader;

        public InvoiceDetailsController(IRepositeryInvoiceDetail repositeryInvoiceDetail, IRepositeryInvoiceHeader repositeryInvoiceHeader)
        {
            this.repositeryInvoiceDetail = repositeryInvoiceDetail;
            this.repositeryInvoiceHeader = repositeryInvoiceHeader;
        }

        // GET: InvoiceDetails
        public async Task<IActionResult> Index()
        {
            var armyTechTaskContext =  await repositeryInvoiceDetail.GetAll();
            return View(armyTechTaskContext);
        }

        // GET: InvoiceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDetail = await repositeryInvoiceDetail.GetById(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Create
        public async Task<ActionResult> Create()
        {
            ViewData["InvoiceHeaderId"] = new SelectList(await repositeryInvoiceHeader.GetAll(), "Id", "CustomerName");
            return View();
        }

        // POST: InvoiceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceDetail invoiceDetail)
        {
            if (ModelState.IsValid)
            {
               await repositeryInvoiceDetail.Add(invoiceDetail);
                repositeryInvoiceDetail.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceHeaderId"] = new SelectList(await repositeryInvoiceHeader.GetAll(), "Id", "CustomerName", invoiceDetail.InvoiceHeaderId);
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDetail = await repositeryInvoiceDetail.GetById(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }
            ViewData["InvoiceHeaderId"] = new SelectList(await repositeryInvoiceHeader.GetAll(), "Id", "CustomerName", invoiceDetail.InvoiceHeaderId);
            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,InvoiceHeaderId,ItemName,ItemCount,ItemPrice")] InvoiceDetail invoiceDetail)
        {
            if (id != invoiceDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repositeryInvoiceDetail.update(invoiceDetail);
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["InvoiceHeaderId"] = new SelectList(await repositeryInvoiceHeader.GetAll(), "Id", "CustomerName", invoiceDetail.InvoiceHeaderId);
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceDetail = await repositeryInvoiceDetail.GetById(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceDetail = await repositeryInvoiceDetail.GetById(id);
            repositeryInvoiceDetail.Delete(invoiceDetail);
            repositeryInvoiceDetail.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
