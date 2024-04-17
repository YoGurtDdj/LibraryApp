using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using Library.View;

namespace Library
{
    public static class Bookmarks
    {
        public static List<Bookmark> BookmarksList = new List<Bookmark>();
    }

    public class Bookmark : Button
    {
        StackPanel _stackPanel;
        StackPanel _innerStackPanel;

        TextBlock _textBlock;

        Button _favButton;
        Button _delButton;

        Path _path1;
        Path _path2;

        BookmarksView _win;

        public string Text { get; set; }
        public int Id { get; set; }

        public Bookmark(string text, BookmarksView window)
        {
            this.Id = 1;
            this._win = window;
            Text = text;

            base.Width = 300;
            base.Height = 300;
            base.Background = new SolidColorBrush(Color.FromRgb(44, 44, 44));
            base.BorderBrush = new SolidColorBrush(Color.FromRgb(44, 44, 44));
            base.Style = Application.Current.TryFindResource("but") as Style;
            base.Margin = new Thickness(75, 0, 0, 90);
            base.Padding = new Thickness(15, 15, 15, 15);
            base.VerticalContentAlignment = VerticalAlignment.Top;

            this._textBlock = new TextBlock
            {
                Text = this.Text,
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.White,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontFamily = new FontFamily("Fonts/Inder.ttf#Inder"),
                Height = 240,
                FontSize = 24
            };

            this._innerStackPanel = new StackPanel 
            { 
                Orientation = Orientation.Horizontal
            };

            this._path1 = new Path
            {
                Style = Application.Current.TryFindResource("fav") as Style,
                Fill = Brushes.White,
                Margin = new Thickness(0, 0, 0, 0),
                Width = 25,
                Height = 25,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            this._favButton = new Button
            {
                Content = _path1,
                Style = Application.Current.TryFindResource("innerBut") as Style
            };
            
            this._path2 = new Path
            {
                Style = Application.Current.TryFindResource("del") as Style,
                Fill = Brushes.White,
                Width = 25,
                Height = 25,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            this._delButton = new Button
            {
                Content = _path2,
                Style = Application.Current.TryFindResource("innerBut") as Style,
                Margin = new Thickness(215, 0, 0, 0),
                Width = 25,
            };
            this._delButton.Click += (sender, e) => DelButClick(Id);

            this._innerStackPanel.Children.Add(_favButton);
            this._innerStackPanel.Children.Add(_delButton);

            this._stackPanel = new StackPanel();

            this._stackPanel.Children.Add(_textBlock);
            this._stackPanel.Children.Add(_innerStackPanel);

            base.Content = _stackPanel;
            base.Resources.Add(typeof(Border), new Style { Setters = { new Setter(Border.CornerRadiusProperty, new CornerRadius(15)) } });
        }

        private void DelButClick(int id)
        {
            Bookmarks.BookmarksList.Remove(this);
            _win.RefreshUI();
        }
    }
}
