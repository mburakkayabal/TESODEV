using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TESODEV.DataTransferObject
{
    public class CustomerDto
    {
        public CustomerDto()
        {
            Orders = new List<OrderDto>();
        }

        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        public AddressDto Address { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}
