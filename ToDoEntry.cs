public class ToDoEntry
{
    // Variable memebers.
    private int m_ID;
    private string? m_Title;
    private string? m_Description;
    private bool m_Checked;

    // Properties.
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Checked { get; set; }

    // Constructor
    public ToDoEntry(int id, string title, string description)
    {
        m_ID = id;
        Title = title;
        Description = description;
        Checked = false;
    }

    // Public functions

    /// <summary>
    /// Overrides the .ToString() to instead give a string
    /// that contains the data of the entry.
    /// </summary>
    /// <returns>A formatted string</returns>
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