using System;
using System.Text;
using SQLite;

namespace WhoPaid.Core.Services.Abstract
{
    public interface IDatabase
    {
        SQLiteConnection CreateConnection();
    }
}
