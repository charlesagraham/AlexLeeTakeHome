using AlexLeeTakeHomeCore.Data;

namespace AlexLeeTakeHomeWeb.Models;

public class PurchaseDetailItemIndexModel
{
	public PurchaseDetailItemSearchModel Search { get; set; } = new PurchaseDetailItemSearchModel();
	public IEnumerable<PurchaseDetailItem> Results { get; set; } = new List<PurchaseDetailItem>();
}