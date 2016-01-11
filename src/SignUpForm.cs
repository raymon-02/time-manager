using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace TimeManager
{
    public partial class SignUpForm : Form
    {
        private readonly NpgsqlConnection npgsqlConnection;

        public SignUpForm()
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();
        }

        private void signupSignUpButton_Click(object sender, EventArgs e)
        {
            var login = loginSignUpTextBox.Text;
            var password = passwordSignUpTextBox.Text;
            var confirmPassword = confirmPasswordTextBox.Text;

            var query = "SELECT id From Member WHERE login = '" + login + "'";
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show(@"User with this login is alredy exist", @"Wrong login", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                dr.Close();
                return;
            }
            dr.Close();

            if (password.Length < 5)
            {
                MessageBox.Show(@"Password must consist at least 5 characters", @"Invalid password", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show(@"Password is not confirmed", @"Wrong confirmed password", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            query = "INSERT INTO Member (role, login, password) VALUES (user, '" +
                login + "', '" + password + "')";
            cmd = new NpgsqlCommand(query, npgsqlConnection);
            dr = cmd.ExecuteReader();
            dr.Close();

            MessageBox.Show(@"Successful", @"Successful sign up", MessageBoxButtons.OK);
            SignUpForm.ActiveForm.Close();
        }

        private void cancelSignUpButton_Click(object sender, EventArgs e)
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
