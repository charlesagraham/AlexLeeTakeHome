using System.ComponentModel;

namespace AlexLeeTakeHomeCore.Models;

[DisplayName("Purchase Detail Item")]
public class PurchaseDetailItem
{
	[DisplayName("Id")]
	public long PurchaseDetailItemAutoId { get; set; }

	[DisplayName("Purchase Order Number")]
	public string PurchaseOrderNumber { get; set; } = null!;

	[DisplayName("Item Number")]
	public int ItemNumber { get; set; }

	[DisplayName("Item Name")]
	public string ItemName { get; set; } = null!;

	[DisplayName("Item Description")]
	public string? ItemDescription { get; set; }

	[DisplayName("Purchase Price")]
	public decimal PurchasePrice { get; set; }

	[DisplayName("Purchase Quantity")]
	public int PurchaseQuantity { get; set; }

	[DisplayName("Last Modified By User")]
	public string LastModifiedByUser { get; set; } = null!;

	[DisplayName("Last Modified Date Time")]
	public DateTime LastModifiedDateTime { get; set; }
}
