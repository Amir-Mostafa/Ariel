using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ariel.PL
{
    public partial class form_config : Form
    {
        public form_config()
        {
            InitializeComponent();
            txtServer.Text = Properties.Settings.Default.server;
            txtDatabase.Text = Properties.Settings.Default.database;
            if (Properties.Settings.Default.mode == "SQL")
            {
                rbsql.Checked = true;
                txtUsername.Text = Properties.Settings.Default.id;
                txtPass.Text = Properties.Settings.Default.password;
            }
            else
            {
                rbwin.Checked = true;
                txtUsername.Text = "";
                txtPass.Text = "";
                txtUsername.ReadOnly = true;
                txtPass.ReadOnly = true;
            }

        }

        private void form_config_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.server = txtServer.Text;
            Properties.Settings.Default.database = txtDatabase.Text;
            Properties.Settings.Default.mode = rbwin.Checked == true ? "windows" : "SQL";
            Properties.Settings.Default.id = txtUsername.Text;
            Properties.Settings.Default.password = txtPass.Text;
            Properties.Settings.Default.Save();
        }

        private void rbwin_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = true;
            txtPass.ReadOnly = true;
        }

        private void rbsql_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = false;
            txtPass.ReadOnly = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
