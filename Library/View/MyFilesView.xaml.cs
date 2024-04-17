using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Win32;
using System.Windows.Data;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for MyFilesView.xaml
    /// </summary>
    public partial class MyFilesView : UserControl
    {
        private Button staticButton;
        public MyFilesView()
        {
            InitializeComponent();
            string projectDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            staticButton = CreateStaticButton();
            SearchFiles(projectDirectory);
        }

        private void SearchFiles(string directory)
        {
            var files = new DirectoryInfo(directory + "//Library_books");
            Files.Children.Clear();
            Files.Children.Add(staticButton);

            foreach (var file in files.GetFiles())
            {
                Button but = new Button();
                but.Width = 300;
                but.Height = 200;
                but.Background = new SolidColorBrush(Color.FromRgb(44, 44, 44));
                but.BorderBrush = new SolidColorBrush(Color.FromRgb(44, 44, 44));
                but.Style = FindResource("but") as Style;
                but.Margin = new Thickness(75, 0, 0, 90);
                but.Click += (sender, e) => FilesButtonClick(file.FullName);
                but.HorizontalContentAlignment = HorizontalAlignment.Left;
                but.VerticalContentAlignment = VerticalAlignment.Bottom;
                but.Padding = new Thickness(10, 10, 10, 10);

                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                TextBlock textBlock = new TextBlock();
                textBlock.Text = file.Name;
                textBlock.Margin = new Thickness(0, 0, 50, 0);
                textBlock.Width = 195;
                textBlock.Height = 35;
                textBlock.TextTrimming = TextTrimming.CharacterEllipsis;

                Button innerButton = new Button();
                System.Windows.Shapes.Path innerIcon = new System.Windows.Shapes.Path();
                innerIcon.Style = FindResource("fav") as Style;
                innerIcon.Fill = new SolidColorBrush(Colors.White);
                innerIcon.Width = 25;
                innerIcon.Height = 25;
                innerButton.Style = FindResource("innerBut") as Style;
                innerButton.Height = 30;
                innerButton.Width = 30;
                innerButton.Background = new SolidColorBrush(Color.FromRgb(44, 44, 44));
                innerButton.BorderBrush = new SolidColorBrush(Color.FromRgb(44, 44, 44));
                innerButton.Content = innerIcon;
                innerButton.Click += (sender, e) => FavButClick(file.Name, e);

                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(innerButton);

                but.Content = stackPanel;

                Files.Children.Add(but);

            }
        }

        private void FilesButtonClick(string filePath)
        {
            DocumentWindow window = new DocumentWindow(filePath);
            window.Show();
        }
        private void FavButClick(string fileName, RoutedEventArgs e)
        {
            
        }
        private Button CreateStaticButton()
        {
            Button myButton = new Button();
            myButton.Width = 300;
            myButton.Height = 200;
            myButton.Background = new SolidColorBrush(Color.FromRgb(44, 44, 44));
            myButton.BorderBrush = new SolidColorBrush(Color.FromRgb(44, 44, 44));
            myButton.Margin = new Thickness(75, 0, 0, 0);
            myButton.VerticalAlignment = VerticalAlignment.Top;
            myButton.Click += Button_Click;

            ControlTemplate buttonTemplate = new ControlTemplate(typeof(Button));
            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.Name = "border";
            borderFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(15));
            borderFactory.SetBinding(Border.BackgroundProperty, new Binding("Background") { Source = myButton });

            FrameworkElementFactory contentPresenterFactory = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterFactory.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterFactory.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);

            borderFactory.AppendChild(contentPresenterFactory);

            buttonTemplate.VisualTree = borderFactory;

            myButton.Template = buttonTemplate;

            Style borderStyle = new Style(typeof(Border));
            borderStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(15)));

            myButton.Resources.Add(typeof(Border), borderStyle);

            System.Windows.Shapes.Path path = new System.Windows.Shapes.Path();
            path.Style = FindResource("add") as Style; // Убедитесь, что у вас есть стиль с именем "add" в ресурсах
            path.Fill = new SolidColorBrush(Color.FromRgb(30, 30, 30));
            path.Width = 150;
            path.Height = 150;

            myButton.Content = path;

            return myButton;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                string destinationFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Library_books";

                try
                {
                    string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(selectedFilePath));
                    File.Copy(selectedFilePath, destinationFilePath, true);
                    MessageBox.Show("Файл успешно скопирован!");
                    SearchFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при копировании файла: {ex.Message}");
                }
            }
        }
    }
}

