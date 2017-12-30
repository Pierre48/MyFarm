using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    [Table("Supplier")]
    public class Supplier : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
