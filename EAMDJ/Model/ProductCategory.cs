namespace EAMDJ.Model;

public record ProductCategory {
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public Guid BusinessId { get; set; }
}