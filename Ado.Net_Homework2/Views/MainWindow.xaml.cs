using Ado.Net_Homework2.Models;
using Ado.Net_Homework2.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ado.Net_Homework2;



public partial class MainWindow : Window
{

    DataTable table;
    SqlDataReader reader;
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
        UpdateBookWindow updateBook = new();
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