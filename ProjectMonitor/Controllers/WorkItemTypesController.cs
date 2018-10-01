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
    public class WorkItemTypesController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public WorkItemTypesController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: WorkItemTypes
        public async Task<IActionResult> Index()
        {
            var projectMonitorContext = _context.WorkItemType.Include(w => w.WorkItems);
            return View(await projectMonitorContext.ToListAsync());
        }

        // GET: WorkItemTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemType = await _context.WorkItemType
                .Include(w => w.WorkItems)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemType == null)
            {
                return NotFound();
            }

            return View(workItemType);
        }

        // GET: WorkItemTypes/Create
        public IActionResult Create()
        {
            ViewData["WorkItemsId"] = new SelectList(_context.WorkItems, "Id", "Id");
            return View();
        }

        // POST: WorkItemTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlimTarihi,AlinanKisi,TeslimAlan,Marka,TeslimAlinanAdet,WorkItemsId")] WorkItemType workItemType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workItemType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkItemsId"] = new SelectList(_context.WorkItems, "Id", "Id", workItemType.WorkItemsId);
            return View(workItemType);
        }

        // GET: WorkItemTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemType = await _context.WorkItemType.FindAsync(id);
            if (workItemType == null)
            {
                return NotFound();
            }
            ViewData["WorkItemsId"] = new SelectList(_context.WorkItems, "Id", "Id", workItemType.WorkItemsId);
            return View(workItemType);
        }

        // POST: WorkItemTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlimTarihi,AlinanKisi,TeslimAlan,Marka,TeslimAlinanAdet,WorkItemsId")] WorkItemType workItemType)
        {
            if (id != workItemType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workItemType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkItemTypeExists(workItemType.Id))
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
            ViewData["WorkItemsId"] = new SelectList(_context.WorkItems, "Id", "Id", workItemType.WorkItemsId);
            return View(workItemType);
        }

        // GET: WorkItemTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workItemType = await _context.WorkItemType
                .Include(w => w.WorkItems)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workItemType == null)
            {
                return NotFound();
            }

            return View(workItemType);
        }

        // POST: WorkItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workItemType = await _context.WorkItemType.FindAsync(id);
            _context.WorkItemType.Remove(workItemType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkItemTypeExists(int id)
        {
            return _context.WorkItemType.Any(e => e.Id == id);
        }
    }
}
