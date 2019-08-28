using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using WhoPaid.Core.Services.Abstract;

namespace WhoPaid.Core.Services
{
    // ReSharper disable once InconsistentNaming
    public class SQLiteDatabase : IDatabase
    {
        public SQLiteConnection CreateConnection()
        {
            var db = "WhoPaid.db";
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(docFolder, db);

            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}