using GamesStaticSQL.Data.DAO;
using GamesStaticSQL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GamesStaticSQL.Data
{
    internal class GameRepository
    {
        public static List<Game> GetAllGames()
        {
            List<Dictionary<string, object>> gamesData = GameDao.GetAllGames();
            List<Game> games = CreateListGames(gamesData);

            if (games.Any())
            {
                foreach (Game game in games)
                {
                    game.showGame();
                }
            }
            else
            {
                Console.WriteLine("No existen juegos en la base de datos.");
            }

            return games;
        }

        public static List<Game> GetGamesBetween(int n1, int n2)
        {
            List<Dictionary<string, object>> gamesData = GameDao.GetGamesBetween(n1, n2);
            List<Game> games = CreateListGames(gamesData);

            if(games.Any())
            {
                foreach (Game game in games)
                {
                    game.showGame();
                }
            }
            else
            {
                Console.WriteLine($"No existen juegos entre {n1} y {n2}");
            }

            return games;
        }

        public static List<Game> GetGamesWithGenre(string genre)
        {
            
            List<Dictionary<string, object>> gamesData = GameDao.GetGamesWithGenre(genre);
            List<Game> games = CreateListGames(gamesData);

            if (games.Any())
            {
                foreach (Game game in games)
                {
                    game.showGame();
                }
            }
            else
            {
                Console.WriteLine($"No existen juegos con el genero: {genre}");
            }

            return games;
        }

        public static List<Game> GetGameWithName(string name)
        {
            List<Dictionary<string, object>> gamesData = GameDao.GetGameWithName(name);
            List<Game> games = CreateListGames(gamesData);

           if(games.Any())
            {
                foreach (Game game in games)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Coincidencias con {name}:");
                    game.showGame();
                    Console.WriteLine("----------------------------");
                }
            }
            else
            {
                Console.WriteLine($"No se encontraron juegos que el nombre coincida con: {name}");
            }

            return games;
        }

        public static List<Game> GetGamesByQuantity(int amount)
        {
            List<Dictionary<string, object>> gamesData = GameDao.GetGamesByQuantity(amount);
            List<Game> games = CreateListGames(gamesData);

            if (games.Any())
            {
                foreach (Game game in games)
                {
                    game.showGame();
                }
            }
            else
            {
                Console.WriteLine("No existen juegos en la base de datos.");
            }
            return games;

        }

        private static List<Game> CreateListGames(List<Dictionary<string, object>> gamesData)
        {
            List<Game> games = new List<Game>();

            foreach (var gameData in gamesData)
            {
                int gameId = Convert.ToInt32(gameData["gameId"]);
                string genreName = Convert.ToString(gameData["genreName"]);
                string gameName = Convert.ToString(gameData["gameName"]);

                games.Add(new Game(gameId, genreName, gameName));
            }

            return games;


        }
    }
}
