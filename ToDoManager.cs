
public class ToDoManager
{
    // A collection of to-do entries.
    private List<ToDoEntry> m_ToDoCollection;

    // Constructor.
    public ToDoManager()
    {
        m_ToDoCollection = new List<ToDoEntry>();
    }

    /// <summary>
    /// Display each entry by ID, CheckedState, Title and description.
    /// </summary>
    public void ListAllEntries()
    {

        // Ensures that there is at least one entry in the collection.
        if (m_ToDoCollection.Count == 0)
        {
            Console.WriteLine("There are no entries to list.");
            return;
        }


        // Iterate through the entire collection.
        for (int i = 0; i < m_ToDoCollection.Count; i++)
        {
            Console.WriteLine();
            m_ToDoCollection[i].ToString();
        }

    }

    /// <summary>
    /// Adds a new entry to the collection.
    /// </summary>
    public void Add()
    {

        // Get the user input for title and description.
        Console.WriteLine("Enter a title for the entry: ");
        string? title = Console.ReadLine();
        Console.WriteLine("Enter a description for the entry (optional): ");
        string? description = Console.ReadLine();


        // Create the index that will be used for the ID variable in the entry.
        int index = m_ToDoCollection == null ? 0 : m_ToDoCollection.Count;


        // Create and add the new entry to the collection of entries.
        m_ToDoCollection.Add(new ToDoEntry(index, title, description));

    }

    /// <summary>
    /// Iterates through the entries and provides the user with data of each entry.
    /// </summary>
    public void ListEntries()
    {

        // Ensures that there are entries to iterate through.
        if (m_ToDoCollection.Count == 0)
        {
            Console.WriteLine("The collection currently has zero entries.");
            return;
        }


        // Iterate through each entry and print out the data regarding it.
        foreach (ToDoEntry tde in m_ToDoCollection)
        {
            Console.WriteLine();
            Console.WriteLine(tde.ToString());
        }


        // Wait for input before continuing the code.
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

    }

    /// <summary>
    /// Allows the user to edit the entries using their ID (indicies).
    /// </summary>
    public void Edit()
    {

        int index;

        // Handle potential errors in conversion of the input.
        while (true)
        {

            // Prompt the user for input.
            Console.Write("Select index: ");
            string? input = Console.ReadLine();


            // Check if input is null or empty.
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please enter a valid index.");
                continue;
            }


            // Try to parse the given input as an integer.
            if (!int.TryParse(input, out index))
                break;
            else
                Console.WriteLine("Invalid index, please enter as a integer.");

        }


        // Ensure that the index is not out of bands, if so force it
        // to last value and notify the user.
        if (index > m_ToDoCollection.Count - 1)
        {
            Console.WriteLine("Requested index is out of bounds,");
            Console.WriteLine("setting the index to last valid entry.");
            index = m_ToDoCollection.Count - 1;
        }


        // Handle editing
        /*
        Console.WriteLine(m_ToDoCollection[index].Title);
        Console.ReadLine();
        */


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
        Console.ReadLine();
    }

    /*
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
    */
}

