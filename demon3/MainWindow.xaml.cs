using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demon3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Database db = new Database();
        
        var itemdb = db.getItems();
        string imageFolder = 
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                "Resources"); 
        string defaultImage = System.IO.Path.Combine(imageFolder, "picture.png"); 
       

        foreach (var dbdb in itemdb)
        {
            if (string.IsNullOrWhiteSpace(dbdb.Photo)) 
            { 
                dbdb.Photo = defaultImage; 
            }
            else
            {
                dbdb.Photo  = System.IO.Path.Combine(imageFolder, dbdb.Photo);
            }
        }
        
        imia.ItemsSource = itemdb;
    }
}