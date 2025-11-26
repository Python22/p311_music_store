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

namespace p311_music_store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void add_new_data(object sender,  RoutedEventArgs e) 
        {
            AddNewDataWindow add_new_data_window = new AddNewDataWindow();
            add_new_data_window.Show();
        
        }
        void show_new_records(object sender, RoutedEventArgs e) { }
        void show_most_popular_records(object sender, RoutedEventArgs e) { }
        void show_most_popular_groups(object sender, RoutedEventArgs e) { }
        void show_most_popular_genres(object sender, RoutedEventArgs e) { }
    }
}
