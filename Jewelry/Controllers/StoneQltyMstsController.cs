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
    public class StoneQltyMstsController : Controller
    {
        private readonly JewelryContext _context;

        public StoneQltyMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: StoneQltyMsts
        public async Task<IActionResult> Index()
        {
              return _context.stoneQltyMsts != null ? 
                          View(await _context.stoneQltyMsts.ToListAsync()) :
                          Problem("Entity set 'JewelryContext.stoneQltyMsts'  is null.");
        }

        // GET: StoneQltyMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.stoneQltyMsts == null)
            {
                return NotFound();
            }

            var stoneQltyMst = await _context.stoneQltyMsts
                .FirstOrDefaultAsync(m => m.StoneQltyMstID == id);
            if (stoneQltyMst == null)
            {
                return NotFound();
            }

            return View(stoneQltyMst);
        }

        // GET: StoneQltyMsts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoneQltyMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoneQltyMstID,StoneQlty")] StoneQltyMst stoneQltyMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stoneQltyMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stoneQltyMst);
        }

        // GET: StoneQltyMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.stoneQltyMsts == null)
            {
                return NotFound();
            }

            var stoneQltyMst = await _context.stoneQltyMsts.FindAsync(id);
            if (stoneQltyMst == null)
            {
                return NotFound();
            }
            return View(stoneQltyMst);
        }

        // POST: StoneQltyMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoneQltyMstID,StoneQlty")] StoneQltyMst stoneQltyMst)
        {
            if (id != stoneQltyMst.StoneQltyMstID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stoneQltyMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoneQltyMstExists(stoneQltyMst.StoneQltyMstID))
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
            return View(stoneQltyMst);
        }

        // GET: StoneQltyMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.stoneQltyMsts == null)
            {
                return NotFound();
            }

            var stoneQltyMst = await _context.stoneQltyMsts
                .FirstOrDefaultAsync(m => m.StoneQltyMstID == id);
            if (stoneQltyMst == null)
            {
                return NotFound();
            }

            return View(stoneQltyMst);
        }

        // POST: StoneQltyMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.stoneQltyMsts == null)
            {
                return Problem("Entity set 'JewelryContext.stoneQltyMsts'  is null.");
            }
            var stoneQltyMst = await _context.stoneQltyMsts.FindAsync(id);
            if (stoneQltyMst != null)
            {
                _context.stoneQltyMsts.Remove(stoneQltyMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoneQltyMstExists(int id)
        {
          return (_context.stoneQltyMsts?.Any(e => e.StoneQltyMstID == id)).GetValueOrDefault();
        }
    }
}
