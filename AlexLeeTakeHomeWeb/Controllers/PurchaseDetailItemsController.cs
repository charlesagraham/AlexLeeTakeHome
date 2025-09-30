using AlexLeeTakeHomeCore.Data;
using AlexLeeTakeHomeCore.Services;
using AlexLeeTakeHomeWeb.Models.PurchaseDetailItems;
using Microsoft.AspNetCore.Mvc;

namespace AlexLeeTakeHomeWeb.Controllers
{
    public class PurchaseDetailItemsController : Controller
    {
        private readonly IPurchaseDetailItemService _purchaseDetailItemService;

		public PurchaseDetailItemsController(IPurchaseDetailItemService purchaseDetailItemService)
		{
			_purchaseDetailItemService = purchaseDetailItemService;
		}

        public async Task<IActionResult> Index()
        {
	        var model = new IndexModel
	        {
		        Search = new SearchModel(),
		        Results = await _purchaseDetailItemService.GetAllAsync(),
	        };

            return View(model);
        }

        public async Task<IActionResult> Search(SearchModel searchModel)
        {
	        var model = new IndexModel
	        {
		        Search = searchModel,
		        Results = await _purchaseDetailItemService.SearchAsync(new PurchaseDetailItemSearchRequest
		        {
					ItemDescription = searchModel.ItemDescription,
					ItemName = searchModel.ItemName,
					ItemNumber = searchModel.ItemNumber,
					PurchaseOrderNumber = searchModel.PurchaseOrderNumber
		        }),
	        };

	        return View("Index", model);
		}

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
        public async Task<IActionResult> Create(CreateModel CreateModel)
        {
	        var purchaseDetailItem = new PurchaseDetailItem
	        {
				ItemDescription = CreateModel.ItemDescription,
                ItemName = CreateModel.ItemName,
                ItemNumber = CreateModel.ItemNumber,
                PurchaseOrderNumber = CreateModel.PurchaseOrderNumber,
                PurchasePrice = CreateModel.PurchasePrice,
                PurchaseQuantity = CreateModel.PurchaseQuantity,
				LastModifiedDateTime = DateTime.Now,
		        LastModifiedByUser = HttpContext.User.Identity.Name ?? "Unauthenticated User",
			};

	        if (!ModelState.IsValid)
	        {
		        return View(purchaseDetailItem);
	        }
	        
	        await _purchaseDetailItemService.CreateAsync(purchaseDetailItem);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(long id)
        {
            var purchaseDetailItem = await _purchaseDetailItemService.GetByIdAsync(id);
            if (purchaseDetailItem == null)
            {
                return NotFound();
            }

            return View(purchaseDetailItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PurchaseDetailItemAutoId,PurchaseOrderNumber,ItemNumber,ItemName,ItemDescription,PurchasePrice,PurchaseQuantity,LastModifiedByUser,LastModifiedDateTime")] PurchaseDetailItem purchaseDetailItem)
        {
            if (id != purchaseDetailItem.PurchaseDetailItemAutoId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
	            return View(purchaseDetailItem);
            }

            await _purchaseDetailItemService.UpdateAsync(purchaseDetailItem);
	            
            return RedirectToAction(nameof(Index));

        }

		public async Task<IActionResult> Delete(long id)
		{
			var purchaseDetailItem = await _purchaseDetailItemService.GetByIdAsync(id);
			if (purchaseDetailItem == null)
			{
				return NotFound();
			}

			return View(purchaseDetailItem);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long id)
		{
			await _purchaseDetailItemService.DeleteByIdAsync(id);

			return RedirectToAction(nameof(Index));
		}
	}
}
