
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSSMSystem.Core.Models
{
	public class StockRoom
	{
        public Guid StockRoomId { get; set; }
        public Guid ImportProductInvoiceId { get; set; }
        public Guid ProductId { get; set; }

        public Guid ShelfColumnId { get; set; }

        public Guid SupplierId { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public decimal? ImportPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal? ExportPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ProductionDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiredDate { get; set; }
        public ImportProductInvoice? ImportProductInvoice { get; set; }
        public Product? Product { get; set; }
        public Supplier? Supplier { get; set; }
        public ShelfColumn? ShelfColumn { get; set; }


    }
}
