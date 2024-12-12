namespace EAMDJ.Dto.BusinessDto
{
	public class BusinessCreateDto
	{
		public string Name { get; set; } = string.Empty;
		public Guid? OwnerId { get; set; }
	}
}
