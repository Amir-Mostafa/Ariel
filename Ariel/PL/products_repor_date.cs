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
    public partial class products_repor_date : Form
    {
        public static products_repor_date p_r;
        public products_repor_date()
        {
            InitializeComponent();
            p_r = this;
        }

        private void products_repor_date_Load(object sender, EventArgs e)
        {

        }

        private void 
            
            
            
            
            ifuThinButton21_Click(object sender, EventArgs e)
        {
            Form f = new products_report();
            f.Show();
            this.Hide();
        }

        private void report_Click(object sender, EventArgs e)
        {
            Form f = new products_report();
            f.Show();
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
