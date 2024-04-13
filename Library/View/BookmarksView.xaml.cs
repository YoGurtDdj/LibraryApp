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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for BookmarksView.xaml
    /// </summary>
    public partial class BookmarksView : UserControl
    {
        public BookmarksView()
        {
            InitializeComponent();
            ShowMarks();
        }

        private void ShowMarks()
        {
            string connStr = "server=localhost;user=root;database=Library;port=3307;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT * from notes1 WHERE user_id = @content2";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@content2", User.UserID);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int itemId = Convert.ToInt32(rdr["id"]);
                    Button but = new Button();
                    but.Width = 300;
                    but.Height = 300;
                    but.Background = new SolidColorBrush(Color.FromRgb(44, 44, 44));
                    but.BorderBrush = new SolidColorBrush(Color.FromRgb(44, 44, 44));
                    but.Style = this.FindResource("but") as Style;
                    but.Margin = new Thickness(75, 0, 0, 90);
                    but.Padding = new Thickness(15, 15, 15, 15);
                    but.VerticalContentAlignment = VerticalAlignment.Top;

                    StackPanel stackPanel = new StackPanel();

                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = rdr["markText"].ToString();
                    textBlock.TextWrapping = TextWrapping.Wrap;
                    textBlock.Foreground = Brushes.White;
                    textBlock.TextTrimming = TextTrimming.CharacterEllipsis;
                    textBlock.FontFamily = new FontFamily("Fonts/Inder.ttf#Inder");
                    textBlock.Height = 240;
                    textBlock.FontSize = 24;

                    StackPanel innerStackPanel = new StackPanel();
                    innerStackPanel.Orientation = Orientation.Horizontal;

                    Button innerButton1 = new Button();
                    innerButton1.Style = this.FindResource("innerBut") as Style;

                    Path path1 = new Path();
                    path1.Style = this.FindResource("fav") as Style;
                    path1.Fill = Brushes.White;
                    path1.Margin = new Thickness(0, 0, 0, 0);
                    path1.Width = 25;
                    path1.Height = 25;
                    path1.HorizontalAlignment = HorizontalAlignment.Left;

                    innerButton1.Content = path1;

                    Button innerButton2 = new Button();
                    innerButton2.Style = this.FindResource("innerBut") as Style;
                    innerButton2.Margin = new Thickness(215, 0, 0, 0);
                    innerButton2.Width = 25;


                    Path path2 = new Path();
                    path2.Style = this.FindResource("del") as Style;
                    path2.Fill = Brushes.White;
                    path2.Width = 25;
                    path2.Height = 25;
                    path2.HorizontalAlignment = HorizontalAlignment.Right;

                    innerButton2.Content = path2;
                    innerButton2.Click += (sender, e) => DelButClick(itemId);

                    innerStackPanel.Children.Add(innerButton1);
                    innerStackPanel.Children.Add(innerButton2);

                    stackPanel.Children.Add(textBlock);
                    stackPanel.Children.Add(innerStackPanel);

                    but.Content = stackPanel;

                    but.Resources.Add(typeof(Border), new Style { Setters = { new Setter(Border.CornerRadiusProperty, new CornerRadius(15)) } });

                    Files.Children.Add(but);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"failed! {ex}");
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        private void DelButClick(int id)
        {
            string connStr = "server=localhost;user=root;database=Library;port=3307;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "DELETE FROM notes1 WHERE id = @content AND user_id = @content2";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@content", id);
                cmd.Parameters.AddWithValue("@content2", User.UserID);
                cmd.ExecuteNonQuery();
                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"dwd {ex}");
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        private void RefreshUI()
        {
            // Clear existing buttons
            Files.Children.Clear();

            // Re-populate the container with updated data
            ShowMarks();
        }
    }
}
