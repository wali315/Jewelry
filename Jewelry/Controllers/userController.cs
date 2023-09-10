using Jewelry.Data;
using Jewelry.Migrations;
using Jewelry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Jewelry.Controllers
{
    public class userController : Controller
    {
        readonly JewelryContext dbg;
        public userController(JewelryContext dbc)
        {
            dbg = dbc;
        }

        public IActionResult Index(string kk = null)
        {
            var items = dbg.itemDetails.Include(i => i.catMst).Include(i => i.brandMst).Include(i => i.prodMst).ToList();

            if (!string.IsNullOrEmpty(kk))
            {
                items = items.Where(x => x.catMst.Cat_Name == kk || x.brandMst.Brand_Type == kk || x.prodMst.Prod_Type == kk).ToList();
            }

            var categories = dbg.catMsts.ToList();
            var brands = dbg.brandMsts.ToList();
            var products = dbg.prodMsts.Take(3).ToList(); // Retrieve only the first three products

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            ViewBag.Products = products;

            return View(items);
        }

        public IActionResult shop(string cs = null, string searchQuery = null)
        {
            var items = dbg.itemDetails.Include(i => i.catMst).Include(i => i.brandMst).Include(i => i.prodMst).ToList();

            if (!string.IsNullOrEmpty(cs))
            {
                items = items.Where(x => x.catMst.Cat_Name == cs || x.brandMst.Brand_Type == cs || x.prodMst.Prod_Type == cs).ToList();
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                items = items.Where(x => x.catMst.Cat_Name.Contains(searchQuery)).ToList();
            }

            var categories = dbg.catMsts.ToList();
            var brands = dbg.brandMsts.ToList();
            var products = dbg.prodMsts.ToList();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            ViewBag.Products = products;

            return View(items);
        }

        public async Task<IActionResult> Singleshop(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDetails = await dbg.itemDetails
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

        public IActionResult About()
        {
            return View();

        }

        public IActionResult Contact()
        {
            return View();

        }

    }
}

