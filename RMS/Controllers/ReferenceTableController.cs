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
    public class ReferenceTableController : Controller
    {
        private readonly RMSContext _context;

        public ReferenceTableController(RMSContext context)
        {
            _context = context;
        }

        // GET: ReferenceTable
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReferenceTables.ToListAsync());
        }

        // GET: ReferenceTable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceTable = await _context.ReferenceTables
                .FirstOrDefaultAsync(m => m.ReferenceTableId == id);
            if (referenceTable == null)
            {
                return NotFound();
            }

            return View(referenceTable);
        }

        // GET: ReferenceTable/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReferenceTable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferenceTableId,Code,Name,Description,Classification,DateCreated,CreatedByUserId,DateUpdated,UpdatedByUserId,DateDeleted,DeletedByUserId,DateRestore,RestoredByUserId,IsActive")] ReferenceTable referenceTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referenceTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(referenceTable);
        }

        // GET: ReferenceTable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceTable = await _context.ReferenceTables.FindAsync(id);
            if (referenceTable == null)
            {
                return NotFound();
            }
            return View(referenceTable);
        }

        // POST: ReferenceTable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReferenceTableId,Code,Name,Description,Classification,DateCreated,CreatedByUserId,DateUpdated,UpdatedByUserId,DateDeleted,DeletedByUserId,DateRestore,RestoredByUserId,IsActive")] ReferenceTable referenceTable)
        {
            if (id != referenceTable.ReferenceTableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referenceTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceTableExists(referenceTable.ReferenceTableId))
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
            return View(referenceTable);
        }

        // GET: ReferenceTable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceTable = await _context.ReferenceTables
                .FirstOrDefaultAsync(m => m.ReferenceTableId == id);
            if (referenceTable == null)
            {
                return NotFound();
            }

            return View(referenceTable);
        }

        // POST: ReferenceTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referenceTable = await _context.ReferenceTables.FindAsync(id);
            if (referenceTable != null)
            {
                _context.ReferenceTables.Remove(referenceTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenceTableExists(int id)
        {
            return _context.ReferenceTables.Any(e => e.ReferenceTableId == id);
        }
    }
}
