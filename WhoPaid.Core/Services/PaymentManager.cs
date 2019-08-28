using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WhoPaid.Core.Models;
using WhoPaid.Core.Services.Abstract;

namespace WhoPaid.Core.Services
{
    class PaymentManager : IPaymentManager
    {
        private readonly SQLiteConnection _connection;

        public PaymentManager(IDatabase database)
        {
            _connection = database.CreateConnection();
        }

        public Task<List<TaxPayer>> GetPayers()
        {
            return Task.FromResult(_connection.Table<TaxPayer>().ToList());
        }

        public Task UpdatePayer(TaxPayer payer)
        {
            _connection.Update(payer);
            return Task.CompletedTask;
        }

        public Task AddPayer(TaxPayer payer)
        {
            _connection.Insert(payer);
            return Task.CompletedTask;
        }

        public Task DeletePayer(TaxPayer payer)
        {
            _connection.Delete(payer);
            return Task.CompletedTask;
        }
    }
}
