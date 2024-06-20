



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Reflection;

namespace ToDoList
{
    class Program
    {


        static void Main(string[] args)
        {

            ToDoManager toDoManager = new ToDoManager();
            bool programState = true;

            while (programState)
            {
                Console.Clear();
                Console.WriteLine("Basic To-do list");
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Add a new entry");
                Console.WriteLine("2. Edit entry by index");
                Console.WriteLine("3. List current entries");
                Console.WriteLine("4. Remove entry by index");
                string? input = Console.ReadLine();



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

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;

                }

            }

        }

    }

    public class ToDoManager
    {
        private List<ToDoEntry> m_ToDoCollection;

        public ToDoManager()
        {
            m_ToDoCollection = new List<ToDoEntry>();
        }

        public void ListAllEntries()
        {
            if (m_ToDoCollection.Count == 0)
            {
                Console.WriteLine("There are no entries to list.");
                return;
            }

            for (int i = 0; i < m_ToDoCollection.Count; i++)
            {
                Console.WriteLine();
                m_ToDoCollection[i].ToString();
            }
        }


        public void Add()
        {

            Console.WriteLine("Enter a title: ");
            string? title = Console.ReadLine();
            Console.WriteLine("Enter a description (optional): ");
            string? description = Console.ReadLine();

            int index = 0;

            if (m_ToDoCollection != null)
            {
                index = m_ToDoCollection.Count;
            }

            ToDoEntry toDoEntry = new ToDoEntry(index, title, description);

            m_ToDoCollection.Add(toDoEntry);
        }
        public void ListEntries()
        {
            foreach (ToDoEntry tde in m_ToDoCollection)
            {
                Console.WriteLine();
                Console.WriteLine(tde.ToString());
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        public void Edit()
        {
            Console.Write("Select index: ");
            string? input = Console.ReadLine();
            int index;
            while (true)
            {
                try
                {
                    index = int.Parse(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid index, please enter as a integer.");
                }
            }

            if (index > m_ToDoCollection.Count - 1)
            {
                Console.WriteLine("Index specified is out of bounds.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine(m_ToDoCollection[index].Title);
            Console.ReadLine();


        }
        public void Remove()
        {
            Console.Write("Select index: ");
            string? input = Console.ReadLine();
            int index;
            while (true)
            {
                try
                {
                    index = int.Parse(input);
                    break;
                }
                // Appears to spam when error occurs, look into it.
                catch (FormatException)
                {
                    Console.WriteLine("Invalid index, please enter as a integer.");
                }
            }

            if (index > m_ToDoCollection.Count - 1)
            {
                Console.WriteLine("Index specified is out of bounds.");
                Console.ReadLine();
                return;
            }

            m_ToDoCollection.RemoveAt(index);
            Console.WriteLine($"Removed entry at index: {index}");
            ReCalculatedIndicies();
            Console.ReadLine();
        }


        private void ReCalculatedIndicies(int startIndex = 0)
        {
            for (int i = startIndex; i < m_ToDoCollection.Count; i++)
            {
                Console.WriteLine($"{m_ToDoCollection[i].ID} - {i}");
                if (m_ToDoCollection[i].ID != i)
                {
                    m_ToDoCollection[i].ID = i;
                }
            }
        }
    }

    public class ToDoEntry
    {

        private int m_ID;
        private string? m_Title;
        private string? m_Description;
        private bool m_Checked;

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }

        public ToDoEntry(int id, string title, string description)
        {
            m_ID = id;
            Title = title;
            Description = description;
            Checked = false;
        }

        public override string ToString()
        {
            string text;
            string isChecked = Checked ? "[x]" : "[ ]";
            text = "ID" + m_ID + " " + isChecked + Environment.NewLine;
            text += "Title: " + Title + Environment.NewLine;
            text += "Description: " + Description;

            return text;
        }

    }

}