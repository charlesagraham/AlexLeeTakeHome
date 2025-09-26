using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlexLeeTakeHomeCore.Data;

[DisplayName("Purchase Detail Item")]
public class PurchaseDetailItem
{
	[DisplayName("Id")]
	public long PurchaseDetailItemAutoId { get; set; }

	[Required]
	[DisplayName("Purchase Order Number")]
	[StringLength(20)]
	public string PurchaseOrderNumber { get; set; } = null!;

	[Required]
	[DisplayName("Item Number")]
	public int ItemNumber { get; set; }

	[Required]
	[DisplayName("Item Name")]
	[StringLength(50)]
	public string ItemName { get; set; } = null!;

	[DisplayName("Item Description")]
	[StringLength(250)]
	public string? ItemDescription { get; set; }

	[Required]
	[Range(0, 99999999.99)] //Max Value of Decimal(10,2)
	[DisplayName("Purchase Price")]
	public decimal PurchasePrice { get; set; }

	[Required]
	[DisplayName("Purchase Quantity")]
	[Range(0, int.MaxValue)]
	public int PurchaseQuantity { get; set; }

	[Required]
	[DisplayName("Last Modified By User")]
	public string LastModifiedByUser { get; set; } = null!;

	[Required]
	[DisplayName("Last Modified Date Time")]
	public DateTime LastModifiedDateTime { get; set; } = DateTime.Now;
}
