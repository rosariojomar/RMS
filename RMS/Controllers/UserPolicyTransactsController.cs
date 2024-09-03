using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RMS_DAL.Models;
using RMS_DAL.RMSDBContext;

namespace RMS.Controllers
{
    public class UserPolicyTransactsController : Controller
    {
        private readonly RMSContext _context;

        public UserPolicyTransactsController(RMSContext context)
        {
            _context = context;
        }

        // GET: UserPolicyTransacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserPolicyTransactions.ToListAsync());
        }

        // GET: UserPolicyTransacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPolicyTransact = await _context.UserPolicyTransactions
                .FirstOrDefaultAsync(m => m.UserPolicyTransactId == id);
            if (userPolicyTransact == null)
            {
                return NotFound();
            }

            return View(userPolicyTransact);
        }

        // GET: UserPolicyTransacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPolicyTransacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserPolicyTransactId,UserPolicyId,ModuleId,CreateAccess,UpdateAccess,DeleteAccess,ReadAccess,RestoreAccess,DateCreated,CreatedByUserId,DateUpdated,UpdatedByUserId,DateDeleted,DeletedByUserId,DateRestore,RestoredByUserId,IsActive")] UserPolicyTransact userPolicyTransact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPolicyTransact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userPolicyTransact);
        }

        // GET: UserPolicyTransacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPolicyTransact = await _context.UserPolicyTransactions.FindAsync(id);
            if (userPolicyTransact == null)
            {
                return NotFound();
            }
            return View(userPolicyTransact);
        }

        // POST: UserPolicyTransacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserPolicyTransactId,UserPolicyId,ModuleId,CreateAccess,UpdateAccess,DeleteAccess,ReadAccess,RestoreAccess,DateCreated,CreatedByUserId,DateUpdated,UpdatedByUserId,DateDeleted,DeletedByUserId,DateRestore,RestoredByUserId,IsActive")] UserPolicyTransact userPolicyTransact)
        {
            if (id != userPolicyTransact.UserPolicyTransactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPolicyTransact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPolicyTransactExists(userPolicyTransact.UserPolicyTransactId))
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
            return View(userPolicyTransact);
        }

        // GET: UserPolicyTransacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPolicyTransact = await _context.UserPolicyTransactions
                .FirstOrDefaultAsync(m => m.UserPolicyTransactId == id);
            if (userPolicyTransact == null)
            {
                return NotFound();
            }

            return View(userPolicyTransact);
        }

        // POST: UserPolicyTransacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPolicyTransact = await _context.UserPolicyTransactions.FindAsync(id);
            if (userPolicyTransact != null)
            {
                _context.UserPolicyTransactions.Remove(userPolicyTransact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPolicyTransactExists(int id)
        {
            return _context.UserPolicyTransactions.Any(e => e.UserPolicyTransactId == id);
        }
    }
}
