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
    public partial class SignUpForm : Form
    {
        private readonly NpgsqlConnection npgsqlConnection;

        public SignUpForm()
        {
            InitializeComponent();

            npgsqlConnection = DataBaseConnection.GetConnection();
            npgsqlConnection.Open();
        }

        private void signupSignUpButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelSignUpButton_Click(object sender, EventArgs e)
        {
            npgsqlConnection.Close();
            SignUpForm.ActiveForm.Close();
        }
    }
}
