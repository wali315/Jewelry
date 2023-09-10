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
    public class CertifyMstsController : Controller
    {
        private readonly JewelryContext _context;

        public CertifyMstsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: CertifyMsts
        public async Task<IActionResult> Index()
        {
              return _context.CertifyMsts != null ? 
                          View(await _context.CertifyMsts.ToListAsync()) :
                          Problem("Entity set 'JewelryContext.CertifyMsts'  is null.");
        }

        // GET: CertifyMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CertifyMsts == null)
            {
                return NotFound();
            }

            var certifyMst = await _context.CertifyMsts
                .FirstOrDefaultAsync(m => m.CertifyMstID == id);
            if (certifyMst == null)
            {
                return NotFound();
            }

            return View(certifyMst);
        }

        // GET: CertifyMsts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CertifyMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertifyMstID,Cat_Name")] CertifyMst certifyMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certifyMst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certifyMst);
        }

        // GET: CertifyMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CertifyMsts == null)
            {
                return NotFound();
            }

            var certifyMst = await _context.CertifyMsts.FindAsync(id);
            if (certifyMst == null)
            {
                return NotFound();
            }
            return View(certifyMst);
        }

        // POST: CertifyMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertifyMstID,Cat_Name")] CertifyMst certifyMst)
        {
            if (id != certifyMst.CertifyMstID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certifyMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertifyMstExists(certifyMst.CertifyMstID))
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
            return View(certifyMst);
        }

        // GET: CertifyMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CertifyMsts == null)
            {
                return NotFound();
            }

            var certifyMst = await _context.CertifyMsts
                .FirstOrDefaultAsync(m => m.CertifyMstID == id);
            if (certifyMst == null)
            {
                return NotFound();
            }

            return View(certifyMst);
        }

        // POST: CertifyMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CertifyMsts == null)
            {
                return Problem("Entity set 'JewelryContext.CertifyMsts'  is null.");
            }
            var certifyMst = await _context.CertifyMsts.FindAsync(id);
            if (certifyMst != null)
            {
                _context.CertifyMsts.Remove(certifyMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertifyMstExists(int id)
        {
          return (_context.CertifyMsts?.Any(e => e.CertifyMstID == id)).GetValueOrDefault();
        }
    }
}
