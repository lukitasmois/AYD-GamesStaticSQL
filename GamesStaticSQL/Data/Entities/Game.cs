using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GamesStaticSQL.Data.Entities
{
    internal class Game
    {
        public int GameId { get; set; }
        public string GenreName { get; set; }
        public string GameName { get; set; }

        public Game(int gameId, string genreName, string gameName)
        {
            GameId = gameId;
            GenreName = genreName;
            GameName = gameName;
        }

        public void showGame()
        {
            Console.WriteLine($"[Game Id={GameId}, Name={GameName}]");
        }
    }
}
