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
        DataAccess data_access;
        public AddNewDataWindow()
        {
            InitializeComponent();
            data_access = new DataAccess("p311_music_store");
            hide_all_inputs();
        }

        private void hide_all_inputs()
        {
            field_1_input.Visibility = Visibility.Hidden;
            field_2_input.Visibility = Visibility.Hidden;
            field_3_input.Visibility = Visibility.Hidden;
            field_4_combobox.Visibility = Visibility.Hidden;
            field_5_combobox.Visibility = Visibility.Hidden;
            field_1_label.Text = "";
            field_2_label.Text = "";
            field_3_label.Text = "";
            field_4_label.Text = "";
            field_5_label.Text = "";
            field_1_input.Text = "";
            field_2_input.Text = "";
            field_3_input.Text = "";
            field_4_combobox.Items.Clear();
            field_5_combobox.Items.Clear();
        }

        private void add_new_data_combobox_changed(object sender, EventArgs e) 
        {
            hide_all_inputs();
            current_data_type = (sender as ComboBox).SelectionBoxItem.ToString();
            Console.WriteLine(current_data_type);

            if (current_data_type == "Добавить жанр")
            {
                field_1_label.Text = "Название жанра:";
                field_1_input.Visibility = Visibility.Visible;
            }
            else if (current_data_type == "Добавить группу")
            {
                field_1_label.Text = "Название группы:";
                field_1_input.Visibility = Visibility.Visible;
                field_2_label.Text = "Исполнители:";
                field_2_input.Visibility = Visibility.Visible;
            }
            else if (current_data_type == "Добавить музыку")
            {
                field_1_label.Text = "Название музыки:";
                field_1_input.Visibility = Visibility.Visible;
                field_2_label.Text = "Текст музыки:";
                field_2_input.Visibility = Visibility.Visible;
                field_4_label.Text = "Группа:";
                field_4_combobox.Visibility = Visibility.Visible;
                field_4_combobox.ItemsSource = data_access.get_group_names();
                field_5_label.Text = "Альбом:";
                field_5_combobox.Visibility = Visibility.Visible;
            }
            else if (current_data_type == "Добавить альбом")
            {
                field_1_label.Text = "Год издания:";
                field_1_input.Visibility = Visibility.Visible;
                field_4_label.Text = "Группа:";
                field_4_combobox.Visibility = Visibility.Visible;
                field_4_combobox.ItemsSource = data_access.get_group_names();
            }
            else if (current_data_type == "Добавить диск")
            {
                field_1_label.Text = "Название диска:";
                field_1_input.Visibility = Visibility.Visible;
                field_2_label.Text = "Цена:";
                field_2_input.Visibility = Visibility.Visible;
                field_3_label.Text = "Кол-во в магазине:";
                field_3_input.Visibility = Visibility.Visible;
                field_4_label.Text = "Группа:";
                field_4_combobox.Visibility = Visibility.Visible;
                field_4_combobox.ItemsSource = data_access.get_group_names();
            }
            else if (current_data_type == "Добавить покупателя")
            {
                field_1_label.Text = "Имя покупателя:";
                field_1_input.Visibility = Visibility.Visible;
                field_2_label.Text = "Телефон:";
                field_2_input.Visibility = Visibility.Visible;
                field_3_label.Text = "Процент скидки(от 0%):";
                field_3_input.Visibility = Visibility.Visible;
            }
            else if (current_data_type == "Добавить жанр музыке")
            {
                field_4_label.Text = "Музыка:";
                field_4_combobox.Visibility = Visibility.Visible;
                field_5_label.Text = "Жанр:";
                field_5_combobox.Visibility = Visibility.Visible;
            }
            else if (current_data_type == "Добавить музыку в диск")
            {
                field_4_label.Text = "Музыка:";
                field_4_combobox.Visibility = Visibility.Visible;
                field_5_label.Text = "Диск:";
                field_5_combobox.Visibility = Visibility.Visible;
            }
            else if (current_data_type == "Добавить новую покупку")
            {
                field_3_label.Text = "Дата покупки:";
                field_3_input.Visibility = Visibility.Visible;
                field_4_label.Text = "Покупатель:";
                field_4_combobox.Visibility = Visibility.Visible;
                field_5_label.Text = "Диск:";
                field_5_combobox.Visibility = Visibility.Visible;
            }
        }

        private void ok_btn_click(object sender, EventArgs e)
        {
            if (current_data_type == "Добавить жанр")
            {
                data_access.add_genre(field_1_input.Text);
                field_1_input.Text = "";
            }
            if (current_data_type == "Добавить группу")
            {
                data_access.add_group(field_1_input.Text, field_2_input.Text);
                field_1_input.Text = "";
                field_2_input.Text = "";
            }
            if (current_data_type == "Добавить музыку")
            {
                data_access.add_music(
                    field_1_input.Text,
                    field_2_input.Text,
                    field_4_combobox.Text.Split(';')[0],
                    ""
                );
                field_1_input.Text = "";
                field_2_input.Text = "";
            }
            if (current_data_type == "Добавить альбом")
            {
                data_access.add_album(
                    field_1_input.Text,
                    field_4_combobox.Text.Split(';')[0]
                );
                field_1_input.Text = "";
            }
            if (current_data_type == "Добавить диск")
            {
                data_access.add_record(
                    field_1_input.Text,
                    field_2_input.Text,
                    field_3_input.Text,
                    field_4_combobox.Text.Split(';')[0]
                );
                field_1_input.Text = "";
                field_2_input.Text = "";
                field_3_input.Text = "";
            }
        }
    }
}
