using Sqorage.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqorage.Core
{
    public class ApiService
    {
        public static IEnumerable<User> GetAll()
        {
            var result = new List<User>();

            using (var ctx = DbContext.GetInstance())
            {
                var query = "SELECT * FROM Users";

                using (var command = new SQLiteCommand(query, ctx))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new User
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Lastname = reader["Lastname"].ToString(),
                                Birthday = Convert.ToDateTime(reader["Birthday"]),
                            });
                        }
                    }
                }
            }

            return result;
        }
    }
}
