namespace AlexLeeTakeHomeCore.Services;

public class PurchaseDetailItemSearchRequest
{
	public string? PurchaseOrderNumber { get; set; }
	public int? ItemNumber { get; set; }
	public string? ItemName { get; set; }
	public string? ItemDescription { get; set; }
}