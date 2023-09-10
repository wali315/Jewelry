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
    public class GoldKrtMstsController : Controller
    {
        private readonly JewelryContext _context;

        public GoldKrtMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: GoldKrtMsts
        public async Task<IActionResult> Index()
        {
              return _context.goldKrtMsts != null ? 
                          View(await _context.goldKrtMsts.ToListAsync()) :
                          Problem("Entity set 'JewelryContext.goldKrtMsts'  is null.");
        }

        // GET: GoldKrtMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.goldKrtMsts == null)
            {
                return NotFound();
            }

            var goldKrtMst = await _context.goldKrtMsts
                .FirstOrDefaultAsync(m => m.GoldKrtMstID == id);
            if (goldKrtMst == null)
            {
                return NotFound();
            }

            return View(goldKrtMst);
        }

        // GET: GoldKrtMsts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoldKrtMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoldKrtMstID,Gold_Crt")] GoldKrtMst goldKrtMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goldKrtMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goldKrtMst);
        }

        // GET: GoldKrtMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.goldKrtMsts == null)
            {
                return NotFound();
            }

            var goldKrtMst = await _context.goldKrtMsts.FindAsync(id);
            if (goldKrtMst == null)
            {
                return NotFound();
            }
            return View(goldKrtMst);
        }

        // POST: GoldKrtMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoldKrtMstID,Gold_Crt")] GoldKrtMst goldKrtMst)
        {
            if (id != goldKrtMst.GoldKrtMstID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goldKrtMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoldKrtMstExists(goldKrtMst.GoldKrtMstID))
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
            return View(goldKrtMst);
        }

        // GET: GoldKrtMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.goldKrtMsts == null)
            {
                return NotFound();
            }

            var goldKrtMst = await _context.goldKrtMsts
                .FirstOrDefaultAsync(m => m.GoldKrtMstID == id);
            if (goldKrtMst == null)
            {
                return NotFound();
            }

            return View(goldKrtMst);
        }

        // POST: GoldKrtMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.goldKrtMsts == null)
            {
                return Problem("Entity set 'JewelryContext.goldKrtMsts'  is null.");
            }
            var goldKrtMst = await _context.goldKrtMsts.FindAsync(id);
            if (goldKrtMst != null)
            {
                _context.goldKrtMsts.Remove(goldKrtMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoldKrtMstExists(int id)
        {
          return (_context.goldKrtMsts?.Any(e => e.GoldKrtMstID == id)).GetValueOrDefault();
        }
    }
}
