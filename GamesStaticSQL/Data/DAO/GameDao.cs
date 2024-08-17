using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GamesStaticSQL.Data.DAO
{
    internal class GameDao
    {

        private static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "LOCALHOST";
            builder.InitialCatalog = "videoGames";
            builder.UserID = "sa";
            builder.Password = "1234";
            builder.TrustServerCertificate = true;

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
            return connection;
        }

        public static List<Dictionary<string, object>> GetGamesBetween(int n1, int n2)
        {
            string query = $"select * from games where gameId between {n1} and {n2}";
            List<Dictionary<string, object>> gamesData = new List<Dictionary<string, object>>();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                gamesData = CreateListDictionary(reader);
            }

            return gamesData;
        }
        public static List<Dictionary<string, object>> GetAllGames()
        {
            string query = "select * from games";
            List<Dictionary<string, object>> gamesData = new List<Dictionary<string, object>>();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                
                gamesData = CreateListDictionary(reader);

                return gamesData;
            }
        }

        public static List<Dictionary<string, object>> GetGamesWithGenre(string genre)
        {
            string query = $"select * from games where genreName = '{genre}'";
            List<Dictionary<string, object>> gamesData = new List<Dictionary<string, object>>();
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    gamesData = CreateListDictionary(reader);
                }
                else
                {
                    Console.WriteLine($"No se encontro ningun juego con el genero: {genre}");
                }
            }

            return gamesData;
        }

        public static List<Dictionary<string, object>> GetGameWithName(string name)
        {
            string query = $"select * from games where gameName like '%{name}%'";
            List<Dictionary<string, object>> gamesData = new List<Dictionary<string, object>>();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                    gamesData = CreateListDictionary(reader);  
            }

            return gamesData;
        }


        public static List<Dictionary<string, object>> GetGamesByQuantity(int amount)
        {
            string query = $"select top {amount} * from games";
            List<Dictionary<string, object>> gamesData = new List<Dictionary<string, object>>();

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    gamesData = CreateListDictionary(reader);
                }
            }

            return gamesData;
        }

        private static List<Dictionary<string, object>> CreateListDictionary(SqlDataReader reader)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                Dictionary<string, object> gameData = new Dictionary<string, object>
                {
                    {"gameId", reader.GetValue(0)},
                    {"genreName", reader.GetValue(1)},
                    {"gameName", reader.GetValue(2)},
                };

                list.Add(gameData);
            }

            return list;
        }
    }


}
