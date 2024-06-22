
public class ToDoManager
{
    // A collection of to-do entries.
    private List<ToDoEntry> m_ToDoCollection;

    // Constructor(s).
    public ToDoManager()
    {
        m_ToDoCollection = new List<ToDoEntry>();
    }

    /// <summary>
    /// Adds a new entry to the collection based on prompted input(s).
    /// </summary>
    public void Add()
    {

        string? title;

        // Prompt the user for a title and handle potential empty string/null error.
        while (true)
        {
            Console.WriteLine("Enter a title for the entry: ");
            title = Console.ReadLine();
            if (!string.IsNullOrEmpty(title)) break;
            Console.WriteLine("Title is null or empty, try again.");
        }

        // Create the index that will be used for the ID variable in the entry.
        int index = m_ToDoCollection == null ? 0 : m_ToDoCollection.Count;

        // Create and add the new entry to the collection of entries.
        m_ToDoCollection.Add(new ToDoEntry(index, title));

        Console.WriteLine(m_ToDoCollection[index].ToString());

        WaitForKeyPress();

    }

    /// <summary>
    /// Seconadry Add function for adding a entry directly programmatically.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="title"></param>
    public void Add(int index, string title)
    {
        m_ToDoCollection.Add(new ToDoEntry(index, title));
    }
    /// <summary>
    /// Calls the function to show all entries and awaits key input.
    /// </summary>
    public void ListEntries()
    {

        // Display all the entries in the collection.
        ListAllEntries();

        // Wait for input before continuing the code.
        WaitForKeyPress();

    }

    /// <summary>
    /// Allows the user to edit the entries using their ID (indicies).
    /// </summary>
    public void Edit()
    {

        // Gets a valid index from the user.
        int entryID = GetValidEntryID() - 1;

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

        // Display the entries to the user.
        Console.WriteLine();
        ListAllEntries();

        Console.WriteLine();
        // Gets a valid index from the user.
        int entryID = GetValidEntryID();

        // Remove the entry at the selected index and notify the user.
        Console.WriteLine($"Removed entry \"#{m_ToDoCollection[entryID-1].DisplayID.ToString("00")} {m_ToDoCollection[entryID-1].Title}\"");
        //Console.WriteLine($"Removed entry at index: {entryID}");
        m_ToDoCollection.RemoveAt(entryID - 1);

        // Update the id value of the entries that come after the removed entry.
        UpdateEntryID(entryID - 1);

        WaitForKeyPress();
    }

    /// <summary>
    /// Updates the entries that require updating after changes and/or removal in the collection
    /// </summary>
    /// <param name="startIndex"></param>
    private void UpdateEntryID(int startIndex = 0)
    {
        for (int i = startIndex; i < m_ToDoCollection.Count; i++)
        {
            m_ToDoCollection[i].ID = i;
        }
    }

    /// <summary>
    /// Iterates through each entry in the collection and prints it to the console.
    /// </summary>
    private void ListAllEntries()
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
    private int GetValidEntryID()
    {
        int entryID;

        while (true)
        {
            // Prompt the user for a selection id.
            Console.Write("Select entry by id: ");
            string? input = Console.ReadLine();

            // Check if input is null or empty
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please enter a valid index.");
                continue;
            }

            // Try to parse the input as an integer, break the loop if valid integer is found.
            if (int.TryParse(input, out entryID))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid entry id, please try again.");
            }
        }

        // Ensures that the index is within a valid range of the collection size.
        if (entryID > m_ToDoCollection.Count)
        {
            Console.WriteLine("Specified entry id is out of bounds, defaulting to the last entry.");
            entryID = m_ToDoCollection.Count;
        }
        else if (entryID == 0)
        {
            Console.WriteLine("An entry id cannot be set to 0, defaulting to the first entry.");
            entryID = 1;
        }

        return entryID;
    }

}

