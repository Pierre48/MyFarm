using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyFarm.Core.Entities
{
    [Table("Farm")]
    public class Farm : BaseEntity
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
