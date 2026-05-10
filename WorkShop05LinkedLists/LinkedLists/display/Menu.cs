using LinkedLists.logic;

namespace LinkedLists.display
{
    class Menu
    {
        private DoublyLinkedList<string> list;

        public Menu()
        {
            list = new DoublyLinkedList<string>();
        }

        public void ShowOptions()
        {
            Console.WriteLine("--- MENU ---");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Show forward");
            Console.WriteLine("3. Show backward");
            Console.WriteLine("4. Sort descending");
            Console.WriteLine("5. Show mode(s)");
            Console.WriteLine("6. Show chart");
            Console.WriteLine("7. Exists");
            Console.WriteLine("8. Delete one occurrence");
            Console.WriteLine("9. Delete all occurrences");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }

        public void Run()
        {
            int option = -1;

            Console.WriteLine("=== WORKSHOP #5 - DOUBLY LINKED LIST ===");
            Console.WriteLine();

            while (option != 0)
            {
                ShowOptions();
                Console.Write("Enter an option: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out option))
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.WriteLine();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        Console.Write("Enter the value to add: ");
                        string value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                        {
                            list.Add(value);
                            Console.WriteLine($"'{value}' added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Value cannot be empty.");
                        }
                        break;

                    case 2:
                        Console.Write("Forward: ");
                        list.ShowForward();
                        break;

                    case 3:
                        Console.Write("Backward: ");
                        list.ShowBackward();
                        break;

                    case 4:
                        list.SortDescending();
                        Console.WriteLine("List sorted descending.");
                        Console.Write("Current list: ");
                        list.ShowForward();
                        break;

                    case 5:
                        list.ShowModes();
                        break;

                    case 6:
                        list.ShowChart();
                        break;

                    case 7:
                        Console.Write("Enter the value to search: ");
                        string search = Console.ReadLine();
                        bool found = list.Exists(search);
                        if (found)
                            Console.WriteLine($"'{search}' EXISTS in the list.");
                        else
                            Console.WriteLine($"'{search}' does NOT exist in the list.");
                        break;

                    case 8:
                        Console.Write("Enter the value to delete (first occurrence): ");
                        string deleteOne = Console.ReadLine();
                        list.DeleteOne(deleteOne);
                        break;

                    case 9:
                        Console.Write("Enter the value to delete (all occurrences): ");
                        string deleteAll = Console.ReadLine();
                        list.DeleteAll(deleteAll);
                        break;

                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
