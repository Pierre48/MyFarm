using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyFarm.Core.Entities
{
    [Table("Address")]
    public class Address : BaseEntity
    {
        [Required]
        public Country Country { get; set; }
        [MaxLength(100)]
        [Required]
        public string FullName { get; set; }
        [MaxLength(100)]
        [Required]
        public string StreetAddress { get; set; }
        [MaxLength(100)]
        public string StreetComplement { get; set; }
        [MaxLength(100)]
        [Required]
        public string City { get; set; }
        [MaxLength(100)]
        public string State { get; set; }
        [MaxLength(10)]
        [Required]
        public string ZipCode { get; set; }
    }
}
