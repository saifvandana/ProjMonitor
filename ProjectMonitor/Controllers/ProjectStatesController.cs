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
    public class ProjectStatesController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public ProjectStatesController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: ProjectStates
        public async Task<IActionResult> Index()
        {
            var projectMonitorContext = _context.ProjectState.Include(p => p.SorumluKisi);
            return View(await projectMonitorContext.ToListAsync());
        }

        // GET: ProjectStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectState = await _context.ProjectState
                .Include(p => p.SorumluKisi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectState == null)
            {
                return NotFound();
            }

            return View(projectState);
        }

        // GET: ProjectStates/Create
        public IActionResult Create()
        {
            ViewData["SorumluKisiId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: ProjectStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectRoles,SorumluKisiId,YardimciKisiler,Status,Tamamlanan,BaslangicTarihi,BitisTarihi,KalanSure,CalismaSure")] ProjectState projectState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SorumluKisiId"] = new SelectList(_context.Employees, "Id", "Id", projectState.SorumluKisiId);
            return View(projectState);
        }

        // GET: ProjectStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectState = await _context.ProjectState.FindAsync(id);
            if (projectState == null)
            {
                return NotFound();
            }
            ViewData["SorumluKisiId"] = new SelectList(_context.Employees, "Id", "Id", projectState.SorumluKisiId);
            return View(projectState);
        }

        // POST: ProjectStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectRoles,SorumluKisiId,YardimciKisiler,Status,Tamamlanan,BaslangicTarihi,BitisTarihi,KalanSure,CalismaSure")] ProjectState projectState)
        {
            if (id != projectState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectStateExists(projectState.Id))
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
            ViewData["SorumluKisiId"] = new SelectList(_context.Employees, "Id", "Id", projectState.SorumluKisiId);
            return View(projectState);
        }

        // GET: ProjectStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectState = await _context.ProjectState
                .Include(p => p.SorumluKisi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectState == null)
            {
                return NotFound();
            }

            return View(projectState);
        }

        // POST: ProjectStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectState = await _context.ProjectState.FindAsync(id);
            _context.ProjectState.Remove(projectState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectStateExists(int id)
        {
            return _context.ProjectState.Any(e => e.Id == id);
        }
    }
}
