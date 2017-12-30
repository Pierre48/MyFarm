using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFarm.Core.Entities
{
    [Table("InvoiceLine")]
    public class InvoiceLine : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }
        [Required]
        public float AmountWithoutTax { get; set; }
        [Required]
        public float AmountWithTax { get; set; }
    }
}