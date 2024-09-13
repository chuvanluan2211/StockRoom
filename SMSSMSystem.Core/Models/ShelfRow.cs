using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSMSystem.Core.Models
{
	public class ShelfRow
	{
		public Guid ShelfRowId { get; set; }
		public Guid ShelfId { get; set; }
		[Required(ErrorMessage = "ShelfRowName is required.")]
		[StringLength(50, ErrorMessage = "ShelfRowName cannot exceed 50 characters.")]
		public string? ShelfRowName { get; set; }

		// Định nghĩa khóa ngoại
		public Shelf? Shelf { get; set; }
		public List<ShelfColumn>? ShelfColumns { get; set; }
	}
}
