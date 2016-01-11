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
        private string role;
        private readonly NpgsqlConnection npgsqlConnection;

        private readonly IDictionary<int, string> idCategories; 
        private readonly IDictionary<string, long> categoriesHours; 

        public ManagerForm(LoginForm preForm, int id)
        {
            InitializeComponent();

            this.preForm = preForm;
            this.id = id;

            idCategories = new Dictionary<int, string>();
            categoriesHours = new SortedDictionary<string, long>();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();

            init();
            initSettings();
        }

        private void initSettings()
        {
            var query = "SELECT role FROM Member WHERE id=" + id;
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            dr.Read();
            role = dr.GetString(0);

            if (role != "admin")
            {
                adminButton.Hide();
            }

            dr.Close();
        }

        private void init()
        {
            initDataListView();
            initTotaLabel();
            initCategories();
            initTotalListView();
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

            while (dr.Read())
            {
                var startTime = dr.GetTimeSpan(0);
                var endTime = dr.GetTimeSpan(1);
                var category = dr.GetString(2);

                var item = new ListViewItem(startTime.ToString());
                item.SubItems.Add(endTime.ToString());
                item.SubItems.Add(category);
                dataListView.Items.Add(item);
            }

            dr.Close();
        }

        private void initTotaLabel()
        {
            totalLabel.Text = "Total for all time since\n";

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

        private void initTotalListView()
        {
            totalListView.Items.Clear();

            foreach (var e in categoriesHours)
            {
                var item = new ListViewItem(e.Key);
                item.SubItems.Add(e.Value.ToString());
                totalListView.Items.Add(item);
            }
        }

        private void initCategories()
        {
            idCategories.Clear();
            categoriesHours.Clear();

            var query = "SELECT Category.name, Mem_cat.category_id" +
                        " FROM Category" +
                        " JOIN Mem_cat ON (Category.id=Mem_cat.category_id)" +
                        " WHERE Mem_cat.member_id=" + id;

            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var category = dr.GetString(0);
                var categoryId = dr.GetInt32(1);

                idCategories.Add(categoryId, category);
            }
            dr.Close();

            countHoursForCategories();
        }

        private void countHoursForCategories()
        {
            foreach (var categoryId in idCategories.Keys)
            {
                var query = "SELECT Data.start_t, Data.end_t FROM Data" +
                            " JOIN Mem_cat ON (Data.mem_cat_id=Mem_cat.id)" +
                            " WHERE Mem_cat.member_id=" + id +
                            " AND Mem_cat.category_id=" + categoryId;

                var cmd = new NpgsqlCommand(query, npgsqlConnection);
                var dr = cmd.ExecuteReader();

                var sum = 0;
                while (dr.Read())
                {
                    var startTime = dr.GetTimeSpan(0);
                    var endTime = dr.GetTimeSpan(1);
                    sum += endTime.Hours*60 + endTime.Minutes -
                           (startTime.Hours*60 + startTime.Minutes);
                }
                dr.Close();

                categoriesHours.Add(idCategories[categoryId], sum / 60);
            }
        }

        private void AddRecord(DateTime date, string startTime, string endTime, string category)
        {
            var dateQuery = "'" + date.Year + "-" + date.Month + "-" + date.Day + "'";
            var query = "SELECT Mem_cat.id FROM Mem_cat" +
                            " JOIN Category ON (Mem_cat.category_id=Category.id)" +
                            " WHERE Mem_cat.member_id=" + id +
                            " AND Category.name='" + category + "'";

            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            dr.Read();
            var memCatId = dr.GetInt32(0);
            dr.Close();

            query = "INSERT INTO Data (mem_cat_id, day, start_t, end_t)" +
                            " VALUES (" + memCatId +
                            ", " + dateQuery +
                            ", '" + startTime +
                            "', '" + endTime + "')";

            cmd = new NpgsqlCommand(query, npgsqlConnection);
            dr = cmd.ExecuteReader();
            dr.Close();
        }

        private void RemoveRecord(DateTime date, string startTime, string endTime, string category)
        {
            var dateQuery = "'" + date.Year + "-" + date.Month + "-" + date.Day + "'";
            var query = "SELECT Mem_cat.id FROM Mem_cat" +
                            " JOIN Category ON (Mem_cat.category_id=Category.id)" +
                            " WHERE Mem_cat.member_id=" + id +
                            " AND Category.name='" + category + "'";

            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            dr.Read();
            var memCatId = dr.GetInt32(0);
            dr.Close();

            query = "DELETE FROM Data WHERE" +
                    " mem_cat_id=" + memCatId +
                    " AND day=" + dateQuery +
                    " AND start_t='" + startTime +
                    "' AND end_t='" + endTime + "'";

            cmd = new NpgsqlCommand(query, npgsqlConnection);
            dr = cmd.ExecuteReader();
            dr.Close();
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            var editRecordForm = new EditRecordForm(id, categoriesHours, dateTimePicker.Value);
            var result = editRecordForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            var startTime = editRecordForm.StartTime;
            var endTime = editRecordForm.EndTime;
            var category = editRecordForm.Category;
            var date = dateTimePicker.Value;
            
            AddRecord(date, startTime, endTime, category);
            init();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"No selected record", @"Editing record", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (dataListView.SelectedItems.Count > 1)
            {
                MessageBox.Show(@"Only one record must be selected", @"Editing record", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var item = dataListView.SelectedItems[0];
            var date = dateTimePicker.Value;
            var startTime = item.SubItems[0].Text;
            var endTime = item.SubItems[1].Text;
            var category = item.SubItems[2].Text;

            var editRecordForm = new EditRecordForm(id, categoriesHours, startTime, endTime, date);
            var result = editRecordForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            RemoveRecord(date, startTime, endTime, category);

            startTime = editRecordForm.StartTime;
            endTime = editRecordForm.EndTime;
            category = editRecordForm.Category;

            AddRecord(date, startTime, endTime, category);
            init();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (dataListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"No selected records", @"Removing records", MessageBoxButtons.OK,
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
                var date = dateTimePicker.Value;
                var startTime = item.SubItems[0].Text;
                var endTime = item.SubItems[1].Text;
                var category = item.SubItems[2].Text;

                RemoveRecord(date, startTime, endTime, category);
            }

            init();
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

            init();
        }

        private void sumButton_Click(object sender, EventArgs e)
        {
            var totalForm = new TotalForm(dataListView, categoriesHours);
            totalForm.ShowDialog();
        }

        private void signoutButton_Click(object sender, EventArgs e)
        {
            npgsqlConnection.Close();
            preForm.Show();
            Hide();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            var adminForm = new AdminForm();
            adminForm.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            npgsqlConnection.Close();
            preForm.Close();
        }

        private void dateTimePicker_CloseUp(object sender, EventArgs e)
        {
            initDataListView();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            signoutButton_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnClosed(e);
        }

        private void addFromStandartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var standartCategoryForm = new StandartCategoryForm(id);
            standartCategoryForm.ShowDialog();

            init();
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var categoryForm = new CategoryForm(id);
            categoryForm.ShowDialog();

            init();
        }

        private void editCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var removeCategoryForm = new RemoveCategoryForm(id, categoriesHours);
            removeCategoryForm.ShowDialog();

            init();
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editUserForm = new EditUserForm(id, id);
            editUserForm.ShowDialog();
        }
    }
}
