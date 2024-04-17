using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class User
    {
        public static event EventHandler UserLoggedIn;
        public static string Login { get; private set; }
        public static string UserID { get; private set; }
        public static void StartSession(string login)
        {
            Login = login;
            UserID = GetId(login);
            UserLoggedIn?.Invoke(null, EventArgs.Empty);
        }

        public static void EndSession()
        {
            Login = null;
        }

        public static bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(Login);
        }

        private static string GetId(string username)
        {
            return "lol";
        }
    }
}
