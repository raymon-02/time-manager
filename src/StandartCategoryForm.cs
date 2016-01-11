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
    public partial class StandartCategoryForm : Form
    {
        private readonly NpgsqlConnection npgsqlConnection;

        private readonly int id;
        public StandartCategoryForm(int id)
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();

            this.id = id;

            initData();
        }

        private void initData()
        {
            var query = "SELECT name FROM Category ORDER BY name";

            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataListBox.Items.Add(dr[0]);
            }

            dr.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Add selected categories?", @"Adding categories", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            IDictionary<string, int> categories = new Dictionary<string, int>();

            foreach (var item in dataListBox.CheckedItems)
            {
                var query = "SELECT id FROM Category" +
                            " WHERE name = '" + item.ToString() + "'";

                var cmd = new NpgsqlCommand(query, npgsqlConnection);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    categories.Add(item.ToString(), dr.GetInt32(0));
                }

                dr.Close();
            }
            
            foreach (var i in categories.Values)
            {
                var query = "SELECT id FROM Mem_cat" +
                            " WHERE member_id=" + id + " AND category_id=" + i;

                var cmd = new NpgsqlCommand(query, npgsqlConnection);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    continue;
                }
                dr.Close();

                query = "INSERT INTO Mem_cat (member_id, category_id)" + 
                            " VALUES (" + id + ", " + i + ")";

                cmd = new NpgsqlCommand(query, npgsqlConnection);
                dr = cmd.ExecuteReader();
                dr.Close();
            }

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
