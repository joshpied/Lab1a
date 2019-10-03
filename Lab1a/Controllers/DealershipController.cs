using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1a.Models;

namespace Lab1a.Controllers
{
    public class DealershipController : Controller
    {
        private readonly Lab1aContext _context;

        public DealershipController(Lab1aContext context)
        {
            _context = context;
        }

        public ActionResult SeedDB()
        {
            // var dealerships = new DealershipMgr().Get();
            if (_context.Dealership.Count() == 0)
            {
                Dealership deal1 = new Dealership { Id = 1, Name = "Joshs Cars", Email = "dealer@josh.ca", PhoneNumber = "905-123-4567" };
                Dealership deal2 = new Dealership { Id = 2, Name = "Used Cars", Email = "used@car.ca", PhoneNumber = "905-122-3461" };
                _context.Dealership.AddRange(deal1, deal2);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Dealership
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dealership.ToListAsync());
        }

        // GET: Dealership/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealership
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }

        // GET: Dealership/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dealership/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber")] Dealership dealership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dealership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dealership);
        }

        // GET: Dealership/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealership.FindAsync(id);
            if (dealership == null)
            {
                return NotFound();
            }
            return View(dealership);
        }

        // POST: Dealership/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber")] Dealership dealership)
        {
            if (id != dealership.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dealership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealershipExists(dealership.Id))
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
            return View(dealership);
        }

        // GET: Dealership/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dealership = await _context.Dealership
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealership == null)
            {
                return NotFound();
            }

            return View(dealership);
        }

        // POST: Dealership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dealership = await _context.Dealership.FindAsync(id);
            _context.Dealership.Remove(dealership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealershipExists(int id)
        {
            return _context.Dealership.Any(e => e.Id == id);
        }
    }
}
