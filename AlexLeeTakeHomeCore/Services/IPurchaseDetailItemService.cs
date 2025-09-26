using System.Diagnostics.CodeAnalysis;
using AlexLeeTakeHomeCore.Data;

namespace AlexLeeTakeHomeCore.Services;

public interface IPurchaseDetailItemService
{
	Task<List<PurchaseDetailItem>> GetAllAsync();
	Task<PurchaseDetailItem?> GetByIdAsync([DisallowNull] long? id);
	Task CreateAsync(PurchaseDetailItem purchaseDetailItem);
	Task UpdateAsync(PurchaseDetailItem purchaseDetailItem);
	Task<bool> DeleteByIdAsync(long id);
	Task<bool> ExistsByIdAsync(long id);
}