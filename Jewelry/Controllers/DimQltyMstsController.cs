using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jewelry.Data;
using Jewelry.Models;

namespace Jewelry.Controllers
{
    public class DimQltyMstsController : Controller
    {
        private readonly JewelryContext _context;

        public DimQltyMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: DimQltyMsts
        public async Task<IActionResult> Index()
        {
              return _context.dimQltyMsts != null ? 
                          View(await _context.dimQltyMsts.ToListAsync()) :
                          Problem("Entity set 'JewelryContext.dimQltyMsts'  is null.");
        }

        // GET: DimQltyMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dimQltyMsts == null)
            {
                return NotFound();
            }

            var dimQltyMst = await _context.dimQltyMsts
                .FirstOrDefaultAsync(m => m.DimQltyMstID == id);
            if (dimQltyMst == null)
            {
                return NotFound();
            }

            return View(dimQltyMst);
        }

        // GET: DimQltyMsts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DimQltyMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DimQltyMstID,DimQlty")] DimQltyMst dimQltyMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dimQltyMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dimQltyMst);
        }

        // GET: DimQltyMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dimQltyMsts == null)
            {
                return NotFound();
            }

            var dimQltyMst = await _context.dimQltyMsts.FindAsync(id);
            if (dimQltyMst == null)
            {
                return NotFound();
            }
            return View(dimQltyMst);
        }

        // POST: DimQltyMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DimQltyMstID,DimQlty")] DimQltyMst dimQltyMst)
        {
            if (id != dimQltyMst.DimQltyMstID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dimQltyMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DimQltyMstExists(dimQltyMst.DimQltyMstID))
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
            return View(dimQltyMst);
        }

        // GET: DimQltyMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dimQltyMsts == null)
            {
                return NotFound();
            }

            var dimQltyMst = await _context.dimQltyMsts
                .FirstOrDefaultAsync(m => m.DimQltyMstID == id);
            if (dimQltyMst == null)
            {
                return NotFound();
            }

            return View(dimQltyMst);
        }

        // POST: DimQltyMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dimQltyMsts == null)
            {
                return Problem("Entity set 'JewelryContext.dimQltyMsts'  is null.");
            }
            var dimQltyMst = await _context.dimQltyMsts.FindAsync(id);
            if (dimQltyMst != null)
            {
                _context.dimQltyMsts.Remove(dimQltyMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DimQltyMstExists(int id)
        {
          return (_context.dimQltyMsts?.Any(e => e.DimQltyMstID == id)).GetValueOrDefault();
        }
    }
}
