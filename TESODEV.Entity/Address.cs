using System;
using System.Collections.Generic;
using System.Text;

namespace TESODEV.Entity
{
    public partial class Address
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CityCode { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
