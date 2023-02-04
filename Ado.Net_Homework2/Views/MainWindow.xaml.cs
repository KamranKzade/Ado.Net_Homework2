using Ado.Net_Homework2.Models;
using Ado.Net_Homework2.Views;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Ado.Net_Homework2;



public partial class MainWindow : Window
{
    SqlDataAdapter da;
    DataSet set;



    public MainWindow()
    {
        InitializeComponent();
    }

    private void Add_Click_2(object sender, RoutedEventArgs e)
    {
        AddBookWindow window = new AddBookWindow();
        window.ShowDialog();
    }

    private void Update_Click_3(object sender, RoutedEventArgs e)
    {
        var obj = myDataGrid.SelectedItem;
        var nese = obj as DataRowView;
        var objects = nese!.Row.ItemArray;

        Books books = new((int)objects[0], objects[1].ToString(), (int)objects[2], (int)objects[3], objects[4].ToString(), (int)objects[5], objects[6].ToString(), objects[7].ToString(), objects[8].ToString(), objects[8].ToString());
      
        UpdateBookWindow updateBook = new(books);
        updateBook.ShowDialog();
    }

    private void Delete_Click_1(object sender, RoutedEventArgs e)
    {
        var obj = myDataGrid.SelectedItem;
        var nese = obj as DataRowView;
        var book = nese!.Row.ItemArray;

        using (var conn = new SqlConnection())
        {
            da = new SqlDataAdapter();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
            conn.Open();
            set = new DataSet();

            SqlCommand sqlCommand = new SqlCommand("ShowAllBooks", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand = sqlCommand;
            da.Fill(set, "Books");



            sqlCommand = new SqlCommand("DeleteBooks", conn);

            sqlCommand.CommandType = CommandType.StoredProcedure;


            sqlCommand.Parameters.Add(new SqlParameter
            {
                DbType = DbType.Int32,
                ParameterName = "@booksId",
                Value = book[0]
            });

            da.UpdateCommand = sqlCommand;

            da.Update(set, "Books");
            da.UpdateCommand.ExecuteNonQuery();

            da.Fill(set, "Books");
        }
    }



    private void ShowAll_Click(object sender, RoutedEventArgs e)
    {

        using (var conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;

            da = new SqlDataAdapter();
            conn.Open();
            set = new DataSet();

            SqlCommand command = new SqlCommand("ShowAllBooks", conn);
            command.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = command;

            da.Fill(set, "AllBooks");
            myDataGrid.ItemsSource = set.Tables[0].DefaultView;
        }
    }

}