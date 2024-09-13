using System.ComponentModel.DataAnnotations;

namespace SMSSMSystem.Core.Models
{
	public class ProductPutOut
	{
		public Guid ProductPutOutId { get; set; }
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		[DataType(DataType.Date)]
		public DateTime ProductionDate { get; set; }
		[DataType(DataType.Date)]
		public DateTime ExpiredDate { get; set; }

		// Định nghĩa khóa ngoại
		public Product? Product { get; set; }
	}
}
