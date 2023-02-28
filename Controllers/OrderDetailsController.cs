using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KursovoiRSOD.Models;

namespace test.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly SecurityCompanyDbContext _context;

        public OrderDetailsController(SecurityCompanyDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var securityCompanyDbContext = _context.OrderDetails.Include(o => o.GuardedObject).Include(o => o.Order).Include(o => o.Service);
            return View(await securityCompanyDbContext.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.GuardedObject)
                .Include(o => o.Order)
                .Include(o => o.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["GuardedObjectId"] = new SelectList(_context.GuardedObjects, "Id", "Name");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,GuardedObjectId,ServiceId,number")] OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuardedObjectId"] = new SelectList(_context.GuardedObjects, "Id", "Name", orderDetails.GuardedObjectId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDetails.OrderId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", orderDetails.ServiceId);
            return View(orderDetails);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            ViewData["GuardedObjectId"] = new SelectList(_context.GuardedObjects, "Id", "Name", orderDetails.GuardedObjectId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDetails.OrderId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", orderDetails.ServiceId);
            return View(orderDetails);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,GuardedObjectId,ServiceId,number")] OrderDetails orderDetails)
        {
            if (id != orderDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailsExists(orderDetails.Id))
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
            ViewData["GuardedObjectId"] = new SelectList(_context.GuardedObjects, "Id", "Name", orderDetails.GuardedObjectId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDetails.OrderId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", orderDetails.ServiceId);
            return View(orderDetails);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.GuardedObject)
                .Include(o => o.Order)
                .Include(o => o.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderDetails == null)
            {
                return Problem("Entity set 'SecurityCompanyDbContext.OrderDetails'  is null.");
            }
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails != null)
            {
                _context.OrderDetails.Remove(orderDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailsExists(int id)
        {
          return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}
