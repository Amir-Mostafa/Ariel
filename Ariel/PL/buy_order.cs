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
    public partial class buy_order : Form
    {
        public static buy_order buy_o;
        BL.buy_orders bl = new BL.buy_orders();
        BL.products b = new BL.products();
        BL.validation vald = new BL.validation();
        public DataTable g = new DataTable();
        public buy_order()
        {
            InitializeComponent();
            buy_o = this;
            comboBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            
            DataTable t = new DataTable();
            t = bl.all_products_name();
            comboBox3.DataSource = t;
            comboBox3.DisplayMember = "product_name";
            comboBox3.ValueMember = "product_id";


            g.Columns.Add("رقم الصنف");
            g.Columns.Add("اسم الصنف");
            g.Columns.Add("العدد ");
            dataGridView2.DataSource = g;



            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.FromArgb(119, 200, 255);

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 16);
            dataGridView2.RowTemplate.Height = 30;

            try
            {
                DataTable dd = new DataTable();
                dd = bl.get_max_id();
                int y = dd.Rows.Count;
                if (dd.Rows.Count > 0)
                {
                    if (dd.Rows[0]["max"].ToString() == "")
                        textBox1.Text = "1";
                    else
                    {
                        int x = int.Parse(dd.Rows[0]["max"].ToString()) + 1;
                        textBox1.Text = x.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(comboBox3.SelectedValue);
                textBox10.Text = x.ToString();
                DataTable f = new DataTable();

                f = bl.select_product_by_id(x);
                if (f.Rows.Count == 0)
                {
                    comboBox3.Focus();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في ادخال البيانات");
                comboBox3.Focus();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buy_order_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = g;
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {

                add_product();
            }

        }
        public void add_product()
        {
            if (textBox2.Text == "")
                textBox2.Text = "0";
            if (textBox16.Text == "")
                textBox16.Text = "0";
            if ((textBox16.Text != "0" || textBox2.Text != "0"))
            {
                try
                {

                    if (!vald.is_int(textBox2.Text) || !vald.is_int(textBox16.Text) || (vald.is_zero(textBox2.Text) && vald.is_zero(textBox16.Text)))
                    {
                        MessageBox.Show("ادخل بيانات صحيحه");
                        return;
                    }
                    DataTable d = bl.select_product_by_id(int.Parse(textBox10.Text));

                    int c_num = int.Parse(d.Rows[0]["num_in_packet"].ToString());

                    int p = int.Parse(textBox2.Text);
                    double calc = (p / (double)c_num) + int.Parse(textBox16.Text);

                    DataRow r = g.NewRow();
                    r[0] = textBox10.Text;
                    r[1] = comboBox3.Text;
                    r[2] = calc.ToString();
                    //r[3] = textBox2.Text;

                    if (index.Text != "")
                    {
                        g.Rows.InsertAt(r, int.Parse(index.Text));
                        index.Text = "";
                    }
                    else
                        g.Rows.InsertAt(r, 0);
                    dataGridView2.DataSource = g;
                    dataGridView2.Columns["رقم الصنف"].Visible = false;
                    comboBox3.Text = "";
                    textBox10.Text = "";
                    textBox16.Text = "";
                    textBox2.Text = "";
                    comboBox3.Focus();
                    save_order();
                    comboBox3.Focus(); comboBox3.Focus();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في ادخال البيانات");
                }
            }
            textBox2.Text = "";
            textBox16.Text = "";
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(comboBox3.SelectedValue);
                textBox10.Text = x.ToString();
                DataTable f = new DataTable();
                
                f = bl.select_product_by_id(x);
                 if(f.Rows.Count==0)
                 {
                     comboBox3.Focus();
                 }

            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في ادخال البيانات");
                comboBox3.Focus();
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_product();
            }

        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    double[] arr = new double[100];
            //    textBox10.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            //    comboBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            //    textBox16.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            //    dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
            //    comboBox3.Focus();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dd = new DataTable();
                dd = bl.get_max_id();
                int y = dd.Rows.Count;
                if (dd.Rows.Count > 0)
                {
                    if (dd.Rows[0]["max"].ToString() == "")
                        textBox1.Text = "1";
                    else
                    {
                        int x = int.Parse(dd.Rows[0]["max"].ToString()) + 1;
                        textBox1.Text = x.ToString();
                    }
                }
                g.Clear();
                dataGridView2.DataSource = g;
                total.Text = "";
                textBox10.Text = "";
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            save_order();
        }
        public void save_order()
        {
            try
            {
                double parsedValue;
                if (total.Text == "" || !double.TryParse(total.Text, out parsedValue))
                    total.Text = "0";

                DataTable q = new DataTable();
                q = bl.get_max_id();
                int x = dataGridView2.Rows.Count;
                //if (x <= 1)
                //{
                //    MessageBox.Show("يجب ادخال عمليات ");
                //    return;
                //}
                int m = 0;
                if (q.Rows[0]["max"].ToString() != "")
                    m = int.Parse(q.Rows[0]["max"].ToString());
                else
                    m = 0;
                if (int.Parse(textBox1.Text) <= m)
                {
                    //update first part 

                    bl.update_buy_order(int.Parse(textBox1.Text), total.Text, dateTimePicker1.Value.Date);

                    //update second part

                    //delete all operations
                    DataTable all_operations = bl.get_buy_operations(int.Parse(textBox1.Text));

                    for (int i = 0; i < all_operations.Rows.Count; i++)
                    {
                        int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                        double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                        DataTable p = new DataTable();
                        p = bl.select_product_by_id(product_id);
                        double amount = double.Parse(p.Rows[0]["amount"].ToString());

                        double final = amount - a;
                        bl.inc_product(product_id, final.ToString());
                    }
                    bl.delete_all_buy_operation(int.Parse(textBox1.Text));

                    //insert new operations

                    for (int i = 0; i < x - 1; i++)
                    {
                        int order_id = int.Parse(textBox1.Text);
                        int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                        string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        DateTime d = dateTimePicker1.Value.Date;
                        bl.add_buy_operation(order_id, product_id, amount, d);

                        DataTable dt = bl.select_product_by_id(product_id);

                        double am = double.Parse(dt.Rows[0]["amount"].ToString());
                        double final = am + double.Parse(amount);

                        bl.inc_product(product_id, final.ToString());
                    }
                    //MessageBox.Show("تم التعديل");
                }
                else
                {
                    //save header of order
                    bl.add_buy_order(int.Parse(textBox1.Text), total.Text, dateTimePicker1.Value.Date);


                    //add second part of buy order
                    for (int i = 0; i < x - 1; i++)
                    {
                        int order_id = int.Parse(textBox1.Text);
                        int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                        string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        DateTime d = dateTimePicker1.Value.Date;
                        bl.add_buy_operation(order_id, product_id, amount, d);

                        DataTable dt = bl.select_product_by_id(product_id);

                        double am = double.Parse(dt.Rows[0]["amount"].ToString());
                        double final = am + double.Parse(amount);

                        bl.inc_product(product_id, final.ToString());
                    }

                    //MessageBox.Show("تم");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حذف العنصر", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    DataTable all_operations = bl.get_buy_operations(int.Parse(textBox1.Text));

                    for (int i = 0; i < all_operations.Rows.Count; i++)
                    {
                        int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                        double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                        DataTable p = new DataTable();
                        p = bl.select_product_by_id(product_id);
                        double amount = double.Parse(p.Rows[0]["amount"].ToString());

                        double final = amount - a;
                        bl.inc_product(product_id, final.ToString());
                    }
                    int x = int.Parse(textBox1.Text);
                    bl.delete_buy_order(x);
                    bl.delete_all_buy_operation(x);
                    new_order();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
        public void new_order()
        {
            comboBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            g.Clear();
            total.Text = "";

            try
            {
                DataTable dd = new DataTable();
                dd = bl.get_max_id();
                int y = dd.Rows.Count;
                if (dd.Rows.Count > 0)
                {
                    if (dd.Rows[0]["max"].ToString() == "")
                        textBox1.Text = "1";
                    else
                    {
                        int x = int.Parse(dd.Rows[0]["max"].ToString()) + 1;
                        textBox1.Text = x.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            if (x > 0)
            {
            f:
                try
                {

                    BL.buy_orders bl = new BL.buy_orders();
                    DataTable d1, d2, d3;
                    d1 = new DataTable();
                    d2 = new DataTable();
                    
                    x--;
                    d1 = bl.bu_order_by_id(x);
                    d2 = bl.get_arabic_operation(x);
                    textBox1.Text = d1.Rows[0]["order_id"].ToString();
                    dateTimePicker1.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());
                    total.Text = d1.Rows[0]["total"].ToString();
                    dataGridView2.DataSource = d2;
                    g = d2;
                   
                }
                catch
                {
                    if (x > 0)
                    {
                        // MessageBox.Show("لا نوجد فاتوره برقم " + "  " + x);
                        goto f;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL.buy_orders bl = new BL.buy_orders();
            DataTable d1, d2;
            d1 = new DataTable();
            d2 = new DataTable();
            int x = int.Parse(textBox1.Text);
            DataTable gg = new DataTable();
            gg = bl.get_max_id();
            if (gg.Rows[0]["max"].ToString() != "" && x < int.Parse(gg.Rows[0]["max"].ToString()))
            {
            f:
                try
                {
                    x++;
                    d1 = bl.bu_order_by_id(x);
                    d2 = bl.get_buy_operations(x);
                  
                    d1 = bl.bu_order_by_id(x);
                    d2 = bl.get_arabic_operation(x);
                    textBox1.Text = d1.Rows[0]["order_id"].ToString();
                    dateTimePicker1.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());
                    total.Text = d1.Rows[0]["total"].ToString();
                    dataGridView2.DataSource = d2;
                    g = d2;
                }
                catch
                {
                    //   MessageBox.Show("لا نوجد فاتوره برقم " + "  " + x);
                    if (x < int.Parse(gg.Rows[0]["order_id"].ToString()))
                        goto f;
                }
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void total_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;
            if (total.Text == "" || !double.TryParse(total.Text, out parsedValue))
                total.Text = "0";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            comboBox3.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_product();
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip my_menu = new System.Windows.Forms.ContextMenuStrip();

                int currentMouseOverRow = dataGridView2.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    my_menu.Items.Add("تعديل").Name = "تحديث";
                    my_menu.Items.Add("حذف").Name = "حذف";
                }

                my_menu.Show(dataGridView2, new Point(e.X, e.Y));

                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu_ItemClicked);

            }
        }

        private void my_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.ToString() == "تحديث")
            {
                try
                {

                    textBox10.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    comboBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    
                    index.Text = dataGridView2.CurrentRow.Index.ToString();
                    int num_in_packet;
                    DataTable d = bl.select_product_by_id(int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()));
                    if (d.Rows[0]["num_in_packet"].ToString() != "")
                        num_in_packet = int.Parse(d.Rows[0]["num_in_packet"].ToString());
                    else
                        num_in_packet = 0;

                    int p = (int)double.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString());

                    double s = Math.Round((double.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString()) - p) * num_in_packet);
                    textBox16.Text = p.ToString();
                    textBox2.Text = s.ToString();
                    dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                    comboBox3.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                comboBox3.Focus();
            }
            save_order();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
