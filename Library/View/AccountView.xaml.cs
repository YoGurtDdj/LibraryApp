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
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        public AccountView()
        {
            InitializeComponent();
            LoginLabel.Content = User.Login;
        }

        private void Out_Click(object sender, RoutedEventArgs e)
        {
            User.EndSession();

        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            
            string connStr = "server=localhost;user=root;database=Library;port=3307;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql1 = "DELETE FROM favourites WHERE user_id = @id";
                string sql2 = "DELETE FROM notes1 WHERE user_id = @id";
                string sql = "DELETE FROM users WHERE id = @id";

                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@id", User.UserID);
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@id", User.UserID);
                cmd2.ExecuteNonQuery();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", User.UserID);
                cmd.ExecuteNonQuery();
                User.EndSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"deleting failed! {ex}");
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
