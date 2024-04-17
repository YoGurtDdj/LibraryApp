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

namespace Library.View
{
    /// <summary>
    /// Interaction logic for FavouritesView.xaml
    /// </summary>
    public partial class FavouritesView : UserControl
    {
        public FavouritesView()
        {
            InitializeComponent();
            ShowFavourites();
        }

        private void ShowFavourites()
        {
            string currentFileName = "wd";
            Button but = new Button();
            but.Width = 300;
            but.Height = 200;
            but.Background = new SolidColorBrush(Color.FromRgb(44, 44, 44));
            but.BorderBrush = new SolidColorBrush(Color.FromRgb(44, 44, 44));
            but.Style = FindResource("but") as Style;
            but.Margin = new Thickness(75, 0, 0, 90);
            but.HorizontalContentAlignment = HorizontalAlignment.Left;
            but.VerticalContentAlignment = VerticalAlignment.Bottom;
            but.Padding = new Thickness(10, 10, 10, 10);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "ws";
            textBlock.Margin = new Thickness(0, 0, 50, 0);
            textBlock.Width = 195;
            textBlock.Height = 35;
            textBlock.TextTrimming = TextTrimming.CharacterEllipsis;

            Button innerButton = new Button();
            Path innerIcon = new Path();
            innerIcon.Style = FindResource("del") as Style;
            innerIcon.Fill = new SolidColorBrush(Colors.White);
            innerIcon.Width = 25;
            innerIcon.Height = 25;
            innerButton.Style = FindResource("innerBut") as Style;
            innerButton.Height = 30;
            innerButton.Width = 30;
            innerButton.Background = new SolidColorBrush(Color.FromRgb(44, 44, 44));
            innerButton.BorderBrush = new SolidColorBrush(Color.FromRgb(44, 44, 44));
            innerButton.Content = innerIcon;
            innerButton.Click += (sender, e) => DelButClick(currentFileName);


            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(innerButton);

            but.Content = stackPanel;

            Files.Children.Add(but);
        }

        private void DelButClick(string fileName)
        {
            
        }
        private void RefreshUI()
        {
            // Clear existing buttons
            Files.Children.Clear();

            // Re-populate the container with updated data
            ShowFavourites();
        }
    }
}
