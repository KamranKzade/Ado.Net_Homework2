using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Ado.Net_Homework2.Views;


public partial class AddBookWindow : Window
{
    public AddBookWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        using (var conn = new SqlConnection())
        {
            SqlDataAdapter da = new SqlDataAdapter();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
            DataSet set = new DataSet();


            conn.Open();


            SqlCommand sqlCommand = new SqlCommand("ShowAllBooks", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand = sqlCommand;
            da.Fill(set, "Books");


            var paramId = new SqlParameter();
            paramId.ParameterName = "@Id";
            paramId.SqlDbType = SqlDbType.Int;
            paramId.Value = id_txt.Text;


            var paramName = new SqlParameter();
            paramName.ParameterName = "@Name";
            paramName.SqlDbType = SqlDbType.NVarChar;
            paramName.Value = name_txt.Text;


            var paramPages = new SqlParameter();
            paramPages.ParameterName = "@Pages";
            paramPages.SqlDbType = SqlDbType.Int;
            paramPages.Value = pages_txt.Text;

            var paramYear = new SqlParameter();
            paramYear.ParameterName = "@YearPress";
            paramYear.SqlDbType = SqlDbType.Int;
            paramYear.Value = yearpress_txt.Text;

            var paramThemes = new SqlParameter();
            paramThemes.ParameterName = "@Id_Themes";
            paramThemes.SqlDbType = SqlDbType.Int;
            paramThemes.Value = idThemes_txt.Text;

            var paramCategory = new SqlParameter();
            paramCategory.ParameterName = "@Id_Category";
            paramCategory.SqlDbType = SqlDbType.Int;
            paramCategory.Value = idCategory_txt.Text;


            var paramAuthor = new SqlParameter();
            paramAuthor.ParameterName = "@Id_Author";
            paramAuthor.SqlDbType = SqlDbType.Int;
            paramAuthor.Value = idAuthor_txt.Text;

            var paramPress = new SqlParameter();
            paramPress.ParameterName = "@Id_Press";
            paramPress.SqlDbType = SqlDbType.Int;
            paramPress.Value = idPress_txt.Text;

            var paramComment = new SqlParameter();
            paramComment.ParameterName = "@Comment";
            paramComment.SqlDbType = SqlDbType.NVarChar;
            paramComment.Value = comment_txt.Text;

            var paramQuantity = new SqlParameter();
            paramQuantity.ParameterName = "@Quantity";
            paramQuantity.SqlDbType = SqlDbType.Int;
            paramQuantity.Value = quantity_txt.Text;

            using (sqlCommand = new SqlCommand("InsertBook", conn))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(paramId);
                sqlCommand.Parameters.Add(paramName);
                sqlCommand.Parameters.Add(paramPages);
                sqlCommand.Parameters.Add(paramYear);
                sqlCommand.Parameters.Add(paramThemes);
                sqlCommand.Parameters.Add(paramCategory);
                sqlCommand.Parameters.Add(paramAuthor);
                sqlCommand.Parameters.Add(paramPress);
                sqlCommand.Parameters.Add(paramComment);
                sqlCommand.Parameters.Add(paramQuantity);


                da.InsertCommand = sqlCommand;

                da.Update(set, "Books");
                da.InsertCommand.ExecuteNonQuery();

                da.Fill(set, "Books");
                MessageBox.Show("Succesfully Added");
            }

            DialogResult = true;
        }

    }
}
