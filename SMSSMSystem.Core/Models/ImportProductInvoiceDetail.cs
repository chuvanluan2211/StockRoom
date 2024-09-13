using System.ComponentModel.DataAnnotations;

namespace SMSSMSystem.Core.Models
{
	public class ImportProductInvoiceDetail
	{
		public Guid ImportProductInvoiceDetailId { get; set; }
		[Required(ErrorMessage = "ImportProductInvoice_id is required")]
		public Guid ImportProductInvoiceId { get; set; }
		[Required(ErrorMessage = "ProductId is required")]
		public Guid ProductId { get; set; }
		public int? Quantity { get; set; }
		[DataType(DataType.Date)]
		public DateTime ProductionDate { get; set; }
		[DataType(DataType.Date)]
		public DateTime ExpiredDate { get; set; }
		[DataType(DataType.Currency)]
		public decimal? Price { get; set; }

		// Định nghĩa khóa ngoại
		public ImportProductInvoice? ImportProductInvoice { get; set; }
		public Product? Product { get; set; }
	}
}
