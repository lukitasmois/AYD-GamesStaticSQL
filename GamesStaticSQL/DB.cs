using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GamesStaticSQL
{
    internal class DB
    {
        private static SqlConnection _connection;

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

        public static void GetGamesBetween(int n1, int n2)
        {
            string query = $"select * from games where gameId between {n1} and {n2}";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShowGameFromDB(reader);
                }
            }
        }
        public static void GetAllGames()
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT * FROM games";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShowGameFromDB(reader);
                }


            }
        }

        public static void GetGamesWithGenre(string genre)
        {
            string query = $"select * from games where genreName = '{genre}'";
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ShowGameFromDB(reader);
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontro ningun juego con el genero: {genre}");
                }
            }
        }

        public static void GetGameWithName(string name)
        {
            string query = $"select * from games where gameName like '%{name}%'";

            using(SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Coincidencias con {name}:");
                    while (reader.Read())
                    {
                        
                        ShowGameFromDB(reader);
                    }
                    Console.WriteLine("----------------------------");
                }
                else
                {
                    Console.WriteLine($"No se encontro ningun juego con el nombre {name}");
                }
            }
        }


        public static void GetGamesByQuantity(int amount)
        {
            string query = $"select top {amount} * from games";

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ShowGameFromDB(reader);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No existen registros en la base de datos.");
                    }
                }
            }
        }

        private static void ShowGameFromDB(SqlDataReader reader)
        {
            Console.WriteLine($"[Game Id={reader.GetValue(0)}, Name={reader.GetValue(2)}]");
        }
    }


}
