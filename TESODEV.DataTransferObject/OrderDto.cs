using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TESODEV.DataTransferObject
{
    public class OrderDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        public AddressDto Address { get; set; }
        public ProductDto Product { get; set; }
        public CustomerDto Customer { get; set; }
    }
}