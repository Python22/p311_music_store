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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace p311_music_store
{
    public partial class AddNewDataWindow : Window
    {
        string current_data_type;
        public AddNewDataWindow()
        {
            InitializeComponent();
        }

        private void add_new_data_combobox_changed(object sender, RoutedEventArgs e) 
        {
            Console.WriteLine((sender as ComboBox).SelectionBoxItem.ToString());
        }
    }
}
