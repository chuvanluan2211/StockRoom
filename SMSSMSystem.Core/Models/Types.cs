using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSMSystem.Core.Models
{
	public class Types
	{
		public Guid TypeId { get; set; }
		[Required(ErrorMessage = "TypeName is required.")]
		[StringLength(50, ErrorMessage = "TypeName cannot exceed 50 characters.")]
		public string? TypeName { get; set; }

		public string? Description { get; set; }
		public List<Product>? Products { get; set; }
	}
}
