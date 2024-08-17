using GamesStaticSQL;
using System.Linq.Expressions;

bool next= true;


while (next)
{
    Console.Clear();
    MostrarMenu();
    int selection = Convert.ToInt16(Console.ReadLine());


    switch (selection)
    {

        case 1:
            DB.GetAllGames();
            break;
        case 2:
            Console.WriteLine("Ver juegos entre (1er id): ");
            int n1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Y entre (2do id): ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            DB.GetGamesBetween(n1, n2);
            break;

        case 3:
            Console.WriteLine("Ingrese el genero de los juegos a buscar:");
            string genre= Console.ReadLine();
            DB.GetGamesWithGenre(genre);
            break;

        case 4:
            Console.WriteLine("Ingrese el nombre del juego a buscar:");
            string name = Console.ReadLine();
            DB.GetGameWithName(name);
            break;

        case 5:
            Console.WriteLine("Ingrese la cantidad de juegos a mostrar:");
            int amount = Convert.ToInt32(Console.ReadLine());
            DB.GetGamesByQuantity(amount);
            break;

        default:
            Console.WriteLine("{0} no existe", selection);
            break;
    }
    if (next)
    {
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

void MostrarMenu()
{
    Console.WriteLine("----------------------------");
    Console.WriteLine("Seleccione una operacion:");
    Console.WriteLine("1. Ver listado de los juegos.");
    Console.WriteLine("2. Ver juegos entre...");
    Console.WriteLine("3. Ver juegos por genero.");
    Console.WriteLine("4. Buscar Juego...");
    Console.WriteLine("5. Mostrar Varios Juegos.");
    Console.WriteLine("----------------------------");
}