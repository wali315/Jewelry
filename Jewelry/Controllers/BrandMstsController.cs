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
    public class BrandMstsController : Controller
    {
        private readonly JewelryContext _context;

        public BrandMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: BrandMsts
        public async Task<IActionResult> Index()
        {
              return _context.brandMsts != null ? 
                          View(await _context.brandMsts.ToListAsync()) :
                          Problem("Entity set 'JewelryContext.brandMsts'  is null.");
        }

        // GET: BrandMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.brandMsts == null)
            {
                return NotFound();
            }

            var brandMst = await _context.brandMsts
                .FirstOrDefaultAsync(m => m.BrandMstID == id);
            if (brandMst == null)
            {
                return NotFound();
            }

            return View(brandMst);
        }

        // GET: BrandMsts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrandMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandMstID,Brand_Type")] BrandMst brandMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brandMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandMst);
        }

        // GET: BrandMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.brandMsts == null)
            {
                return NotFound();
            }

            var brandMst = await _context.brandMsts.FindAsync(id);
            if (brandMst == null)
            {
                return NotFound();
            }
            return View(brandMst);
        }

        // POST: BrandMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandMstID,Brand_Type")] BrandMst brandMst)
        {
            if (id != brandMst.BrandMstID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brandMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandMstExists(brandMst.BrandMstID))
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
            return View(brandMst);
        }

        // GET: BrandMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.brandMsts == null)
            {
                return NotFound();
            }

            var brandMst = await _context.brandMsts
                .FirstOrDefaultAsync(m => m.BrandMstID == id);
            if (brandMst == null)
            {
                return NotFound();
            }

            return View(brandMst);
        }

        // POST: BrandMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.brandMsts == null)
            {
                return Problem("Entity set 'JewelryContext.brandMsts'  is null.");
            }
            var brandMst = await _context.brandMsts.FindAsync(id);
            if (brandMst != null)
            {
                _context.brandMsts.Remove(brandMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandMstExists(int id)
        {
          return (_context.brandMsts?.Any(e => e.BrandMstID == id)).GetValueOrDefault();
        }
    }
}
