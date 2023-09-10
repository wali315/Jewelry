using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jewelry.Data;
using Jewelry.Models;
using Jewelry.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Http;

namespace Jewelry.Controllers
{
    public class UserRegMstsController : Controller
    {
        JewelryContext _context;      
        IHttpContextAccessor ca;

        public UserRegMstsController(JewelryContext scc, IHttpContextAccessor cca)
        {
            _context = scc;
              ca = cca;
        }

        // GET: UserRegMsts
        public async Task<IActionResult> Index()
        {
              return _context.userRegMsts != null ? 
                          View(await _context.userRegMsts.ToListAsync()) :
                          Problem("Entity set 'JewelryContext.userRegMsts'  is null.");
        }

        // GET: UserRegMsts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.userRegMsts == null)
            {
                return NotFound();
            }

            var userRegMst = await _context.userRegMsts
                .FirstOrDefaultAsync(m => m.UserRegMstId == id);
            if (userRegMst == null)
            {
                return NotFound();
            }

            return View(userRegMst);
        }

        // GET: UserRegMsts/Create
        public IActionResult Create()
        {
            return View();
        }

        

        // POST: UserRegMsts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("UserRegMstId,userFname,userLname,address,city,state,mobNo,emailID,dob,cdate,password")]*/ UserRegMst userRegMst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userRegMst);
                await _context.SaveChangesAsync();
                return RedirectToAction("userlogin","UserRegMsts");
            }
            return View();
        }

        // Step1 User Login 
        [HttpGet]

        public IActionResult userlogin()
        {
            return View();

        }
        [HttpPost]

       
        public IActionResult userlogin(UserRegMst l)
        {

            if (l.emailID.Equals("admin@gmail.com") && l.password.Equals("admin123"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var x = from a in _context.userRegMsts
                        where a.emailID == l.emailID
                        && a.password == l.password
                        select new { a.userFname, a.userLname };
                if (x.Any())

                {
                    var user = x.First();
                    ca.HttpContext.Session.SetString("uid", l.UserRegMstId.ToString());
                    ca.HttpContext.Session.SetString("y", l.emailID);
                    ca.HttpContext.Session.SetString("f", user.userFname);
                    ca.HttpContext.Session.SetString("l", user.userLname);
                    

                    return RedirectToAction("Index", "User");
                    
                }
                else
                {
                    ViewBag.m = "Incorrect Password or Username";
                    return View();
                }
            }
        }
        HttpKeepAlivePingPolicy a = new HttpKeepAlivePingPolicy();

        // GET: UserRegMsts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.userRegMsts == null)
            {
                return NotFound();
            }

            var userRegMst = await _context.userRegMsts.FindAsync(id);
            if (userRegMst == null)
            {
                return NotFound();
            }
            return View(userRegMst);
        }

        // POST: UserRegMsts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserRegMstId,userFname,userLname,address,city,state,mobNo,emailID,dob,cdate,password")] UserRegMst userRegMst)
        {
            if (id != userRegMst.UserRegMstId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRegMst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRegMstExists(userRegMst.UserRegMstId))
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
            return View(userRegMst);
        }

        // GET: UserRegMsts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.userRegMsts == null)
            {
                return NotFound();
            }

            var userRegMst = await _context.userRegMsts
                .FirstOrDefaultAsync(m => m.UserRegMstId == id);
            if (userRegMst == null)
            {
                return NotFound();
            }

            return View(userRegMst);
        }

        // POST: UserRegMsts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.userRegMsts == null)
            {
                return Problem("Entity set 'JewelryContext.userRegMsts'  is null.");
            }
            var userRegMst = await _context.userRegMsts.FindAsync(id);
            if (userRegMst != null)
            {
                _context.userRegMsts.Remove(userRegMst);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRegMstExists(int id)
        {
          return (_context.userRegMsts?.Any(e => e.UserRegMstId == id)).GetValueOrDefault();
        }

        public IActionResult Logout()
        {
            // Clear session variables or perform any necessary logout actions
            ca.HttpContext.Session.Clear();

            // Redirect the user to the login page or any desired page
            return RedirectToAction("Index", "user");
        }
    }
}
