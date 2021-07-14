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
    public partial class update_product : Form
    {
        BL.products bl = new BL.products();
        public update_product()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد تديل العنصر", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bl.update_prduct(int.Parse(id.Text), name.Text, price.Text, int.Parse(num.Text), int.Parse(min.Text), code.Text);
                    DataTable dt = bl.search("");
                     products.prods.dataGridView1.DataSource = dt;
                    name.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_product_Load(object sender, EventArgs e)
        {
            try
            {
                BL.buy_orders b = new BL.buy_orders();
                DataTable pp = b.select_product_by_id(int.Parse( products.prods.dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                id.Text = pp.Rows[0]["product_id"].ToString();
                name.Text = pp.Rows[0]["product_name"].ToString();
                num.Text = pp.Rows[0]["num_in_packet"].ToString();
                price.Text = pp.Rows[0]["price"].ToString();
                min.Text = pp.Rows[0]["min_amount"].ToString();
                code.Text = pp.Rows[0]["code"].ToString();
            }
            catch
            {

            }
                
        }
    }
}
