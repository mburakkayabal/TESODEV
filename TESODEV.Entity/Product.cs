using System;
using System.Collections.Generic;
using System.Text;

namespace TESODEV.Entity
{
    public partial class Product
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }

        public virtual Order Order { get; set; }
    }
}
