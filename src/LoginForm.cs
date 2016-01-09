using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace TimeManager
{
    public partial class LoginForm : Form
    {
        private const string ServerDataBase = "Server=localhost";
        private const string PortDataBase = "Port=5432";
        private const string UserIdDataBase = "User Id=postgres";
        private const string PasswordDataBase = "Password=csc";
        private const string DataBase = "Database=postgres";

        private readonly NpgsqlConnection npgsqlConnection;
        public LoginForm()
        {
            InitializeComponent();

            var settingsDataBase = new string[] {ServerDataBase, PortDataBase, UserIdDataBase, PasswordDataBase, DataBase};
            var connectionDataBase = string.Join(";", settingsDataBase);
            npgsqlConnection = new NpgsqlConnection(connectionDataBase);
            npgsqlConnection.Open();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;
            var query = "SELECT password FROM Member WHERE login='" + login + "';";

            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                MessageBox.Show(@"Login is invalid", @"Sign in error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dr.Close();
                return;
            }

            var expectedPassord = dr.GetString(0);
            if (password == expectedPassord)
            {
                MessageBox.Show("Great! ExPassowrd = " + expectedPassord);
            }
            else
            {
                MessageBox.Show(@"Wrong password", @"Sign in Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            dr.Close();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            npgsqlConnection.Close();
            LoginForm.ActiveForm.Close();
        }
    }
}
