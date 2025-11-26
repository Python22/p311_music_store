using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace p311_music_store
{
    internal class DataAccess
    {
        private string _database_name;
        private string _connection_string;

        public DataAccess(string database_name)
        {
            _database_name = database_name;
            _connection_string = new SqlConnectionStringBuilder { 
                DataSource = "192.168.65.100",
                InitialCatalog = _database_name,
                UserID = "Teacher",
                Password = "shag39"
            }.ConnectionString;
        }


    }
}
