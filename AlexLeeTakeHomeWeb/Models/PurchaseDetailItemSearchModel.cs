namespace AlexLeeTakeHomeWeb.Models;

public class PurchaseDetailItemSearchModel
{
	public string PurchaseOrderNumber { get; set; } = null!;

	public int ItemNumber { get; set; }

	public string ItemName { get; set; } = null!;

	public string? ItemDescription { get; set; }
}