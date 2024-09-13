using System.ComponentModel.DataAnnotations;

namespace SMSSMSystem.Core.Models
{
	public class Category
	{
		public Guid CategoryId { get; set; }
		[Required(ErrorMessage = "CategoryName is required.")]
		[StringLength(50, ErrorMessage = "CategoryName cannot exceed 50 characters.")]
		public string? CategoryName { get; set; }
		[StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
		public string? Description { get; set; }
		public List<Product>? Products { get; set; }

	}
}
