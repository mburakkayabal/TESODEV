using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TESODEV.DataTransferObject
{
    public class AddressDto
    {
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int CityCode { get; set; }

        public CustomerDto Customer { get; set; }
        public OrderDto Order { get; set; }
    }
}
