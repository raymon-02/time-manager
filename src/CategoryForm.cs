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
    public partial class CategoryForm : Form
    {
        private readonly NpgsqlConnection npgsqlConnection;

        private readonly int id;

        public CategoryForm(int id)
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();

            this.id = id;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Add new category?", @"Adding category", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            var name = categoryTextBox.Text;
            var idCategory = 0;

            var query = "SELECT id FROM Category WHERE name='" + name + "'";
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                idCategory = dr.GetInt32(0);
                dr.Close();

                query = "SELECT id FROM Mem_cat WHERE member_id=" + id + " AND category_id=" + idCategory;
                cmd = new NpgsqlCommand(query, npgsqlConnection);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    Close();
                    return;
                }
                dr.Close();
            }
            else
            {
                dr.Close();
                query = "INSERT INTO Category (name) VALUES ('" + name + "')";
                cmd = new NpgsqlCommand(query, npgsqlConnection);
                dr = cmd.ExecuteReader();
                dr.Close();

                query = "SELECT id FROM Category WHERE name='" + name + "'";
                cmd = new NpgsqlCommand(query, npgsqlConnection);
                dr = cmd.ExecuteReader();
                dr.Read();
                idCategory = dr.GetInt32(0);
                dr.Close();
            }

            query = "INSERT INTO Mem_cat (member_id, category_id)" +
                            " VALUES (" + id + ", " + idCategory + ")";

            cmd = new NpgsqlCommand(query, npgsqlConnection);
            dr = cmd.ExecuteReader();
            dr.Close();

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
