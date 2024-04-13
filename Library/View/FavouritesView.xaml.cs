using MySql.Data.MySqlClient;
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
            string connStr = "server=localhost;user=root;database=Library;port=3307;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT * from favourites WHERE user_id = @content";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@content", User.UserID);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string currentFileName = rdr["fileName"].ToString();
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
                    textBlock.Text = rdr["fileName"].ToString();
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
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed! {ex}");
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        private void DelButClick(string fileName)
        {
            string connStr = "server=localhost;user=root;database=Library;port=3307;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "DELETE FROM favourites WHERE fileName = @content AND user_id = @content2";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@content", fileName);
                cmd.Parameters.AddWithValue("@content2", User.UserID);
                cmd.ExecuteNonQuery();
                RefreshUI();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
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
