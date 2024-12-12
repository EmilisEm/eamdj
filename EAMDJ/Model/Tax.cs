namespace EAMDJ.Model;

public record Tax
{
	public Guid Id { get; init; }
	public string Name { get; set; } = string.Empty;
	public decimal Percentage { get; set; }
	public Guid BusinessId { get; set; }
}