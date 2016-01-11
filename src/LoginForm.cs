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
        private readonly NpgsqlConnection npgsqlConnection;


        public LoginForm()
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;

            var query = "SELECT id, password FROM Member WHERE login='" + login + "'";
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                MessageBox.Show(@"Login is invalid", @"Sign in error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dr.Close();
                return;
            }

            var expectedPassord = dr.GetString(1);
            if (password != expectedPassord)
            {
                MessageBox.Show(@"Wrong password", @"Sign in Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var id = int.Parse(dr.GetString(0));
            var managerForm = new ManagerForm(this, id);
            managerForm.Show();
            Hide();

            loginTextBox.Text = "";
            passwordTextBox.Text = "";

            dr.Close();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            var signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            npgsqlConnection.Close();
        }
    }
}
