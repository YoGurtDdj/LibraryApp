using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data;
using MySql.Data.MySqlClient;
using Library.ViewModel;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
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

                string sql = "INSERT INTO users(Login, psw) VALUES (@Login, @password)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Login", Login.Text);
                cmd.Parameters.AddWithValue("@password", Password.Password);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    User.StartSession(Login.Text);
                }
                else
                {
                    MessageBox.Show("Registration failed!");
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
