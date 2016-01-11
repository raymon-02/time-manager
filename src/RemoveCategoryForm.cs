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
    public partial class RemoveCategoryForm : Form
    {
        private readonly NpgsqlConnection npgsqlConnection;

        private readonly int id;
        private readonly IDictionary<string, long> categories; 
        public RemoveCategoryForm(int id, IDictionary<string, long> categories)
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();

            this.id = id;
            this.categories = categories;

            initData();
        }

        private void initData()
        {
            foreach (var e in categories.Keys)
            {
                dataListBox.Items.Add(e);
            }
            
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Remove selected categories?", @"Removing categories", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            foreach (var item in dataListBox.CheckedItems)
            {
                var query = "SELECT Mem_cat.id FROM Mem_cat" +
                            " JOIN Category ON (Mem_cat.category_id=Category.id)" +
                            " WHERE Mem_cat.member_id=" + id +
                            " AND Category.name='" + item.ToString() + "'";

                var cmd = new NpgsqlCommand(query, npgsqlConnection);
                var dr = cmd.ExecuteReader();
                dr.Read();
                var idMemCat = dr[0];
                dr.Close();

                query = "DELETE FROM Data WHERE mem_cat_id=" + idMemCat;
                cmd = new NpgsqlCommand(query, npgsqlConnection);
                dr = cmd.ExecuteReader();
                dr.Close();

                query = "DELETE FROM Mem_cat WHERE id=" + idMemCat;
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
