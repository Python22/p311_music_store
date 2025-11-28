using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

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

        public void add_genre(string name)
        {
            var conn = new SqlConnection(_connection_string);
            conn.Open();
            string query = $@"
                INSERT INTO dbo.Genres
                (name)                
                VALUES
                (@name)
            ";
            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(
                $"Жанр '{name}' успешно добавлен",
                "Ок",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }

        public void add_group(string name, string peoples)
        {
            var conn = new SqlConnection(_connection_string);
            conn.Open();
            string query = $@"
                INSERT INTO dbo.Groups
                (name, peoples)                
                VALUES
                (@name, @peoples)
            ";
            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@peoples", peoples);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(
                $"Группа '{name}' успешна добавлена",
                "Ок",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }

        public List<string> get_group_names()
        {
            var conn = new SqlConnection(_connection_string);
            conn.Open();
            string query = $@"
                SELECT id, name
                FROM dbo.Groups
                ORDER BY name
            ";
            List<string> result_string = new List<string>();
            var cmd = new SqlCommand(query, conn);
            var sql_result = cmd.ExecuteReader();
            while (sql_result.Read())
            {
                result_string.Add($"{sql_result.GetInt32(0)}; {sql_result.GetString(1)}");
            }
            return result_string; 
        }

        public void add_music(string title, string music_text, string group_id, string album_id)
        {
            var conn = new SqlConnection(_connection_string);
            conn.Open();
            string album_id_query_add = album_id != "" ? ", album_id" : "";
            string need_album = album_id != "" ? ",@album_id" : "";
            string query = $@"
                INSERT INTO dbo.Music
                (title, music_text, group_id{album_id_query_add})                
                VALUES
                (@title, @music_text, @group_id{need_album})
            ";
            var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@music_text", music_text);
            cmd.Parameters.AddWithValue("@group_id", Convert.ToInt32(group_id));
            if (need_album != "")
            {
                cmd.Parameters.AddWithValue("@album_id", Convert.ToInt32(album_id));
            }
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(
                $"Музыка '{title}' успешна добавлена",
                "Ок",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
    }
}
