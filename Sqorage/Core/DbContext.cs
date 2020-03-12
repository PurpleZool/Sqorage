using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqorage.Core
{
    public class DbContext
    {
        private const string DBName = @"D:\Databases\database.sqlite";
        //private const string SQLScript = @"..\..\Util\database.sql";
        private static bool IsDbRecentlyCreated = false;

        public static SQLiteConnection Up()
        {
            // Crea la base de datos y registra usuario solo una vez
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                SQLiteConnection.CreateFile(DBName);
                IsDbRecentlyCreated = true;
            }

            SQLiteConnection dbConnection = GetInstance();
            if (IsDbRecentlyCreated)
            {
                new TableGen(dbConnection).GenerateTables();
            }

            return dbConnection;
        }

        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", DBName)
            );

            db.Open();

            return db;
        }

        public DbContext(string sqliteFilePath)
        {
            DBName = sqliteFilePath;

        }

    }
}
