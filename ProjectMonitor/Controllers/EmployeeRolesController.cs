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
    public class EmployeeRolesController : Controller
    {
        private readonly ProjectMonitorContext _context;

        public EmployeeRolesController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: EmployeeRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeRoles.ToListAsync());
        }

        // GET: EmployeeRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRoles = await _context.EmployeeRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeRoles == null)
            {
                return NotFound();
            }

            return View(employeeRoles);
        }

        // GET: EmployeeRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RoleLevel,CanAssignTask")] EmployeeRoles employeeRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeRoles);
        }

        // GET: EmployeeRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRoles = await _context.EmployeeRoles.FindAsync(id);
            if (employeeRoles == null)
            {
                return NotFound();
            }
            return View(employeeRoles);
        }

        // POST: EmployeeRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RoleLevel,CanAssignTask")] EmployeeRoles employeeRoles)
        {
            if (id != employeeRoles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeRolesExists(employeeRoles.Id))
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
            return View(employeeRoles);
        }

        // GET: EmployeeRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRoles = await _context.EmployeeRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeRoles == null)
            {
                return NotFound();
            }

            return View(employeeRoles);
        }

        // POST: EmployeeRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeRoles = await _context.EmployeeRoles.FindAsync(id);
            _context.EmployeeRoles.Remove(employeeRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeRolesExists(int id)
        {
            return _context.EmployeeRoles.Any(e => e.Id == id);
        }
    }
}
