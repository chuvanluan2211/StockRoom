using System.ComponentModel.DataAnnotations;

namespace SMSSMSystem.Core.Models
{
	public class UnPaidInvoiceDetail
	{
		public Guid InvoiceDetailId { get; set; }
		public Guid UnpaidInvoiceId { get; set; }
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }

		// Định nghĩa khóa ngoại
		public UnPaidInvoice? UnPaidInvoice { get; set; }
		public Product? Product { get; set; }

	}
}
