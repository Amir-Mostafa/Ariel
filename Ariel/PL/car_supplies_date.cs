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
    public partial class car_supplies_date : Form
    {
        BL.car_virtually bll = new BL.car_virtually();
        BL.sell_order bl = new BL.sell_order();
        
        public car_supplies_date()
        {
            InitializeComponent();
            
            DataTable t = bl.all_clints();
            comboBox3.DataSource = t;
            comboBox3.DisplayMember = "clint_name";
            comboBox3.ValueMember = "clint_id";
        }

        private void car_supplies_date_Load(object sender, EventArgs e)
        {
            date1.Value = DateTime.Now;
            date2.Value = DateTime.Now;
        }

        private void report_Click(object sender, EventArgs e)
        {
            try
            {
                car_supplies f = new car_supplies();
                double sum = 0;
                DataTable d = bll.supplies_report(date1.Value.Date,date2.Value.Date, Convert.ToInt32(comboBox3.SelectedValue));
                car_supplies.car_sup.dataGridView1.DataSource = d;
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    if (d.Rows[i]["الاجمالي"].ToString() == "")
                        car_supplies.car_sup.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    else
                        sum += double.Parse(d.Rows[i]["الاجمالي"].ToString());
                }
                car_supplies.car_sup.total.Text = sum.ToString();
                f.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
