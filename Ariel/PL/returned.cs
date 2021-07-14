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
    public partial class returned : Form
    {
        BL.validation vald = new BL.validation();
        BL.buy_orders b = new BL.buy_orders();
        BL.products p = new BL.products();
        BL.sell_order c = new BL.sell_order();
        BL.returned_class bl = new BL.returned_class();
        BL.car car = new BL.car();
        DataTable g = new DataTable();
        public returned()
        {
            InitializeComponent();


            try
            {
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

            date.Value = DateTime.Now;

            DataTable t = new DataTable();
            t = b.all_products_name();
            comboBox3.DataSource = t;
            comboBox3.DisplayMember = "product_name";
            comboBox3.ValueMember = "product_id";

                DataTable cc = c.all_clints();
                car_name.DataSource = cc;
                car_name.DisplayMember = "clint_name";
                car_name.ValueMember = "clint_id";

            g.Columns.Add("رقم الصنف");
            g.Columns.Add("اسم الصنف");
            g.Columns.Add("عدد الصنف");
            dataGridView2.DataSource = g;


            DataTable dd = new DataTable();
            dd = bl.max_returned_id();
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
            catch
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void returned_Load(object sender, EventArgs e)
        {

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
                    int x = Convert.ToInt32(comboBox3.SelectedValue);
                    textBox10.Text = x.ToString();
                    DataTable f = new DataTable();

                    f = b.select_product_by_id(x);
                    if (f.Rows.Count == 0)
                    {
                        MessageBox.Show("يجب اضافه الصنف ");
                    }
                    else
                    {

                        if (!vald.is_int(textBox2.Text) || !vald.is_int(textBox16.Text) || (vald.is_zero(textBox2.Text) && vald.is_zero(textBox16.Text)))
                        {
                            MessageBox.Show("ادخل بيانات صحيحه");
                            return;
                        }

                        DataTable d = b.select_product_by_id(int.Parse(textBox10.Text));

                        int c_num = int.Parse(d.Rows[0]["num_in_packet"].ToString());

                        int p = int.Parse(textBox2.Text);
                        double calc = (p / (double)c_num) + int.Parse(textBox16.Text);
                        MessageBox.Show(calc.ToString());
                        if (!test_amount(calc))
                        {
                            MessageBox.Show("الكميه لا تكفي");
                            return;
                        }
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
                        
                        //count.Text = (dataGridView2.Rows.Count - 1).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في ادخال البيانات");
                }
            }
            textBox2.Text = "";
            textBox16.Text = "";
        }

        public bool test_amount(double x)
        {
            double amount = 0;
            try
            {
                
                DataTable f = new DataTable();
                f = b.select_product_by_id(int.Parse(textBox10.Text));
                string a = "0";

                if (Convert.ToInt32(car_name.SelectedValue) == 1)
                {
                    a = f.Rows[0]["in_car"].ToString();
                }

                if (Convert.ToInt32(car_name.SelectedValue) == 3)
                    a = f.Rows[0]["in_car2"].ToString();

                if (Convert.ToInt32(car_name.SelectedValue) == 4)
                    a = f.Rows[0]["in_car3"].ToString();
                amount = double.Parse(a);
                //decimal request = decimal.Parse(textBox16.Text);
                if (x > amount)
                {

                    return false;
                }
                else
                {

                    return true;
                }

            }
            catch (Exception ex)
            {


                return false;
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                add_product();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            comboBox3.Focus();
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_product();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_product();
            }
        }


        public void save_order()
        {
            try
            {

                DataTable q = new DataTable();
                q = bl.max_returned_id();
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

                    bl.update_returned_order(int.Parse(textBox1.Text),Convert.ToInt32(car_name.SelectedValue),date.Value.Date);

                    //update second part

                    //delete all operations
                    DataTable all_operations = bl.get_returned_operation(int.Parse(textBox1.Text));

                    for (int i = 0; i < all_operations.Rows.Count; i++)
                    {
                        if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 1)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car"].ToString());
                            double repos = double.Parse(p.Rows[0]["amount"].ToString())-a;
                            double final = amount + a;
                            car.update_in_car(product_id, final.ToString());
                            b.inc_product(product_id, repos.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 3)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car2"].ToString());
                            double repos = double.Parse(p.Rows[0]["amount"].ToString()) - a;
                            double final = amount + a;
                            car.update_in_car2(product_id, final.ToString());
                            b.inc_product(product_id, repos.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 4)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car3"].ToString());
                            double repos = double.Parse(p.Rows[0]["amount"].ToString()) - a;
                            double final = amount + a;
                            car.update_in_car3(product_id, final.ToString());
                            b.inc_product(product_id, repos.ToString());
                        }
                    }
                    bl.delete_returned_operation(int.Parse(textBox1.Text));

                    //insert new operations

                    for (int i = 0; i < x - 1; i++)
                    {
                        int id = int.Parse(textBox1.Text);
                        int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                        string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        DateTime d = date.Value.Date;


                        DataTable dt = b.select_product_by_id(product_id);
                        if (Convert.ToInt32(car_name.SelectedValue) == 1)
                        {

                            double am = double.Parse(dt.Rows[0]["in_car"].ToString());
                            double repos = double.Parse(dt.Rows[0]["amount"].ToString())+double.Parse(amount);
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            }
                            else
                            {
                                bl.insert_returned_operation(product_id, amount, d, Convert.ToInt32(car_name.SelectedValue),id);
                                car.update_in_car(product_id, final.ToString());
                                b.inc_product(product_id, repos.ToString());
                            }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 3)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car2"].ToString());
                            double repos = double.Parse(dt.Rows[0]["amount"].ToString()) +double.Parse(amount);
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            }
                            else
                            {
                                bl.insert_returned_operation(product_id, amount, d, Convert.ToInt32(car_name.SelectedValue), id);
                                car.update_in_car2(product_id, final.ToString());
                                b.inc_product(product_id, repos.ToString());
                            }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 4)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car3"].ToString());
                            double repos = double.Parse(dt.Rows[0]["amount"].ToString()) +double.Parse(amount);
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            }
                            else
                            {
                                bl.insert_returned_operation(product_id, amount, d, Convert.ToInt32(car_name.SelectedValue), id);
                                car.update_in_car3(product_id, final.ToString());
                                b.inc_product(product_id, repos.ToString());
                            }
                        }
                    }
                }
                else
                {
                    //save header of order
                    bl.add_returned_order(int.Parse(textBox1.Text), Convert.ToInt32(car_name.SelectedValue),date.Value.Date);


                    //add second part of car order
                    for (int i = 0; i < x - 1; i++)
                    {
                        int id = int.Parse(textBox1.Text);
                        int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                        string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        DateTime d = date.Value.Date;
                      //  bl.insert_returned_operation(product_id, amount, d, Convert.ToInt32(car_name.SelectedValue),id);

                        DataTable dt = b.select_product_by_id(product_id);

                        if (Convert.ToInt32(car_name.SelectedValue) == 1)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car"].ToString());
                            double repos = double.Parse(dt.Rows[0]["amount"].ToString()) + double.Parse(amount);
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            }
                            else
                            {
                                bl.insert_returned_operation(product_id, amount, d, Convert.ToInt32(car_name.SelectedValue), id);
                                car.update_in_car(product_id, final.ToString());
                                b.inc_product(product_id, repos.ToString());
                            }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 3)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car2"].ToString());
                            double repos = double.Parse(dt.Rows[0]["amount"].ToString()) + double.Parse(amount);
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            }
                            else
                            {
                                bl.insert_returned_operation(product_id, amount, d, Convert.ToInt32(car_name.SelectedValue), id);
                                car.update_in_car(product_id, final.ToString());
                                b.inc_product(product_id, repos.ToString());
                            }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 4)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car3"].ToString());
                            double repos = double.Parse(dt.Rows[0]["amount"].ToString()) + double.Parse(amount);
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            }
                            else
                            {
                                bl.insert_returned_operation(product_id, amount, d, Convert.ToInt32(car_name.SelectedValue), id);
                                car.update_in_car(product_id, final.ToString());
                                b.inc_product(product_id, repos.ToString());
                            }
                        }
                    }

                    //add mony operations 


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد الحذف", "fv", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    DataTable all_operations = bl.get_returned_operation(int.Parse(textBox1.Text));

                    for (int i = 0; i < all_operations.Rows.Count; i++)
                    {
                        if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 1)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());

                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car"].ToString());
                            double repos = double.Parse(p.Rows[0]["amount"].ToString()) - a;
                            double final = amount + a;
                            car.update_in_car(product_id, final.ToString());
                            b.inc_product(product_id, repos.ToString());

                        }
                        else if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 3)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car2"].ToString());
                            double repos = double.Parse(p.Rows[0]["amount"].ToString()) - a;
                            double final = amount + a;
                            car.update_in_car2(product_id, final.ToString());
                            b.inc_product(product_id, repos.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 4)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car3"].ToString());
                            double repos = double.Parse(p.Rows[0]["amount"].ToString()) - a;
                            double final = amount + a;
                            car.update_in_car3(product_id, final.ToString());
                            b.inc_product(product_id, repos.ToString());
                        }

                    }
                
                    bl.delete_returned_order(int.Parse(textBox1.Text));
                    bl.delete_returned_operation(int.Parse(textBox1.Text));
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
            try
            {
                DataTable dd = new DataTable();
                dd = bl.max_returned_id();
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

                date.Value = DateTime.Now;
                comboBox3.SelectedIndex = -1;
                textBox16.Text = "";
                textBox10.Text = "";
                    textBox2.Text="";
                index.Text="";
                g.Clear();
                dataGridView2.DataSource = g;
            }
            catch
            {

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
            try
            {
                if (e.ClickedItem.Name.ToString() == "تحديث")
                {


                    textBox10.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    comboBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();

                    index.Text = dataGridView2.CurrentRow.Index.ToString();
                    int num_in_packet;
                    DataTable d = b.select_product_by_id(int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()));
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


                else
                {
                    dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                    comboBox3.Focus();
                }
                save_order();
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

                    DataTable d1, d2, d3;
                    d1 = new DataTable();
                    d2 = new DataTable();

                    x--;
                    d1 = bl.get_returned_order(x);
                    d2 = bl.get_returned_operation_arabic(x);
                    textBox1.Text = d1.Rows[0]["id"].ToString();
                    date.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());

                    car_name.SelectedValue = Convert.ToInt32(d1.Rows[0]["clint_id"].ToString());
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
            DataTable d1, d2;
            d1 = new DataTable();
            d2 = new DataTable();
            int x = int.Parse(textBox1.Text);
            DataTable gg = new DataTable();
            gg = bl.max_returned_id();
            if (gg.Rows[0]["max"].ToString() != "" && x < int.Parse(gg.Rows[0]["max"].ToString()))
            {
            f:
                try
                {
                    x++;
                    d1 = bl.get_returned_order(x);
                    d2 = bl.get_returned_operation_arabic(x);


                    textBox1.Text = d1.Rows[0]["id"].ToString();
                    date.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());
                  
                    car_name.SelectedValue = Convert.ToInt32(d1.Rows[0]["clint_id"].ToString());
                    dataGridView2.DataSource = d2;
                    g = d2;

                
                }
                catch
                {
                    //   MessageBox.Show("لا نوجد فاتوره برقم " + "  " + x);
                    if (x < int.Parse(gg.Rows[0]["max"].ToString()))
                        goto f;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                new_order();
            }
            catch
            {

            }
        }

    }
}
