using Ado.Net_Homework2.Views;
using System;
using System.Collections.Generic;
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

    }

    private void ShowAll_Click(object sender, RoutedEventArgs e)
    {

    }
}
