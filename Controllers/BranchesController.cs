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
    public class BranchesController : Controller
    {
        private readonly IRepositeryBranch repositeryBranch;
        private readonly IRepositeryCity repositeryCity;

        public BranchesController(IRepositeryBranch repositeryBranch, IRepositeryCity repositeryCity)
        {
            this.repositeryBranch = repositeryBranch;
            this.repositeryCity = repositeryCity;
        }

        // GET: Branches
        public async Task<IActionResult> Index()
        {
            var armyTechTaskContext = await repositeryBranch.GetAll();
            return View(armyTechTaskContext);
        }

        // GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await repositeryBranch.GetById(id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // GET: Branches/Create
        public async Task<ActionResult> Create()
        {
            ViewData["CityId"] = new SelectList(await repositeryCity.GetAll(), "Id", "CityName");
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BranchName,CityId")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                await repositeryBranch.Add(branch);
                  repositeryBranch.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(await repositeryCity.GetAll(), "Id", "CityName", branch.CityId);
            return View(branch);
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await repositeryBranch.GetById(id);
            if (branch == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(await repositeryCity.GetAll(), "Id", "CityName", branch.CityId);
            return View(branch);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BranchName,CityId")] Branch branch)
        {
            if (id != branch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repositeryBranch.update(branch);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CityId"] = new SelectList(await repositeryCity.GetAll(), "Id", "CityName", branch.CityId);
            return View(branch);
        }

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await repositeryBranch.GetById(id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await repositeryBranch.GetById(id);
            repositeryBranch.Delete(branch);
            repositeryBranch.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
