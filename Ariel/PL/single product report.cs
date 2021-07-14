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
    public partial class single_product_report : Form
    {
        BL.buy_orders b = new BL.buy_orders();
        BL.sell_order bl = new BL.sell_order();
        public static single_product_report single_product;
        public single_product_report()
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
            single_product = this;



            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.Tan;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 16);
            dataGridView1.RowTemplate.Height = 30;
        }

        private void single_product_report_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                BL.products b = new BL.products();
                DataTable t = b.product_in_date(date1.Value.Date, date2.Value.Date, Convert.ToInt32(comboBox3.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue));
                single_product_report.single_product.dataGridView1.DataSource = t;
                double sum = 0;
                for (int i = 0; i < t.Rows.Count; i++)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
