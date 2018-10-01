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
    public class WorkItemMonitorsController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public WorkItemMonitorsController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: WorkItemMonitors
        public async Task<IActionResult> Index()
        {
            var projectMonitorContext = _context.WorkItemMonitor.Include(w => w.WorkItemType);
            return View(await projectMonitorContext.ToListAsync());
        }

        // GET: WorkItemMonitors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemMonitor = await _context.WorkItemMonitor
                .Include(w => w.WorkItemType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemMonitor == null)
            {
                return NotFound();
            }

            return View(workItemMonitor);
        }

        // GET: WorkItemMonitors/Create
        public IActionResult Create()
        {
            ViewData["WorkItemTypeId"] = new SelectList(_context.WorkItemType, "Id", "Id");
            return View();
        }

        // POST: WorkItemMonitors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkItemTypeId,WorkItemUsed,WorkItemDelivered,WorkItemRemaining")] WorkItemMonitor workItemMonitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workItemMonitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkItemTypeId"] = new SelectList(_context.WorkItemType, "Id", "Id", workItemMonitor.WorkItemTypeId);
            return View(workItemMonitor);
        }

        // GET: WorkItemMonitors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemMonitor = await _context.WorkItemMonitor.FindAsync(id);
            if (workItemMonitor == null)
            {
                return NotFound();
            }
            ViewData["WorkItemTypeId"] = new SelectList(_context.WorkItemType, "Id", "Id", workItemMonitor.WorkItemTypeId);
            return View(workItemMonitor);
        }

        // POST: WorkItemMonitors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkItemTypeId,WorkItemUsed,WorkItemDelivered,WorkItemRemaining")] WorkItemMonitor workItemMonitor)
        {
            if (id != workItemMonitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workItemMonitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkItemMonitorExists(workItemMonitor.Id))
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
            ViewData["WorkItemTypeId"] = new SelectList(_context.WorkItemType, "Id", "Id", workItemMonitor.WorkItemTypeId);
            return View(workItemMonitor);
        }

        // GET: WorkItemMonitors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemMonitor = await _context.WorkItemMonitor
                .Include(w => w.WorkItemType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemMonitor == null)
            {
                return NotFound();
            }

            return View(workItemMonitor);
        }

        // POST: WorkItemMonitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workItemMonitor = await _context.WorkItemMonitor.FindAsync(id);
            _context.WorkItemMonitor.Remove(workItemMonitor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkItemMonitorExists(int id)
        {
            return _context.WorkItemMonitor.Any(e => e.Id == id);
        }
    }
}
