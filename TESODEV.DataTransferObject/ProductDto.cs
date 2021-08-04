using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TESODEV.DataTransferObject
{
    public class ProductDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Name { get; set; }

        public OrderDto Order { get; set; }
    }
}
