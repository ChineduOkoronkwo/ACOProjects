using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbServiceAcceptanceTest.Products.Models
{
    public class Currency : BaseEntity
    {
        public string CurrencyCode { get; set; } = default!;
        public Country Country { get; set; } = default!;
    }
}