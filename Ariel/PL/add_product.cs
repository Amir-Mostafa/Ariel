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
    public partial class add_product : Form
    {
        public add_product()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                double distance;
                BL.products bl = new BL.products();

                if (price.Text == "" || num.Text == "" || min.Text == "" || code.Text == "")
                    MessageBox.Show("ادخل بيانات صحيحه");

                else if (!double.TryParse(price.Text, out distance) || !double.TryParse(num.Text, out distance) || !double.TryParse(min.Text, out distance))
                    MessageBox.Show("ادخل بيانات صحيحه");
                else
                {
                    bl.insert(name.Text, price.Text, int.Parse(num.Text), int.Parse(min.Text), code.Text);
                    name.Text = "";
                    amo.Text = "";
                    DataTable dt = bl.products_name();

                   products.prods.dataGridView1.DataSource = dt;
                    name.Focus();
                    price.Text = "";
                    num.Text = "";
                    min.Text = "";
                    code.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
