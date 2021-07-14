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
    public partial class gifts_date : Form
    {
        public gifts_date()
        {
            InitializeComponent();
        }

        private void report_Click(object sender, EventArgs e)
        {
            Form f = new free_products();

            try
            {
                BL.car b = new BL.car();
                free_products.free.dataGridView1.DataSource = b.all_gifts(date1.Value.Date,date2.Value.Date);
                double total = 0;
                for (int i = 0; i < free_products.free.dataGridView1.Rows.Count - 1; i++)
                {
                    if (free_products.free.dataGridView1.Rows[i].Cells[3].Value.ToString()!="")
                    total += double.Parse(free_products.free.dataGridView1.Rows[i].Cells[3].Value.ToString());
                    else
                        free_products.free.dataGridView1.Rows[i].Cells[3].Value="0";
                }
                free_products.free.total.Text = total.ToString();
            }
            catch
            {

            }
            this.Hide();
            f.Show();
        }
    }
}
