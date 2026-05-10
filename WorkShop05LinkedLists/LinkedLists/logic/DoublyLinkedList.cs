
namespace LinkedLists.logic
{
    class DoublyLinkedList<T> where T : IComparable<T>
    {
        private Node<T> head;

        public DoublyLinkedList()
        {
            head = null;
        }

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null || data.CompareTo(head.Data) <= 0)
            {
                newNode.Next = head;
                if (head != null) head.Previous = newNode;
                head = newNode;
                return;
            }

            Node<T> current = head;
            while (current.Next != null && current.Next.Data.CompareTo(data) <= 0)
                current = current.Next;

            newNode.Next = current.Next;
            newNode.Previous = current;
            if (current.Next != null) current.Next.Previous = newNode;
            current.Next = newNode;
        }

        public void ShowForward()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data);
                if (current.Next != null)
                    Console.Write(" -> ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void ShowBackward()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            while (current != null)
            {
                Console.Write(current.Data);
                if (current.Previous != null)
                    Console.Write(" -> ");
                current = current.Previous;
            }
            Console.WriteLine();
        }

        public void SortDescending()
        {
            if (head == null || head.Next == null)
                return;

            Node<T> current = head;
            Node<T> temp = null;

            while (current != null)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                current = current.Previous;
            }

            if (temp != null)
            {
                head = temp.Previous;
            }
        }

        public void ShowModes()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            int total = CountElements();
            T[] values = new T[total];
            int[] counts = new int[total];
            int uniqueCount = 0;

            Node<T> current = head;
            while (current != null)
            {
                bool found = false;
                for (int i = 0; i < uniqueCount; i++)
                {
                    if (values[i].CompareTo(current.Data) == 0)
                    {
                        counts[i]++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    values[uniqueCount] = current.Data;
                    counts[uniqueCount] = 1;
                    uniqueCount++;
                }

                current = current.Next;
            }

            int maxCount = 0;
            for (int i = 0; i < uniqueCount; i++)
            {
                if (counts[i] > maxCount)
                    maxCount = counts[i];
            }

            if (maxCount == 1)
            {
                Console.WriteLine("No mode found (all elements appear only once).");
                return;
            }

            Console.Write("Mode(s): ");
            bool first = true;
            for (int i = 0; i < uniqueCount; i++)
            {
                if (counts[i] == maxCount)
                {
                    if (!first)
                        Console.Write(", ");
                    Console.Write(values[i]);
                    first = false;
                }
            }
            Console.WriteLine($" (appears {maxCount} times)");
        }

        public void ShowChart()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            int total = CountElements();
            T[] values = new T[total];
            int[] counts = new int[total];
            int uniqueCount = 0;

            Node<T> current = head;
            while (current != null)
            {
                bool found = false;
                for (int i = 0; i < uniqueCount; i++)
                {
                    if (values[i].CompareTo(current.Data) == 0)
                    {
                        counts[i]++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    values[uniqueCount] = current.Data;
                    counts[uniqueCount] = 1;
                    uniqueCount++;
                }

                current = current.Next;
            }

            Console.WriteLine("--- CHART ---");
            for (int i = 0; i < uniqueCount; i++)
            {
                Console.Write($"{values[i]}\t");
                for (int j = 0; j < counts[i]; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public bool Exists(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.CompareTo(data) == 0)
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void DeleteOne(T data)
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;

                    Console.WriteLine($"'{data}' deleted (first occurrence).");
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine($"'{data}' was not found in the list.");
        }

        public void DeleteAll(T data)
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            int counter = 0;
            Node<T> current = head;

            while (current != null)
            {
                Node<T> next = current.Next;

                if (current.Data.CompareTo(data) == 0)
                {
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;

                    counter++;
                }

                current = next;
            }

            if (counter > 0)
                Console.WriteLine($"Deleted {counter} occurrence(s) of '{data}'.");
            else
                Console.WriteLine($"'{data}' was not found in the list.");
        }

        private int CountElements()
        {
            int count = 0;
            Node<T> current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
