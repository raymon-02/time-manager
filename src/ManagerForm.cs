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
        private LoginForm preForm;
        private int id;
        private readonly NpgsqlConnection npgsqlConnection;

        public ManagerForm(LoginForm preForm, int id)
        {
            InitializeComponent();

            this.preForm = preForm;
            this.id = id;

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();


        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

        }

        private void addEventButton_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            preForm.Show();
        }
    }
}
