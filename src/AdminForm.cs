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
    public partial class AdminForm : Form
    {
        private readonly NpgsqlConnection npgsqlConnection;

        private readonly int id;

        public AdminForm(int id)
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();

            this.id = id;

            initData();
        }

        private void initData()
        {
            dataListView.Items.Clear();

            var query = "SELECT login FROM Member WHERE id = " + id;
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            dr.Read();
            var currentLogin = dr.GetString(0);
            dr.Close();

            query = "SELECT login, role FROM Member";
            cmd = new NpgsqlCommand(query, npgsqlConnection);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var login = dr.GetString(0);

                if (login == currentLogin)
                {
                    continue;
                }

                var role = dr.GetString(1);
                var item = new ListViewItem(login);
                item.SubItems.Add(role);
                dataListView.Items.Add(item);
            }

            dr.Close();
        }

        private void RemoveUser(string login)
        {
            var query = "DELETE FROM Member WHERE login = '" + login + "'";
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            dr.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"No users selected to edit", @"Wrong selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (dataListView.SelectedItems.Count > 1)
            {
                MessageBox.Show(@"You must select only one user to edit", @"Wrong selection", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var login = dataListView.SelectedItems[0].SubItems[0].Text;

            var query = "SELECT id FROM Member WHERE login = '" + login + "'";
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            dr.Read();
            var editId = dr.GetInt32(0);
            dr.Close();

            var editUserForm = new EditUserForm(id, editId);
            editUserForm.ShowDialog();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Remove selected users?", @"Removing users...", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            foreach (ListViewItem item in dataListView.SelectedItems)
            {
                var login = item.SubItems[0].Text;
                RemoveUser(login);

                initData();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Remove all users?", @"Removing users...", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            foreach (ListViewItem item in dataListView.Items)
            {
                var login = item.SubItems[0].Text;
                RemoveUser(login);

                initData();
            }
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
