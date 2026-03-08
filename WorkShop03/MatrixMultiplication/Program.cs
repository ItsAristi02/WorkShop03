using Shared;
string answer = string.Empty;
List<string> options = new List<string> { "si", "no" };

do
{
    int m = ConsoleExtension.GetInt("Ingrese el valor de m: ");
    int n = ConsoleExtension.GetInt("Ingrese el valor de n: ");
    int p = ConsoleExtension.GetInt("Ingrese el valor de p: ");

    if (m <= 0 || n <= 0 || p <= 0)
    {
        Console.WriteLine("Los valores deben ser mayores a 0.");
    }
    else
    {
        int[,] matrixA = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrixA[i, j] = (i + 1) * j;
            }
        }

        int[,] matrixB = new int[n, p];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < p; j++)
            {
                matrixB[i, j] = (j + 1) * i;
            }
        }

        int[,] matrixC = new int[m, p];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < p; j++)
            {
                int sum = 0;
                for (int k = 0; k < n; k++)
                {
                    sum = sum + (matrixA[i, k] * matrixB[k, j]);
                }
                matrixC[i, j] = sum;
            }
        }

        Console.WriteLine("\n*** A ***");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{matrixA[i, j],2}");
            Console.WriteLine();
        }

        Console.WriteLine("\n*** B ***");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < p; j++)
                Console.Write($"{matrixB[i, j],2}");
            Console.WriteLine();
        }

        Console.WriteLine("\n*** C ***");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < p; j++)
                Console.Write($"{matrixC[i, j],3}");
            Console.WriteLine();
        }
    }

    answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options);
    while (string.IsNullOrEmpty(answer))
    {
        Console.WriteLine("Opción no válida, ingrese 'si' o 'no'.");
        answer = ConsoleExtension.GetValidOptions("Desea continuar (si/no): ", options);
    }

    Console.WriteLine();
} while (answer == "si");

Console.WriteLine("¡Gracias por usar el programa!");
