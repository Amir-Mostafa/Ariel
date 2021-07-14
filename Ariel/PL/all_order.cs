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
    public partial class all_order : Form
    {
        BL.sell_order bl = new BL.sell_order();
        int mov, mx, my;
        public all_order()
        {
            InitializeComponent();
            DataTable d = new DataTable();
            d = bl.get_all_order(search.Text);
            dataGridView1.DataSource = d;


            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Green;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Tan;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dataGridView1.RowTemplate.Height = 30;

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Black;
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.Red;
            label1.ForeColor = Color.Black;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void all_order_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable d = new DataTable();
                d = bl.get_all_order(search.Text);
                dataGridView1.DataSource = d;
            }
            catch
            {

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                orders_form f = new orders_form();
                DataTable d1, d2, d3;
                d1 = new DataTable();
                d2 = new DataTable();

                int x = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                d1 = bl.sell_order_by_id(x);
                d2 = bl.sell_operations_arabic(x);
                orders_form.orders.total.Text = d1.Rows[0]["total"].ToString();
                orders_form.orders.textBox1.Text = d1.Rows[0]["order_id"].ToString();
                orders_form.orders.dateTimePicker1.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());
                orders_form.orders.comboBox1.Text = d1.Rows[0]["clint_name"].ToString();
                orders_form.orders.dataGridView2.DataSource = d2;
                orders_form.orders.g = d2;
                orders_form.orders.nums.Text = (orders_form.orders.dataGridView2.Rows.Count - 1).ToString();
                orders_form.orders.compobox_back_color();

                f.Show();

            }
            catch
            {

            }
        }
    }
}
