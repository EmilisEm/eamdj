namespace EAMDJ.Model;

public record Tax
{
	public Guid Id { get; init; }
	public Guid BusinessId { get; init; }
	public virtual Business? Business { get; set; }
	public string Name { get; set; } = string.Empty;
	public decimal Percentage { get; set; }
	public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
}