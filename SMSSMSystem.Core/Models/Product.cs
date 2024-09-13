using System.ComponentModel.DataAnnotations;

namespace SMSSMSystem.Core.Models
{
	public class Product
	{
		public Guid ProductId { get; set; }
		public Guid TypeId { get; set; }
		public Guid CategoryId { get; set; }
		[Required(ErrorMessage = "ProductName is required.")]
		[StringLength(100, ErrorMessage = "ProductName cannot exceed 100 characters.")]
		public string? ProductName { get; set; }
		[Required(ErrorMessage = "ImportPrice is required.")]
		public decimal? ImportPrice { get; set; }
		[Required(ErrorMessage = "Weight is required.")]
		public float? Weight { get; set; }
		[Required(ErrorMessage = "ExportPrice is required.")]
		public decimal? ExportPrice { get; set; }

		// Định nghĩa khóa ngoại
		public Types? Type { get; set; }
		public Category? Category { get; set; }
		public List<ProductImport>? ProductImports { get; set; }
		public List<ProductPutOut>? ProductPutOuts { get; set; }
		public List<ShelfColumn>? ShelfColumns { get; set; }
		public List<StockRoom>? StockRoom { get; set; }
		public List<UnPaidInvoiceDetail>? UnPaidInvoiceDetails { get; set; }
		public List<ImportProductInvoiceDetail>? ImportProductInvoiceDetail { get; set; }


	}
}
