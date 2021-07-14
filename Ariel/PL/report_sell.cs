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
     
    public partial class report_sell : Form
    {
        public static report_sell R_S;
        public report_sell()
        {
            InitializeComponent();
            R_S = this;
            

            date1.Value = DateTime.Now;
            date2.Value = DateTime.Now;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form f = new repors_sell();
            f.Show();
            this.Hide();
        }

        private void report_sell_Load(object sender, EventArgs e)
        {
            
        }

        private void report_Click(object sender, EventArgs e)
        {
            Form f = new repors_sell();
            f.Show();

        }
    }
}
