using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jewelry.Data;
using Jewelry.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Jewelry.Controllers
{
    public class ItemDetailsController : Controller
    {
        private readonly JewelryContext _context;
        IWebHostEnvironment ie;
        public ItemDetailsController(JewelryContext context, IWebHostEnvironment ue)
        {
            _context = context;
            ie = ue;
        }
        // GET: ItemDetails
        public async Task<IActionResult> Index()
        {
            var jewelryContext = _context.itemDetails.Include(i => i.brandMst).Include(i => i.catMst).Include(i => i.certifyMst).Include(i => i.goldKrtMst).Include(i => i.prodMst);
            return View(await jewelryContext.ToListAsync());
        }
        // GET: ItemDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.itemDetails == null)
            {
                return NotFound();
            }
            var itemDetails = await _context.itemDetails
                .Include(i => i.brandMst)
                .Include(i => i.catMst)
                .Include(i => i.certifyMst)
                .Include(i => i.goldKrtMst)
                .Include(i => i.prodMst)
                .FirstOrDefaultAsync(m => m.ItemMstID == id);
            if (itemDetails == null)
            {
                return NotFound();
            }
            return View(itemDetails);
        }
        // GET: ItemDetails/Create
        public IActionResult Create()
        {
            ViewData["BrandMstID"] = new SelectList(_context.brandMsts, "BrandMstID", "Brand_Type");
            ViewData["CatMstId"] = new SelectList(_context.catMsts, "CatMstId", "Cat_Name");
            ViewData["CertifyMstID"] = new SelectList(_context.CertifyMsts, "CertifyMstID", "Cat_Name");
            ViewData["GoldKrtMstID"] = new SelectList(_context.goldKrtMsts, "GoldKrtMstID", "Gold_Crt");
            ViewData["ProdMstID"] = new SelectList(_context.prodMsts, "ProdMstID", "Prod_Type");
            return View();
        }
        // POST: ItemDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemDetails itemDetails, IFormFile img )
        {
            string ext = Path.GetExtension(img.FileName);
            if (ext == ".jpg" || ext == ".gif" || ext == ".png" )
            {
                string d = Path.Combine(ie.WebRootPath, "images");
                var fname = Path.GetFileName(img.FileName);
                string filepath = Path.Combine(d, fname);
                using (var fs = new FileStream(filepath, FileMode.Create))
                {
                    await img.CopyToAsync(fs);
                }
                itemDetails.imgUrl = @"\images\" + fname;

                _context.Add(itemDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.m = "wrong picture format";
            }
            _context.Add(itemDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
        // GET: ItemDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.itemDetails == null)
            {
                return NotFound();
            }
            var itemDetails = await _context.itemDetails.FindAsync(id);
            if (itemDetails == null)
            {
                return NotFound();
            }
            ViewData["BrandMstID"] = new SelectList(_context.brandMsts, "BrandMstID", "Brand_Type", itemDetails.BrandMstID);
            ViewData["CatMstId"] = new SelectList(_context.catMsts, "CatMstId", "Cat_Name", itemDetails.CatMstId);
            ViewData["CertifyMstID"] = new SelectList(_context.CertifyMsts, "CertifyMstID", "Cat_Name", itemDetails.CertifyMstID);
            ViewData["GoldKrtMstID"] = new SelectList(_context.goldKrtMsts, "GoldKrtMstID", "Gold_Crt", itemDetails.GoldKrtMstID);
            ViewData["ProdMstID"] = new SelectList(_context.prodMsts, "ProdMstID", "Prod_Type", itemDetails.ProdMstID);
            return View(itemDetails);
        }
        // POST: ItemDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemMstID,CatMstId,prodName,Pairs,BrandMstID,Quantity,CertifyMstID,GoldKrtMstID,Gold_Wt,Net_Gold,Wstg_Per,Wstg,Tot_Gross_Wt,Gold_Rate,Gold_Amt,Gold_Making,ProdMstID,Dim_Pcs,Stone_Wt,Stone_Making,Dim_Amt,imgUrl,MRP")] ItemDetails itemDetails)
        {
            if (id != itemDetails.ItemMstID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemDetailsExists(itemDetails.ItemMstID))
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
            ViewData["BrandMstID"] = new SelectList(_context.brandMsts, "BrandMstID", "Brand_Type", itemDetails.BrandMstID);
            ViewData["CatMstId"] = new SelectList(_context.catMsts, "CatMstId", "Cat_Name", itemDetails.CatMstId);
            ViewData["CertifyMstID"] = new SelectList(_context.CertifyMsts, "CertifyMstID", "Cat_Name", itemDetails.CertifyMstID);
            ViewData["GoldKrtMstID"] = new SelectList(_context.goldKrtMsts, "GoldKrtMstID", "Gold_Crt", itemDetails.GoldKrtMstID);
            ViewData["ProdMstID"] = new SelectList(_context.prodMsts, "ProdMstID", "Prod_Type", itemDetails.ProdMstID);
            return View(itemDetails);
        }
        // GET: ItemDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.itemDetails == null)
            {
                return NotFound();
            }
            var itemDetails = await _context.itemDetails
                .Include(i => i.brandMst)
                .Include(i => i.catMst)
                .Include(i => i.certifyMst)
                .Include(i => i.goldKrtMst)
                .Include(i => i.prodMst)
                .FirstOrDefaultAsync(m => m.ItemMstID == id);
            if (itemDetails == null)
            {
                return NotFound();
            }
            return View(itemDetails);
        }
        // POST: ItemDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.itemDetails == null)
            {
                return Problem("Entity set 'JewelryContext.itemDetails'  is null.");
            }
            var itemDetails = await _context.itemDetails.FindAsync(id);
            if (itemDetails != null)
            {
                _context.itemDetails.Remove(itemDetails);
            }            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ItemDetailsExists(int id)
        {
          return (_context.itemDetails?.Any(e => e.ItemMstID == id)).GetValueOrDefault();
        }
    }
}
