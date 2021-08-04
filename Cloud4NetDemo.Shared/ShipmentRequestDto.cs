using System;
using System.ComponentModel.DataAnnotations;

namespace Cloud4NetDemo.Shared
{
    public class ShipmentRequestDto
    {
        [Required]
        public string PackageId { get; set; }
        [Required]
        public string CustomerId { get; set; }
    }
}