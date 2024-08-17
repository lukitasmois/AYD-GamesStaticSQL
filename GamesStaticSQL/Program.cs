using GamesStaticSQL;
using System.ComponentModel.Design;
using System.Linq.Expressions;

bool next= true;


while (next)
{
    Console.Clear();
    MostrarMenu();
    string input = Console.ReadLine();
    int selection;


    if (int.TryParse(input, out selection))
    {
        switch (selection)
        {

            case 1:
                Menu.Option1();
                break;
            case 2:
                Menu.Option2();
                break;

            case 3:
                Menu.Option3();
                break;

            case 4:
                Menu.Option4();
                break;

            case 5:
                Menu.Option5();
                break;

            default:
                Console.WriteLine("La operacion: {0}, no existe", selection);
                break;
        }
    }
    else
    {
        Console.WriteLine("Por favor, ingrese un número válido.");
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