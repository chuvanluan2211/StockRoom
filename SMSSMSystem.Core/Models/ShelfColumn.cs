using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSSMSystem.Core.Models
{
	public class ShelfColumn
	{
        public Guid ShelfColumnId { get; set; }
        public Guid ShelfRowId { get; set; }

        [Required(ErrorMessage = "ShelfColumnName is required.")]
        [StringLength(50, ErrorMessage = "ShelfColumnName cannot exceed 50 characters.")]
        public string? ShelfColumnName { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public ShelfRow? ShelfRow { get; set; }

        public List<StockRoom>? StockRoom { get; set; }


    }
}
