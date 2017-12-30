using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    [Table("Country")]
    public class Country : BaseEntity
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
