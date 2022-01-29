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

namespace _5._2_WPF
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            drawing_color.Color = Colors.Black;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            drawing_color.Color = Colors.White;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            drawing_color.Color = Colors.Red;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            drawing_color.Color = Colors.Blue;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            drawing_color.Color = Colors.Green;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "PNG (*.png)|*.png|Все файлы (*.*)|*.*";
            if (open_file_dialog.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(open_file_dialog.FileName, UriKind.Absolute));
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            // Код взят с сайта:
            // https://andrey.moveax.ru/post/wpf-rendertargetbitmap

            var pSource = PresentationSource.FromVisual(Application.Current.MainWindow);
            Matrix m = pSource.CompositionTarget.TransformToDevice;
            double dpiX = m.M11 * 96;
            double dpiY = m.M22 * 96;

            int width = (int)this.ink_canvas.ActualWidth;
            int height = (int)this.ink_canvas.ActualHeight;

            var elementBitmap = new RenderTargetBitmap(width, height, dpiX, dpiY, PixelFormats.Default);

            var drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                var visualBrush = new VisualBrush(ink_canvas);
                drawingContext.DrawRectangle(
                    visualBrush,
                    null,
                    new Rect(new Point(0, 0), new Size(width / m.M11, height / m.M22)));
            }

            elementBitmap.Render(drawingVisual);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(elementBitmap));

            SaveFileDialog save_file_dialog = new SaveFileDialog();
            save_file_dialog.Filter = "PNG (*.png)|*.png|Все файлы (*.*)|*.*";
            if (save_file_dialog.ShowDialog() == true)
            {
                string file_name = save_file_dialog.FileName;
                using (var imageFile = new FileStream(file_name, FileMode.Create, FileAccess.Write))
                {
                    encoder.Save(imageFile);
                    imageFile.Flush();
                    imageFile.Close();
                }
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
