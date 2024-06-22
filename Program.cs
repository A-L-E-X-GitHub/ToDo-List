namespace ToDoList
{
    class Program
    {

        static void Main(string[] args)
        {

            ToDoManager toDoManager = new ToDoManager();
            bool programState = true;

            // REMOVE AFTER TESTING
            toDoManager.Add(0, "A");
            toDoManager.Add(1, "B");
            toDoManager.Add(2, "C");
            toDoManager.Add(3, "D");

            // Keep looping the code while programState remains true.
            while (programState)
            {
                // Clear the console for a clean window and print
                // instructions on how to navigate the application.
                Console.Clear();
                Console.WriteLine("Basic To-do list");
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Add a new entry");
                Console.WriteLine("2. Edit entry by id");
                Console.WriteLine("3. List current entries");
                Console.WriteLine("4. Remove entry by id");
                Console.WriteLine("5. Exit application");
                Console.WriteLine();
                Console.Write("Input: ");
                string? input = Console.ReadLine();

                // Determine which action to take based on the user input.
                switch (input)
                {
                    case "1":
                        toDoManager.Add();
                        break;

                    case "2":
                        toDoManager.Edit();
                        break;

                    case "3":
                        toDoManager.ListEntries();
                        break;

                    case "4":
                        toDoManager.Remove();
                        break;

                    case "5":
                        programState = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;

                }
            }
        }
    }
}

