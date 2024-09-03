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
    public class UserPoliciesController : Controller
    {
        private readonly RMSContext _context;

        public UserPoliciesController(RMSContext context)
        {
            _context = context;
        }

        // GET: UserPolicies
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserPolicies.ToListAsync());
        }

        // GET: UserPolicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPolicy = await _context.UserPolicies
                .FirstOrDefaultAsync(m => m.UserPolicyId == id);
            if (userPolicy == null)
            {
                return NotFound();
            }

            return View(userPolicy);
        }

        // GET: UserPolicies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserPolicyId,UserId,RoleId,DateCreated,CreatedByUserId,DateUpdated,UpdatedByUserId,DateDeleted,DeletedByUserId,DateRestore,RestoredByUserId,IsActive")] UserPolicy userPolicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPolicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userPolicy);
        }

        // GET: UserPolicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPolicy = await _context.UserPolicies.FindAsync(id);
            if (userPolicy == null)
            {
                return NotFound();
            }
            return View(userPolicy);
        }

        // POST: UserPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserPolicyId,UserId,RoleId,DateCreated,CreatedByUserId,DateUpdated,UpdatedByUserId,DateDeleted,DeletedByUserId,DateRestore,RestoredByUserId,IsActive")] UserPolicy userPolicy)
        {
            if (id != userPolicy.UserPolicyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPolicyExists(userPolicy.UserPolicyId))
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
            return View(userPolicy);
        }

        // GET: UserPolicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPolicy = await _context.UserPolicies
                .FirstOrDefaultAsync(m => m.UserPolicyId == id);
            if (userPolicy == null)
            {
                return NotFound();
            }

            return View(userPolicy);
        }

        // POST: UserPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPolicy = await _context.UserPolicies.FindAsync(id);
            if (userPolicy != null)
            {
                _context.UserPolicies.Remove(userPolicy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPolicyExists(int id)
        {
            return _context.UserPolicies.Any(e => e.UserPolicyId == id);
        }
    }
}
