using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesStaticSQL.Data;
using GamesStaticSQL.Data.DAO;

namespace GamesStaticSQL
{
    internal class Menu
    {
        public static void Option1()
        {
            GameRepository.GetAllGames();
        }

        public static void Option2()
        {
            int n1 = ValidateIntInput("Ver juegos entre (1er id): ");
            int n2 = ValidateIntInput("Y entre (2do id): ");
            Console.WriteLine("Ver juegos entre (1er id): ");
            GameRepository.GetGamesBetween(n1, n2);
        }

        public static void Option3()
        {
            Console.WriteLine("Ingrese el genero de los juegos a buscar:");
            string genre = Console.ReadLine();
            GameRepository.GetGamesWithGenre(genre);
        }

        public static void Option4()
        {
            Console.WriteLine("Ingrese el nombre del juego a buscar:");
            string name = Console.ReadLine();
            GameRepository.GetGameWithName(name);
        }

        public static void Option5()
        {
            Console.WriteLine();
            int amount = ValidateIntInput("Ingrese la cantidad de juegos a mostrar:");
            GameRepository.GetGamesByQuantity(amount);
        }

        private static int ValidateIntInput(string prompt)
        {
            int result;

            while(true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result) && result > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            }

            return result;
        }

    }
}
