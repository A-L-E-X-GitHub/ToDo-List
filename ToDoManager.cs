
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
    /// Adds a new entry to the collection.
    /// </summary>
    public void Add()
    {

        // Get the user input for title.
        Console.WriteLine("Enter a title for the entry: ");
        string? title = Console.ReadLine();

        // #TODO: Add error checking incase of stoopid user on title input.

        // Create the index that will be used for the ID variable in the entry.
        int index = m_ToDoCollection == null ? 0 : m_ToDoCollection.Count;

        // Create and add the new entry to the collection of entries.
        m_ToDoCollection.Add(new ToDoEntry(index, title));

        Console.WriteLine(m_ToDoCollection[index].ToString());

        WaitForKeyPress();

    }

    /// <summary>
    /// Iterates through each entry in the collection and output the data regarding it.
    /// </summary>
    public void ListEntries()
    {

        // Ensures that there are entries to iterate through.
        if (m_ToDoCollection.Count == 0)
        {
            Console.WriteLine("The collection currently has zero entries.");
            WaitForKeyPress();
            return;
        }


        // Iterate through each entry and print out the data regarding it.
        foreach (ToDoEntry tde in m_ToDoCollection)
        {
            Console.WriteLine(tde.ToString());
        }


        // Wait for input before continuing the code.
        WaitForKeyPress();

    }

    /// <summary>
    /// Allows the user to edit the entries using their ID (indicies).
    /// </summary>
    public void Edit()
    {

        // Gets a valid index from the user.
        int index = GetValidIndex();

        // Handle editing
        /*
        Console.WriteLine(m_ToDoCollection[index].Title);
        Console.ReadLine();
        */

    }
    /// <summary>
    /// Allows for removal of a entry at a specific index.
    /// </summary>
    public void Remove()
    {

        // Gets a valid index from the user.
        int index = GetValidIndex();

        // Remove the entry at the selected index and notify the user.
        m_ToDoCollection.RemoveAt(index);
        Console.WriteLine($"Removed entry at index: {index}");

        UpdateEntryIDS();

        WaitForKeyPress();
    }

    // TODO: This does not work at all, it is not showing up in the console
    // when it is supposed to, future me, fix plez.
    private void UpdateEntryIDS(int startIndex = 0)
    {
        for (int i = startIndex; i < m_ToDoCollection.Count; i++)
        {
            m_ToDoCollection[i].ToString();
        }

    }

    /// <summary>
    /// Awaits for the users to enter any input before continuing.
    /// </summary>
    private void WaitForKeyPress()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }

    /// <summary>
    /// Prompts the user to enter a valid integer index and ensures it is within the bounds of the to-do collection.
    /// If out of bounds, defaults to the last entry.
    /// </summary>
    /// <returns>A valid index within the to-do collection.</returns>
    private int GetValidIndex()
    {
        int index;

        while (true)
        {
            // Prompt the user for a selection index.
            Console.Write("Select index: ");
            string? input = Console.ReadLine();

            // Check if input is null or empty
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please enter a valid index.");
                continue;
            }

            // Try to parse the input as an integer, break the loop if valid integer is found.
            if (int.TryParse(input, out index))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid index, please enter an integer.");
            }
        }

        // Ensures that the index is within a valid range of the collection size.
        if (index > m_ToDoCollection.Count - 1)
        {
            Console.WriteLine("Specified index is out of bounds, setting it to last entry in the collection.");
            index = m_ToDoCollection.Count - 1;
        }

        return index;
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

