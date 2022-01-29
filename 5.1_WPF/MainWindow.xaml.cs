using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _5._1_WPF
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string font_name = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (text_box != null)
            {
                text_box.FontFamily = new FontFamily(font_name);
            }

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double font_size = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (text_box != null)
            {
                text_box.FontSize = font_size;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (text_box.FontWeight == FontWeights.Normal)
            {
                text_box.FontWeight = FontWeights.Bold;
            }
            else
            {
                text_box.FontWeight = FontWeights.Normal;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (text_box.FontStyle == FontStyles.Normal)
            {
                text_box.FontStyle = FontStyles.Italic;
            }
            else
            {
                text_box.FontStyle = FontStyles.Normal;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (text_box.TextDecorations == null)
            {
                text_box.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                text_box.TextDecorations = null;
            }

        }  // Foreground="Red" 

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            text_box.Foreground = Brushes.Black;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            text_box.Foreground = Brushes.Red;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (open_file_dialog.ShowDialog() == true)
            {
                text_box.Text = File.ReadAllText(open_file_dialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save_file_dialog = new SaveFileDialog();
            save_file_dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (save_file_dialog.ShowDialog() == true)
            {
                File.WriteAllText(save_file_dialog.FileName, text_box.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
