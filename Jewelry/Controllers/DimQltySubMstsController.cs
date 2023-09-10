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
    public class DimQltySubMstsController : Controller
    {
        private readonly JewelryContext _context;

        public DimQltySubMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: DimQltySubMsts
        public async Task<IActionResult> Index()
        {
              return _context.dimQltySubMsts != null ? 
                          View(await _context.dimQltySubMsts.ToListAsync()) :
                          Problem("Entity set 'JewelryContext.dimQltySubMsts'  is null.");
        }

        // GET: DimQltySubMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.dimQltySubMsts == null)
            {
                return NotFound();
            }

            var dimQltySubMst = await _context.dimQltySubMsts
                .FirstOrDefaultAsync(m => m.DimQltySubMstID == id);
            if (dimQltySubMst == null)
            {
                return NotFound();
            }

            return View(dimQltySubMst);
        }

        // GET: DimQltySubMsts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DimQltySubMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DimQltySubMstID,DimQlty")] DimQltySubMst dimQltySubMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dimQltySubMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dimQltySubMst);
        }

        // GET: DimQltySubMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.dimQltySubMsts == null)
            {
                return NotFound();
            }

            var dimQltySubMst = await _context.dimQltySubMsts.FindAsync(id);
            if (dimQltySubMst == null)
            {
                return NotFound();
            }
            return View(dimQltySubMst);
        }

        // POST: DimQltySubMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DimQltySubMstID,DimQlty")] DimQltySubMst dimQltySubMst)
        {
            if (id != dimQltySubMst.DimQltySubMstID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dimQltySubMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DimQltySubMstExists(dimQltySubMst.DimQltySubMstID))
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
            return View(dimQltySubMst);
        }

        // GET: DimQltySubMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.dimQltySubMsts == null)
            {
                return NotFound();
            }

            var dimQltySubMst = await _context.dimQltySubMsts
                .FirstOrDefaultAsync(m => m.DimQltySubMstID == id);
            if (dimQltySubMst == null)
            {
                return NotFound();
            }

            return View(dimQltySubMst);
        }

        // POST: DimQltySubMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.dimQltySubMsts == null)
            {
                return Problem("Entity set 'JewelryContext.dimQltySubMsts'  is null.");
            }
            var dimQltySubMst = await _context.dimQltySubMsts.FindAsync(id);
            if (dimQltySubMst != null)
            {
                _context.dimQltySubMsts.Remove(dimQltySubMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DimQltySubMstExists(int id)
        {
          return (_context.dimQltySubMsts?.Any(e => e.DimQltySubMstID == id)).GetValueOrDefault();
        }
    }
}
