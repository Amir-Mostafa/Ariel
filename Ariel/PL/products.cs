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
    public partial class products : Form
    {
        BL.products bl = new BL.products();
        public static products prods;
        public products()
        {
            InitializeComponent();
            prods = this;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form f = new add_product();
            f.Show();
        }

        private void products_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bl.products_name();
                
                dataGridView1.DataSource = dt;
                //name.Focus();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bl.search(textBox3.Text);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CursorChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                //BL.buy_orders b = new BL.buy_orders();

                //DataTable pp = b.select_product_by_id(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                //id.Text = pp.Rows[0]["product_id"].ToString();
                //name.Text = pp.Rows[0]["product_name"].ToString();
                //num.Text = pp.Rows[0]["num_in_packet"].ToString();
                //price.Text = pp.Rows[0]["price"].ToString();
                //min.Text = pp.Rows[0]["min_amount"].ToString();
                //code.Text=pp.Rows[0]["code"].ToString();

                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f = new update_product();
            f.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            


        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل تريد حذف العنصر", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bl.delete(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    DataTable dt = bl.search("");
                    dataGridView1.DataSource = dt;
                    
                    //name.Focus();
                    //name.Text = "";
                    //price.Text = "";
                    //num.Text = "";
                    //min.Text = "";
                    //code.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void price_Leave(object sender, EventArgs e)
        {
            
        }

        private void min_Leave(object sender, EventArgs e)
        {
           
        }

        private void code_Leave(object sender, EventArgs e)
        {
            button7.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
