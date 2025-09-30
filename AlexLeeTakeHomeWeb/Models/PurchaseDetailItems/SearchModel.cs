using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlexLeeTakeHomeWeb.Models.PurchaseDetailItems;

public class SearchModel
{
	[DisplayName("Purchase Order Number")]
	public string? PurchaseOrderNumber { get; set; } = null!;

	[Range(0, int.MaxValue)]
	[DisplayName("Item Number")]
	public int? ItemNumber { get; set; }

	[DisplayName("Item Name")]
	public string? ItemName { get; set; } = null!;

	[DisplayName("Item Description")]
	public string? ItemDescription { get; set; }
}