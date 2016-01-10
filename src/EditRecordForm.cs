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

namespace TimeManager
{
    public partial class EditRecordForm : Form
    {
        private readonly IDictionary<string, long> categories;
        private string startTime;
        private string endTime;
        private readonly string date;

        public EditRecordForm(IDictionary<string, long> categories, string date)
        {
            InitializeComponent();

            this.categories = categories;
            this.date = date;

            initForm("Add");
        }
        public EditRecordForm(IDictionary<string, long> categories, string startTime, string endTime, string date)
        {
            InitializeComponent();

            this.categories = categories;
            this.startTime = startTime;
            this.endTime = endTime;
            this.date = date;

            initForm("Edit");
        }

        private void initForm(string action)
        {
            this.Text = action + @" record";
            titleLabel.Text = action + titleLabel.Text + date;

            foreach (var category in categories.Keys)
            {
                categoryBox.Items.Add(category);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
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

            startTime = startTimePicker.Text;
            endTime = endTimePicker.Text;
            DialogResult = DialogResult.OK;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
