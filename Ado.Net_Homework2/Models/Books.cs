namespace Ado.Net_Homework2.Models;

public class Books
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public int? Pages { get; set; }
    public int? YearPress { get; set; }
    public string Comment { get; set; }
    public int? Quantity { get; set; }
    public string AuthorFullName { get; set; }
    public string ThemesName { get; set; }
    public string CategoryName { get; set; }
    public string PressName { get; set; }

    public Books(int? id, string name, int? pages, int? yearPress, string comment, int? quantity, string authorFullName, string themesName, string categoryName, string pressName)
    {
        Id = id;
        Name = name;
        Pages = pages;
        YearPress = yearPress;
        Comment = comment;
        Quantity = quantity;
        AuthorFullName = authorFullName;
        ThemesName = themesName;
        CategoryName = categoryName;
        PressName = pressName;
    }

}

