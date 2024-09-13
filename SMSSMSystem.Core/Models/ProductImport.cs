using System.ComponentModel.DataAnnotations;

namespace SMSSMSystem.Core.Models
{
	public class ProductImport
	{
		public Guid ProductImportId { get; set; }
		[Required(ErrorMessage = "ProductId is required")]
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		[DataType(DataType.Date)]
		public DateTime? ProductionDate { get; set; }
		[DataType(DataType.Date)]
		public DateTime? ExpiredDate { get; set; }

		// Định nghĩa khóa ngoại
		public Product? Product { get; set; }
	}
}
