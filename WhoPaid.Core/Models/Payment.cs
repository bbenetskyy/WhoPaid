using System;

namespace WhoPaid.Core.Models
{
    public class Payment
    {
        public DateTime PayTime { get; set; }
        public bool IsPaid { get; set; }
    }
}