using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlexLeeTakeHomeCore.Models;

namespace AlexLeeTakeHomeWeb.Controllers
{
    public class PurchaseDetailItemsController : Controller
    {
        private readonly AlexLeeTakeHomeContext _context;

        public PurchaseDetailItemsController(AlexLeeTakeHomeContext context)
        {
            _context = context;
        }

        // GET: PurchaseDetailItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseDetailItems.ToListAsync());
        }

        // GET: PurchaseDetailItems/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetailItem = await _context.PurchaseDetailItems
                .FirstOrDefaultAsync(m => m.PurchaseDetailItemAutoId == id);
            if (purchaseDetailItem == null)
            {
                return NotFound();
            }

            return View(purchaseDetailItem);
        }

        // GET: PurchaseDetailItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseDetailItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseDetailItemAutoId,PurchaseOrderNumber,ItemNumber,ItemName,ItemDescription,PurchasePrice,PurchaseQuantity,LastModifiedByUser,LastModifiedDateTime")] PurchaseDetailItem purchaseDetailItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseDetailItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseDetailItem);
        }

        // GET: PurchaseDetailItems/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetailItem = await _context.PurchaseDetailItems.FindAsync(id);
            if (purchaseDetailItem == null)
            {
                return NotFound();
            }
            return View(purchaseDetailItem);
        }

        // POST: PurchaseDetailItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PurchaseDetailItemAutoId,PurchaseOrderNumber,ItemNumber,ItemName,ItemDescription,PurchasePrice,PurchaseQuantity,LastModifiedByUser,LastModifiedDateTime")] PurchaseDetailItem purchaseDetailItem)
        {
            if (id != purchaseDetailItem.PurchaseDetailItemAutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseDetailItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseDetailItemExists(purchaseDetailItem.PurchaseDetailItemAutoId))
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
            return View(purchaseDetailItem);
        }

        // GET: PurchaseDetailItems/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetailItem = await _context.PurchaseDetailItems
                .FirstOrDefaultAsync(m => m.PurchaseDetailItemAutoId == id);
            if (purchaseDetailItem == null)
            {
                return NotFound();
            }

            return View(purchaseDetailItem);
        }

        // POST: PurchaseDetailItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var purchaseDetailItem = await _context.PurchaseDetailItems.FindAsync(id);
            if (purchaseDetailItem != null)
            {
                _context.PurchaseDetailItems.Remove(purchaseDetailItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseDetailItemExists(long id)
        {
            return _context.PurchaseDetailItems.Any(e => e.PurchaseDetailItemAutoId == id);
        }
    }
}
