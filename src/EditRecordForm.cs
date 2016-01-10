using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace TimeManager
{
    public partial class EditRecordForm : Form
    {
        private readonly NpgsqlConnection npgsqlConnection;

        private readonly IDictionary<string, long> categories;
        private readonly DateTime date;

        public EditRecordForm(IDictionary<string, long> categories, DateTime date)
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();

            this.categories = categories;
            this.StartTime = "00:00";
            this.EndTime = "00:00";
            this.date = date;

            initForm("Add");
        }
        public EditRecordForm(IDictionary<string, long> categories, string startTime, string endTime, DateTime date)
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();

            this.categories = categories;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.date = date;

            startTimePicker.Text = startTime;
            endTimePicker.Text = endTime;

            initForm("Edit");
        }

        public string StartTime { get; private set; }

        public string EndTime { get; private set; }

        public string Category { get; private set; }

        private void initForm(string action)
        {
            this.Text = action + @" record";
            titleLabel.Text = action + titleLabel.Text + 
                date.Year + @"-" + date.Month + @"-" + date.Day;

            foreach (var category in categories.Keys)
            {
                categoryBox.Items.Add(category);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (startTimePicker.Value > endTimePicker.Value)
            {
                MessageBox.Show(@"Start time must be less than End time", @"Time fields", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var startTime = startTimePicker.Text;
            var endTime = endTimePicker.Text;

            var dateQuery = "'" + date.Year + "-" + date.Month + "-" + date.Day + "'";
            var query = "SELECT Data.id FROM Data" +
                            " WHERE Data.day=" + dateQuery +
                            " AND Data.start_t='" + startTime +
                            "' AND Data.end_t='" + endTime + "'";
            var cmd = new NpgsqlCommand(query, npgsqlConnection);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                MessageBox.Show(@"This record is already exist", @"Adding record", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            dr.Close();

            if (categoryBox.Text == "")
            {
                MessageBox.Show(@"Category field must be not empty", @"Category field", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(@"Save changes?", @"Saving changes", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            StartTime = startTimePicker.Text;
            EndTime = endTimePicker.Text;
            Category = categoryBox.Text;
            DialogResult = DialogResult.OK;

            npgsqlConnection.Close();

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            npgsqlConnection.Close();

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
