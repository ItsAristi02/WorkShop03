using Shared;
string answer = string.Empty;
List<string> options = new List<string> { "si", "no" };

do
{
    int size = ConsoleExtension.GetInt("Ingrese el tamaño del rombo: ");

    if (size <= 0 || size % 2 == 0)
    {
        Console.WriteLine("El tamaño debe ser un número impar positivo.");
    }
    else
    {
        int middle = size / 2;

        for (int i = 0; i <= middle; i++)
        {
            string line = "";

            for (int s = 0; s < middle - i; s++)
            {
                line = line + " ";
            }

            if (i == 0)
            {
                line = line + "#";
            }
            else
            {
                line = line + "#";
                for (int h = 0; h < i * 2 - 1; h++)
                {
                    line = line + " ";
                }
                line = line + "#";
            }

            Console.WriteLine(line);
        }

        for (int i = middle - 1; i >= 0; i--)
        {
            string line = "";

            for (int s = 0; s < middle - i; s++)
            {
                line = line + " ";
            }

            if (i == 0)
            {
                line = line + "#";
            }
            else
            {
                line = line + "#";
                for (int h = 0; h < i * 2 - 1; h++)
                {
                    line = line + " ";
                }
                line = line + "#";
            }

            Console.WriteLine(line);
        }
    }

    answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options) ?? string.Empty;
    while (string.IsNullOrEmpty(answer))
    {
        Console.WriteLine("Opción no válida, ingrese 'si' o 'no'.");
        answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options) ?? string.Empty;
    }

    Console.WriteLine();
} while (answer == "si");

Console.WriteLine("¡Gracias por usar el programa!");