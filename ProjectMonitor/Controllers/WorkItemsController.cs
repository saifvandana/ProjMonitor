using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMonitor.Models;

namespace ProjectMonitor.Controllers
{
    public class WorkItemsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public WorkItemsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: WorkItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkItems.ToListAsync());
        }

        // GET: WorkItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItems = await _context.WorkItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItems == null)
            {
                return NotFound();
            }

            return View(workItems);
        }

        // GET: WorkItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,Birimi,Adedi")] WorkItems workItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workItems);
        }

        // GET: WorkItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItems = await _context.WorkItems.FindAsync(id);
            if (workItems == null)
            {
                return NotFound();
            }
            return View(workItems);
        }

        // POST: WorkItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,Birimi,Adedi")] WorkItems workItems)
        {
            if (id != workItems.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkItemsExists(workItems.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workItems);
        }

        // GET: WorkItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItems = await _context.WorkItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItems == null)
            {
                return NotFound();
            }

            return View(workItems);
        }

        // POST: WorkItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workItems = await _context.WorkItems.FindAsync(id);
            _context.WorkItems.Remove(workItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkItemsExists(int id)
        {
            return _context.WorkItems.Any(e => e.Id == id);
        }
    }
}
