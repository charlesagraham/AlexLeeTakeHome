using AlexLeeTakeHomeCore.Data;

namespace AlexLeeTakeHomeWeb.Models.PurchaseDetailItems;

public class IndexModel
{
	public SearchModel Search { get; set; } = new SearchModel();
	public IEnumerable<PurchaseDetailItem> Results { get; set; } = new List<PurchaseDetailItem>();
	public CreateModel Create { get; set; } = new CreateModel();
}