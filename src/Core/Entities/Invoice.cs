using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyFarm.Core.Entities
{
    [Table("Invoice")]
    public class Invoice : BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Supplier Supplier { get; set; }
        [Required]
        public Farm Farm { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }
    }
}
