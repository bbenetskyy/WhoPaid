using System.Collections.Generic;
using System.Text;

namespace WhoPaid.Core.Models
{
    public class TaxPayer
    {
        public string FullName { get; set; }
        public int MonthRate { get; set; }
        public List<Payment> PaymentHistory { get; set; }
    }
}
