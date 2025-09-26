using Microsoft.AspNetCore.Mvc;
using AlexLeeTakeHomeCore.Data;
using AlexLeeTakeHomeCore.Services;

namespace AlexLeeTakeHomeWeb.Controllers
{
    public class PurchaseDetailItemsController : Controller
    {
        private readonly IPurchaseDetailItemService _purchaseDetailItemService;

		public PurchaseDetailItemsController(IPurchaseDetailItemService purchaseDetailItemService)
		{
			_purchaseDetailItemService = purchaseDetailItemService;
		}

        // GET: PurchaseDetailItems
        public async Task<IActionResult> Index()
        {
            return View(await _purchaseDetailItemService.GetAllAsync());
        }

        // GET: PurchaseDetailItems/Details/5
        public async Task<IActionResult> Details(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetailItem = await _purchaseDetailItemService.GetByIdAsync(id);

            if (purchaseDetailItem == null)
            {
                return NotFound();
            }

            return View(purchaseDetailItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] PurchaseDetailItem purchaseDetailItem)
        {
	        purchaseDetailItem.LastModifiedByUser = HttpContext.User.ToString();

            if (ModelState.IsValid)
            {
	            await _purchaseDetailItemService.CreateAsync(purchaseDetailItem);

	            return RedirectToAction(nameof(Index));
            }

            return View(purchaseDetailItem);
        }

        // GET: PurchaseDetailItems/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetailItem = await _purchaseDetailItemService.GetByIdAsync(id);
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
	            await _purchaseDetailItemService.UpdateAsync(purchaseDetailItem);
	            
                return RedirectToAction(nameof(Index));
            }

            return View(purchaseDetailItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
	        var wasDeleted = await _purchaseDetailItemService.DeleteByIdAsync(id);
	        if (!wasDeleted)
	        {
		        return NotFound();
	        }

			return RedirectToAction(nameof(Index));
        }
    }
}
