namespace SMSSMSystem.Core.Models
{
	public class ImportProductInvoice
	{
		public Guid ImportProductInvoiceId { get; set; }
		public Guid SupplierId { get; set; }
		public decimal? TotalMoney { get; set; }
		public bool Status { get; set; }

		// Định nghĩa khóa ngoại
		public Supplier Supplier { get; set; }
		public List<ImportProductInvoiceDetail> InvoiceDetails { get; set; }
		public List<StockRoom>? StockRoom { get; set; }

	}
}
