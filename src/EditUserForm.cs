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
    public partial class EditUserForm : Form
    {
        private readonly NpgsqlConnection npgsqlConnection;

        private readonly int id;
        private readonly int editId;
        private string role;

        public EditUserForm(int id, int editId)
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();

            this.id = id;
            this.editId = editId;

            initData();
        }

        private void initData()
        {
            var query = "SELECT login, password, role FROM Member WHERE id=" + editId;
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            dr.Read();
            loginTextBox.Text = dr.GetString(0);
            passwordTextBox.Text = dr.GetString(1);
            confirmTextBox.Text = dr.GetString(1);
            roleTextBox.Text = dr.GetString(2);
            dr.Close();

            query = "SELECT role FROM Member WHERE id=" + id;
            cmd = new NpgsqlCommand(query, npgsqlConnection);
            dr = cmd.ExecuteReader();
            dr.Read();
            role = dr.GetString(0);
            dr.Close();

            if (role != "admin")
            {
                roleTextBox.Enabled = false;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;
            var confirmPass = confirmTextBox.Text;
            var roleEdit = roleTextBox.Text;

            if (password.Length < 5)
            {
                MessageBox.Show(@"Password must be at least 5 charachters", @"Incorrect password", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPass)
            {
                MessageBox.Show(@"Password is not confirmed", @"Wrong confirmed password", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(@"Save changes?", @"Editing profile", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            var query = "UPDATE Member SET login='" + login +
                        "', password='" + password +
                        "', role='" + roleEdit + "'" +
                        "WHERE id=" + editId;
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var db = cmd.ExecuteReader();
            db.Close(); 

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
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
