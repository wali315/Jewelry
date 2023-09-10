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
    public class CatMstsController : Controller
    {
        private readonly JewelryContext _context;

        public CatMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: CatMsts
        public async Task<IActionResult> Index()
        {
              return _context.catMsts != null ? 
                          View(await _context.catMsts.ToListAsync()) :
                          Problem("Entity set 'JewelryContext.catMsts'  is null.");
        }

        // GET: CatMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.catMsts == null)
            {
                return NotFound();
            }

            var catMst = await _context.catMsts
                .FirstOrDefaultAsync(m => m.CatMstId == id);
            if (catMst == null)
            {
                return NotFound();
            }

            return View(catMst);
        }

        // GET: CatMsts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatMstId,Cat_Name")] CatMst catMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catMst);
        }

        // GET: CatMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.catMsts == null)
            {
                return NotFound();
            }

            var catMst = await _context.catMsts.FindAsync(id);
            if (catMst == null)
            {
                return NotFound();
            }
            return View(catMst);
        }

        // POST: CatMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatMstId,Cat_Name")] CatMst catMst)
        {
            if (id != catMst.CatMstId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatMstExists(catMst.CatMstId))
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
            return View(catMst);
        }

        // GET: CatMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.catMsts == null)
            {
                return NotFound();
            }

            var catMst = await _context.catMsts
                .FirstOrDefaultAsync(m => m.CatMstId == id);
            if (catMst == null)
            {
                return NotFound();
            }

            return View(catMst);
        }

        // POST: CatMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.catMsts == null)
            {
                return Problem("Entity set 'JewelryContext.catMsts'  is null.");
            }
            var catMst = await _context.catMsts.FindAsync(id);
            if (catMst != null)
            {
                _context.catMsts.Remove(catMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatMstExists(int id)
        {
          return (_context.catMsts?.Any(e => e.CatMstId == id)).GetValueOrDefault();
        }
    }
}
