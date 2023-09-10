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
    public class ProdMstsController : Controller
    {
        private readonly JewelryContext _context;

        public ProdMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: ProdMsts
        public async Task<IActionResult> Index()
        {
              return _context.prodMsts != null ? 
                          View(await _context.prodMsts.ToListAsync()) :
                          Problem("Entity set 'JewelryContext.prodMsts'  is null.");
        }

        // GET: ProdMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.prodMsts == null)
            {
                return NotFound();
            }

            var prodMst = await _context.prodMsts
                .FirstOrDefaultAsync(m => m.ProdMstID == id);
            if (prodMst == null)
            {
                return NotFound();
            }

            return View(prodMst);
        }

        // GET: ProdMsts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdMstID,Prod_Type")] ProdMst prodMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodMst);
        }

        // GET: ProdMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.prodMsts == null)
            {
                return NotFound();
            }

            var prodMst = await _context.prodMsts.FindAsync(id);
            if (prodMst == null)
            {
                return NotFound();
            }
            return View(prodMst);
        }

        // POST: ProdMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdMstID,Prod_Type")] ProdMst prodMst)
        {
            if (id != prodMst.ProdMstID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdMstExists(prodMst.ProdMstID))
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
            return View(prodMst);
        }

        // GET: ProdMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.prodMsts == null)
            {
                return NotFound();
            }

            var prodMst = await _context.prodMsts
                .FirstOrDefaultAsync(m => m.ProdMstID == id);
            if (prodMst == null)
            {
                return NotFound();
            }

            return View(prodMst);
        }

        // POST: ProdMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.prodMsts == null)
            {
                return Problem("Entity set 'JewelryContext.prodMsts'  is null.");
            }
            var prodMst = await _context.prodMsts.FindAsync(id);
            if (prodMst != null)
            {
                _context.prodMsts.Remove(prodMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdMstExists(int id)
        {
          return (_context.prodMsts?.Any(e => e.ProdMstID == id)).GetValueOrDefault();
        }
    }
}
