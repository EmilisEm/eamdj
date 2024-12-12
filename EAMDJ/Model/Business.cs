namespace EAMDJ.Model;

public record Business
{
	public Guid Id { get; init; }

	// Should probably decide whether we set strings as nullable or we initialize them as string.Empty.
	public string Name { get; set; } = string.Empty;
	public string Address { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public Guid OwnerId { get; set; }
	public User? Owner { get; set; }

	// Data model specifies business-wide VAT.
	// I don't think there should be a business-wide VAT because:
	// VAT tax can differ depending on type of product and service being offered.
	// In Lithuania for our use-case (point-of-purchase system) it wouldn't differ (21%) but for example in Poland the
	// standard VAT tax is 23% but is lower for certain food products and services.
	// public decimal VAT { get; set; }
}