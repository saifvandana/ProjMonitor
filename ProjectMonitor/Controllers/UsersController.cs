using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMonitor.Models;
using ProjectMonitor.ViewModels;
using SimpleCrypto;

namespace ProjectMonitor.Controllers
{
    public class UsersController : Controller
    {
        private readonly ProjectMonitorContext _context;


		public UsersController(ProjectMonitorContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

		public ActionResult Create()
		{
			IEnumerable<Role> roleList = _context.Roles;

			UserViewModel userVM = new UserViewModel()
			{
				Role = new SelectList(roleList, "Id", "Name")
			};
			return View(userVM);
		}

		[HttpPost]
		public async Task<ActionResult> CreateAsync(UserViewModel userVM)
		{
			User user = new User
			{
				Id = userVM.Id,
				IdentityNumber = userVM.IdentityNumber,
				Name = userVM.Name,
				LastName = userVM.LastName,
				Email = userVM.Email,
				IsActive = userVM.IsActive,
				Phone = userVM.Phone,
				RoleId = userVM.RoleId,
			};

			ICryptoService cryptoService = new PBKDF2();
			//New User
			string password = userVM.Password;
			//save this salt to the database
			string passwordHashedSalt = cryptoService.GenerateSalt();
			//save this hash to the database
			string passwordHashed = cryptoService.Compute(password);

			user.PasswordHashedSalt = passwordHashedSalt;
			user.PasswordHashed = passwordHashed;

			if (ModelState.IsValid)
			{
				_context.Add(user);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(userVM);
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Index");
			}
			
			User user =  _context.FindAsync(id);
			if (user == null)
			{
				return RedirectToAction("Index");
			}

			IEnumerable<Role> roleList = _context.Roles;

			UserViewModel userVM = new UserViewModel()
			{
				Id = user.Id,
				IdentityNumber = user.IdentityNumber,
				Name = user.Name,
				LastName = user.LastName,
				Email = user.Email,
				IsActive = user.IsActive,
				Phone = user.Phone,
				RoleId = user.RoleId,
				Role = new SelectList(roleList, "Id", "Name"),
			};
			return View(userVM);
		}

		[HttpPost]
		public ActionResult Edit(UserViewModel userVM)
		{
			User user = new User
			{
				Id = userVM.Id,
				IdentityNumber = userVM.IdentityNumber,
				Name = userVM.Name,
				LastName = userVM.LastName,
				Email = userVM.Email,
				IsActive = userVM.IsActive,
				Phone = userVM.Phone,
				RoleId = userVM.RoleId,
			};

			ICryptoService cryptoService = new PBKDF2();
			//New User
			string password = userVM.Password;
			//save this salt to the database
			string passwordHashedSalt = cryptoService.GenerateSalt();
			//save this hash to the database
			string passwordHashed = cryptoService.Compute(password);

			user.PasswordHashedSalt = passwordHashedSalt;
			user.PasswordHashed = passwordHashed;

			if (ModelState.IsValid)
			{
				_context.Add(user);
				return RedirectToAction("Index");
			}
			return View(userVM);
		}



		
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
