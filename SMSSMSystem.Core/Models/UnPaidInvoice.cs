using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSMSystem.Core.Models
{
	public class UnPaidInvoice
	{
		public Guid UnPaidInvoiceId { get; set; }
		public string? Phone { get; set; }
		[Required(ErrorMessage = "UnPaidInvoiceName is required.")]
		[StringLength(50, ErrorMessage = "UnPaidInvoiceName cannot exceed 50 characters.")]
		public string? UnPaidInvoiceName { get; set; }
		[DataType(DataType.Date)]
		public DateTime? OrderDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? PaymentDate { get; set; }

		[DataType(DataType.Currency)]
		public decimal? TotalMoney { get; set; }

		public bool Status { get; set; }
		public List<UnPaidInvoiceDetail>? UnPaidInvoiceDetails { get; set; }
	}
}
