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
    public partial class all_buy_order : Form
    {
        DataTable dt = new DataTable();
        BL.buy_orders bl = new BL.buy_orders();
        public all_buy_order()
        {
            InitializeComponent();
            dt = bl.all_buy_order();
            dataGridView1.DataSource = dt;
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

        private void all_buy_order_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                dataGridView1.DataSource = bl.search_buy_order(textBox1.Text);
            }
            catch
            {

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                buy_order f = new buy_order();
                f.Show();
                BL.buy_orders bl = new BL.buy_orders();
                DataTable d1, d2, d3;
                d1 = new DataTable();
                d2 = new DataTable();

                int x=int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                d1 = bl.bu_order_by_id(x);
                d2 = bl.get_arabic_operation(x);
                textBox1.Text = d1.Rows[0]["order_id"].ToString();
                buy_order.buy_o.textBox1.Text = x.ToString();
                buy_order.buy_o.dateTimePicker1.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());
                buy_order.buy_o.total.Text = d1.Rows[0]["total"].ToString();
                buy_order.buy_o.dataGridView2.DataSource = d2;
                buy_order.buy_o.g = d2;
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
