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
    public partial class pdf_date : Form
    {
        public pdf_date()
        {
            InitializeComponent();
            DataTable t = new DataTable();
            BL.sell_order bl = new BL.sell_order();
            t = bl.all_clints();
            comboBox1.DataSource = t;
            comboBox1.DisplayMember = "clint_name";
            comboBox1.ValueMember = "clint_id";
        }

        private void pdf_date_Load(object sender, EventArgs e)
        {

        }

        private void report_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new pdf_report();

                BL.car bl = new BL.car();

                DataTable data= bl.all_pdf(Convert.ToInt32(comboBox1.SelectedValue), date1.Value.Date, date2.Value.Date);

                pdf_report.pdf_all.dataGridView1.DataSource = data;


                double sum = 0;
                for (int i=0;i<data.Rows.Count;i++)
                {
                    sum += double.Parse(data.Rows[i]["pdf"].ToString());
                }
                
                pdf_report.pdf_all.total.Text = sum.ToString();
                this.Hide();
                f.Show();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
