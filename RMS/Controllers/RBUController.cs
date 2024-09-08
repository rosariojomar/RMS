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
    public class RBUController : Controller
    {
        private readonly RMSContext _context;

        public RBUController(RMSContext context)
        {
            _context = context;
        }

        // GET: RBU
        public async Task<IActionResult> Index()
        {
            return View(await _context.RBU.ToListAsync());
        }

        // GET: RBU/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rBU = await _context.RBU
                .FirstOrDefaultAsync(m => m.RBUId == id);
            if (rBU == null)
            {
                return NotFound();
            }

            return View(rBU);
        }

        // GET: RBU/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RBU/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RBUId,Code,Name,Description,DateCreated,CreatedByUserId,DateUpdated,UpdatedByUserId,DateDeleted,DeletedByUserId,DateRestore,RestoredByUserId,IsActive")] RBU rBU)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rBU);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rBU);
        }

        // GET: RBU/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rBU = await _context.RBU.FindAsync(id);
            if (rBU == null)
            {
                return NotFound();
            }
            return View(rBU);
        }

        // POST: RBU/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RBUId,Code,Name,Description,DateCreated,CreatedByUserId,DateUpdated,UpdatedByUserId,DateDeleted,DeletedByUserId,DateRestore,RestoredByUserId,IsActive")] RBU rBU)
        {
            if (id != rBU.RBUId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rBU);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RBUExists(rBU.RBUId))
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
            return View(rBU);
        }

        // GET: RBU/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rBU = await _context.RBU
                .FirstOrDefaultAsync(m => m.RBUId == id);
            if (rBU == null)
            {
                return NotFound();
            }

            return View(rBU);
        }

        // POST: RBU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rBU = await _context.RBU.FindAsync(id);
            if (rBU != null)
            {
                _context.RBU.Remove(rBU);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RBUExists(int id)
        {
            return _context.RBU.Any(e => e.RBUId == id);
        }
    }
}
