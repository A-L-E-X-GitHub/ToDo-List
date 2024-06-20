public class ToDoEntry
{
    // Variable memebers.
    private int m_ID;
    private string? m_Title;
    private bool m_Checked;

    // Properties.
    public int ID { get; set; }
    public string Title { get; set; }
    public bool Checked { get; set; }

    // Constructor
    public ToDoEntry(int id, string title)
    {
        m_ID = id;
        Title = title;
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
        string isChecked = Checked ? "[x]" : "[ ]";
        return isChecked + " #" + m_ID.ToString("00") + ": " + Title;
    }

}