using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSMSystem.Core.Models
{
	public class SupplierCriteria
	{
		public Guid SupplierCriteriaId { get; set; }
		public Guid SupplierId { get; set; }
		public int DeliveryProgress { get; set; }
		public int ProductQuality { get; set; }
		public int DeliveryAttitude { get; set; }

		// Định nghĩa khóa ngoại
		public Supplier? Supplier { get; set; }
	}
}
