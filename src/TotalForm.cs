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
    public partial class TotalForm : Form
    {
        private readonly ListView list;
        private readonly IDictionary<string, long> categories; 

        public TotalForm(ListView list, IDictionary<string, long> categories)
        {
            InitializeComponent();

            this.list = list;
            this.categories = categories;

            initData();
        }

        private void initData()
        {
            IDictionary<string, long> categoriesHours = new Dictionary<string, long>();
            foreach (var category in categories.Keys)
            {
                categoriesHours.Add(category, 0);
            }


            foreach (ListViewItem item in list.Items)
            {
                var startTime = item.SubItems[0].Text;
                var endTime = item.SubItems[1].Text;
                var category = item.SubItems[2].Text;

                var total = parseStringTime(endTime) - parseStringTime(startTime);
                categoriesHours[category] += total;
            }

            foreach (var e in categoriesHours)
            {
                var item = new ListViewItem(e.Key);
                item.SubItems.Add((e.Value / 60).ToString());
                totalListView.Items.Add(item);
            }
        }

        private int parseStringTime(string time)
        {
            var hours = int.Parse(time.Substring(0, 2));
            var minutes = int.Parse(time.Substring(3, 2));

            return hours * 60 + minutes;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
