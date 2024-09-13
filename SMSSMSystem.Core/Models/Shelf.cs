using System.ComponentModel.DataAnnotations;

namespace SMSSMSystem.Core.Models
{
	public class Shelf
	{
		public Guid ShelfId { get; set; }
		[Required(ErrorMessage = "ShelfName is required.")]
		[StringLength(50, ErrorMessage = "ShelfName cannot exceed 50 characters.")]
		public string? ShelfName { get; set; }
		public List<ShelfRow>? ShelfRows { get; set; }
	}
}
