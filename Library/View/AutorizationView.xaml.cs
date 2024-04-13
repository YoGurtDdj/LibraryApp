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
    /// Interaction logic for AutorizationView.xaml
    /// </summary>
    public partial class AutorizationView : UserControl
    {
        public AutorizationView()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string connStr = "server=localhost;user=root;database=Library;port=3307;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT * FROM Users WHERE login = @Login and psw = @password";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Login", Login.Text);
                cmd.Parameters.AddWithValue("@password", Password.Password);
                int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (userCount > 0)
                {
                    User.StartSession(Login.Text);
                }
                else
                {
                    MessageBox.Show("Login failed! Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed! {ex}");
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
