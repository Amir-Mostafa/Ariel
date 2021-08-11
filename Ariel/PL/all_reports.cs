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
    public partial class all_reports : Form
    {
        public all_reports()
        {
            InitializeComponent();
        }

        private void 
            
            
            ifuThinButton21_Click(object sender, EventArgs e)
        {
           
        }

        private void 
            
            ifuThinButton24_Click(object sender, EventArgs e)
        {
            Form f = new report_sell();
            f.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Form f = new car_date();
            f.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Form f = new car_now();
            f.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            Form f = new products_repor_date();
            f.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form f = new report_sell();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new car_date();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new car_now();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new products_repor_date();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new mony();
            f.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f = new all_mony();
            this.Hide();
            f.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form f = new gifts_date();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form f = new notifications_date();
            this.Hide();
            f.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form f = new outgoings_report();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new product_in_date();
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form f = new sells_car_product();
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pdf_date f = new pdf_date();
            f.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form f = new car_supplies_date();
            f.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            disc_date f = new disc_date();
            f.Show();
        }
    }
}
