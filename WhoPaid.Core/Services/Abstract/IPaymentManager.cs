using System.Collections.Generic;
using System.Threading.Tasks;
using WhoPaid.Core.Models;

namespace WhoPaid.Core.Services.Abstract
{
    public interface IPaymentManager
    {
        Task<List<TaxPayer>> GetPayers();
        Task UpdatePayer(TaxPayer payer);
        Task AddPayer(TaxPayer payer);
        Task DeletePayer(TaxPayer payer);
    }
}