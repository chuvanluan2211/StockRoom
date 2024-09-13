using System.ComponentModel.DataAnnotations;

namespace SMSSMSystem.Core.Models
{
	public class Supplier
	{
		public Guid SupplierId { get; set; }
		[Required(ErrorMessage = "SupplierName is required.")]
		[StringLength(50, ErrorMessage = "SupplierName cannot exceed 50 characters.")]
		public string? SupplierName { get; set; }
		[Required(ErrorMessage = "Phone is required.")]
		[StringLength(15, ErrorMessage = "Phone cannot exceed 15 characters.")]
		public string? Phone { get; set; }
		[StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
		public string? Address { get; set; }
		public List<ImportProductInvoice>? ImportProductInvoices { get; set; }
		public List<SupplierCriteria>? SupplierCriterias { get; set; }
		public List<StockRoom>? StockRoom { get; set; }

	}
}
