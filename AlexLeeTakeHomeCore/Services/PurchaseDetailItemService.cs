using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using AlexLeeTakeHomeCore.Data;
using Microsoft.IdentityModel.Tokens;

namespace AlexLeeTakeHomeCore.Services;

public class PurchaseDetailItemService : IPurchaseDetailItemService
{
	private readonly AlexLeeTakeHomeContext _context;

	public PurchaseDetailItemService(AlexLeeTakeHomeContext context)
	{
		_context = context;
	}

	public async Task<List<PurchaseDetailItem>> GetAllAsync()
	{
		return await _context.PurchaseDetailItems.ToListAsync();
	}

	public Task<List<PurchaseDetailItem>> SearchAsync(PurchaseDetailItemSearchRequest searchRequest)
	{
		IQueryable<PurchaseDetailItem> results = _context.PurchaseDetailItems;
		if (!searchRequest.PurchaseOrderNumber.IsNullOrEmpty())
		{
			results = results.Where(r => r.PurchaseOrderNumber.Contains(searchRequest.PurchaseOrderNumber));
		}

		if (searchRequest.ItemNumber.HasValue)
		{
			results = results.Where(r => r.ItemNumber == searchRequest.ItemNumber);
		}

		if (!searchRequest.ItemName.IsNullOrEmpty())
		{
			results = results.Where(r => r.ItemName.Contains(searchRequest.ItemName));
		}

		if (!searchRequest.ItemDescription.IsNullOrEmpty())
		{
			results = results.Where(r => r.ItemDescription.Contains(searchRequest.ItemDescription));
		}

		return results.ToListAsync();
	}

	public async Task<PurchaseDetailItem?> GetByIdAsync([DisallowNull] long? id)
	{
		var purchaseDetailItem = await _context.PurchaseDetailItems
			.FirstOrDefaultAsync(m => m.PurchaseDetailItemAutoId == id);

		return purchaseDetailItem;
	}

	public async Task CreateAsync(PurchaseDetailItem purchaseDetailItem)
	{
		_context.Add(purchaseDetailItem);

		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(PurchaseDetailItem purchaseDetailItem)
	{
		_context.Update(purchaseDetailItem);
		await _context.SaveChangesAsync();
	}

	public async Task<bool> DeleteByIdAsync(long id)
	{
		var itemToDelete = await _context.PurchaseDetailItems.FindAsync(id);
		if (itemToDelete == null)
		{
			return false;
		}

		_context.PurchaseDetailItems.Remove(itemToDelete);
		await _context.SaveChangesAsync();

		return true;
	}

	public Task<bool> ExistsByIdAsync(long id)
	{
		return _context.PurchaseDetailItems.AnyAsync(e => e.PurchaseDetailItemAutoId == id);
	}
}