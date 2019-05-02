using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqorage.Core
{
    class TableGen
    {
        SQLiteConnection dbConnection;
        private bool isOpen { get { return dbConnection.State != System.Data.ConnectionState.Closed; } }


        public TableGen(SQLiteConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            
        }

        public void GenerateTables()
        {
            if (!isOpen) dbConnection.Open();
            CreateMainTable();
        }

        private void CreateMainTable()
        {
            string sql = "CREATE TABLE main (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            sql = "INSERT INTO main (name, score) values ('Me', 9001)";
            command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }


    }
}
