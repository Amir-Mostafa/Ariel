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
    public partial class product_in_date : Form
    {
        BL.buy_orders b = new BL.buy_orders();
        BL.sell_order bl = new BL.sell_order();
        public product_in_date()
        {
            InitializeComponent();
           
            DataTable t = new DataTable();
            t = b.all_products_name();
            comboBox3.DataSource = t;
            comboBox3.DisplayMember = "product_name";
            comboBox3.ValueMember = "product_id";


            t = bl.all_clints();
            comboBox1.DataSource = t;
            comboBox1.DisplayMember = "clint_name";
            comboBox1.ValueMember = "clint_id";
        }

        private void product_in_date_Load(object sender, EventArgs e)
        {

        }

        private void report_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = new single_product_report();
                BL.products b = new BL.products();
                DataTable t = b.product_in_date(date1.Value.Date, date2.Value.Date, Convert.ToInt32(comboBox3.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue));
                single_product_report.single_product.dataGridView1.DataSource = t;
                double sum = 0;
                for (int i = 0; i < t.Rows.Count;i++ )
                {
                    sum += double.Parse(t.Rows[i]["الكميه"].ToString());
                }
                single_product_report.single_product.total.Text = sum.ToString();


                 t = b.get_car_sells_products(date1.Value.Date, date2.Value.Date, Convert.ToInt32(comboBox3.SelectedValue),Convert.ToInt32(comboBox1.SelectedValue));

                 sum = 0;
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    sum += double.Parse(t.Rows[i]["الكميه"].ToString());
                }
                single_product_report.single_product.total2.Text = sum.ToString();

                single_product_report.single_product.textBox1.Text = (double.Parse(single_product_report.single_product.total.Text) - double.Parse(single_product_report.single_product.total2.Text)).ToString();

                

                    this.Hide();
                
                f.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

 
        }
    }
}
