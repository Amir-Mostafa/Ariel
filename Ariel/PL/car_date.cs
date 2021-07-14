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
    public partial class car_date : Form
    {
        BL.sell_order bl = new BL.sell_order();
        public static car_date c_d;
        public car_date()
        {
            InitializeComponent();
            c_d = this;

            DataTable t = bl.all_clints();
            comboBox3.DataSource = t;
            comboBox3.DisplayMember = "clint_name";
            comboBox3.ValueMember = "clint_id";
        }

        private void car_date_Load(object sender, EventArgs e)
        {
            date1.Value = DateTime.Now;
            date2.Value = DateTime.Now;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form f = new car_sell_report();
            f.Show();
            this.Hide();
        }

        private void date2_onValueChanged(object sender, EventArgs e)
        {

        }

        private void date1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void report_Click(object sender, EventArgs e)
        {
            Form f = new car_sell_report(); f.Show(); this.Hide();
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
