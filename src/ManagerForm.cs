using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace TimeManager
{
    public partial class ManagerForm : Form
    {
        private readonly LoginForm preForm;
        private readonly int id;
        private readonly NpgsqlConnection npgsqlConnection;

        public ManagerForm(LoginForm preForm, int id)
        {
            InitializeComponent();

            this.preForm = preForm;
            this.id = id;

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();

            initDataListView();
            initTotaLabel();
        }

        private void initDataListView()
        {
            dataListView.Items.Clear();

            var date = dateTimePicker.Value.Date;
            var dateQuery = "'" + date.Year + "-" + date.Month + "-" + date.Day + "'";
            var query = "SELECT Data.start_t, Data.end_t, Category.name" +
                        " FROM Data" +
                        " JOIN Mem_cat ON (Data.mem_cat_id=Mem_cat.id)" +
                        " JOIN Category ON (Mem_cat.category_id=Category.id)" +
                        " WHERE Mem_cat.member_id=" + id +
                        " AND Data.day=" + dateQuery;

            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                dr.Close();
                return;
            }

            var i = 0;
            while (i < dr.FieldCount)
            {
                var startTime = dr.GetTimeSpan(i);
                i++;
                var endTime = dr.GetTimeSpan(i);
                i++;
                var category = dr.GetString(i);

                var item = new ListViewItem(startTime.ToString());
                item.SubItems.Add(endTime.ToString());
                item.SubItems.Add(category);
                dataListView.Items.Add(item);

                i++;
            }

            dr.Close();
        }

        private void initTotaLabel()
        {
            var query = "SELECT Data.day FROM Data" +
                        " JOIN Mem_cat ON (Data.mem_cat_id=Mem_cat.id)" +
                        " JOIN Category ON (Mem_cat.category_id=Category.id)" +
                        " WHERE Mem_cat.member_id=" + id +
                        " ORDER BY Data.day LIMIT 1";

            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                totalLabel.Text += @"----/--/--";
                dr.Close();
                return;
            }

            var date = dr.GetDate(0);
            totalLabel.Text += date.ToString();

            dr.Close();
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {

        }
        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"No selected record", @"Editing record", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (dataListView.SelectedItems.Count > 1)
            {
                MessageBox.Show(@"Only one record must be selected", @"Editing record", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var item = dataListView.SelectedItems[0];



            var date = dateTimePicker.Value.Date;
            var timeStart = item.SubItems[0];
            var timeEnd = item.SubItems[1];

            var dateQuery = "'" + date.Year + "-" + date.Month + "-" + date.Day + "'";
            var query = "DELETE FROM Data WHERE day=" + dateQuery +
                        " AND start_t='" + timeStart.Text +
                        "' AND end_t='" + timeEnd.Text + "'";
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            dr.Close();

//            query = "INSERT INTO Data(day, start_t, end_t) VALUES (" + dateQuery +
//                        ", '" + timeStart.Text +
//                        "', '" + timeEnd.Text + "'";
//            cmd = new NpgsqlCommand(query, npgsqlConnection);
//            dr = cmd.ExecuteReader();
//            dr.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (dataListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"No records selected", @"Removing records", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(@"Are you sure?", @"Removing records", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            foreach (ListViewItem item in dataListView.SelectedItems)
            {
                var date = dateTimePicker.Value.Date;
                var timeStart = item.SubItems[0];
                var timeEnd = item.SubItems[1];


                var dateQuery = "'" + date.Year + "-" + date.Month + "-" + date.Day + "'";
                var query = "DELETE FROM Data WHERE day=" + dateQuery +
                            " AND start_t='" + timeStart.Text +
                            "' AND end_t='" + timeEnd.Text + "'";
                var cmd = new NpgsqlCommand(query, npgsqlConnection);
                var dr = cmd.ExecuteReader();
                dr.Close();

                dataListView.Items.Remove(item);
            }

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            
            var result = MessageBox.Show(@"Are you sure?", @"Removing records", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            var date = dateTimePicker.Value.Date;
            var dateQuery = "'" + date.Year + "-" + date.Month + "-" + date.Day + "'";
            var query = "DELETE FROM Data WHERE day=" + dateQuery;
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            dr.Close();

            dataListView.Items.Clear();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            preForm.Show();
        }
        private void dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            initDataListView();
        }
    }
}
