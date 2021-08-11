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
    public partial class disc_date : Form
    {
        public disc_date()
        {
            InitializeComponent();
        }

        private void report_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new disc_report();

                BL.car bl = new BL.car();
                DataTable data = bl.all_disc(date1.Value.Date, date2.Value.Date);

                disc_report.disc_all.dataGridView1.DataSource = data;
                double sum = 0;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if(data.Rows[i]["خصم"].ToString()!="")
                    sum += double.Parse(data.Rows[i]["خصم"].ToString());
                }

                disc_report.disc_all.total.Text = sum.ToString();
                this.Hide();
                f.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
