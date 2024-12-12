namespace EAMDJ.Model
{
	public class ProductModifier
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public Guid ProductId { get; set; }
		public virtual Product? Product { get; set; }
	}
}
