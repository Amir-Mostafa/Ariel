using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
namespace Ariel.PL
{
    public partial class orders_form : Form
    {
        BL.buy_orders b = new BL.buy_orders();
        BL.sell_order bl = new BL.sell_order();
        BL.products c = new BL.products();
        BL.validation vald = new BL.validation();
        BL.car car = new BL.car();
        public DataTable g = new DataTable();

        public static orders_form orders;
        public orders_form()
        {
            InitializeComponent();
            try
            {
                orders = this;
            comboBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;

            DataTable t = new DataTable();
            t = b.all_products_name();
            comboBox3.DataSource = t;
            comboBox3.DisplayMember = "product_name";
            comboBox3.ValueMember = "product_id";

            t = bl.all_clints();
            comboBox1.DataSource = t;
            comboBox1.DisplayMember = "clint_name";
            comboBox1.ValueMember = "clint_id";
                comboBox2.Items.Add("الكل");
                comboBox2.Items.Add("سياره 1");
                comboBox2.Items.Add("سياره 2");
                comboBox2.Items.Add("سياره 3");
                comboBox2.Items.Add("المحل");
            //    comboBox2.DataSource = t;
            //comboBox2.DisplayMember = "clint_name";
            //comboBox2.ValueMember = "clint_id";


                g.Columns.Add("رقم الصنف");
            g.Columns.Add("اسم الصنف");
            g.Columns.Add("عدد الصنف");
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


            
                DataTable dd = new DataTable();
                dd = bl.max_sell_order();
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


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void orders_form_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

        public void new_order()
        {
            comboBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            g.Clear();
            nums.Text = "0";
            textBox10.Text = "";
            textBox16.Text = "0";
            total.Text = "0";

            try
            {
                DataTable dd = new DataTable();
                dd = bl.max_sell_order();
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

            }
            catch (Exception ex)
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
                    DataTable q = new DataTable();
                    q = bl.max_sell_order();
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
                        if(total.Text=="")
                            total.Text="0";
                        bl.update_sell_order(int.Parse(textBox1.Text), Convert.ToInt32(comboBox1.SelectedValue), dateTimePicker1.Value.Date,total.Text);

                        //update second part

                        //delete all operations
                        DataTable all_operations = bl.get_sell_operations(int.Parse(textBox1.Text));

                        for (int i = 0; i < all_operations.Rows.Count; i++)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            string am = "0";
                            if (p.Rows[0]["amount"].ToString() != "")
                                am = p.Rows[0]["amount"].ToString();
                            double amount = double.Parse(am);
                            double final = amount + a;
                            b.inc_product(product_id, final.ToString());

                            ////////in car////////////
                            if (int.Parse(all_operations.Rows[i]["clint_id"].ToString())==1)
                            {
                                string v = "0";
                                if (p.Rows[0]["in_car"].ToString() != "")
                                    v = p.Rows[0]["in_car"].ToString();
                                amount = double.Parse(v);
                                final = amount - a;
                                car.update_in_car(product_id, final.ToString());
                            }
                            ////////in car 2////////////
                            else if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 3)
                            {
                                string v = "0";
                                if (p.Rows[0]["in_car2"].ToString() != "")
                                    v = p.Rows[0]["in_car2"].ToString();
                                amount = double.Parse(v);
                                final = amount - a;
                                car.update_in_car2(product_id, final.ToString());
                            }

                            else if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 4)
                            {
                                string v = "0";
                                if (p.Rows[0]["in_car3"].ToString() != "")
                                    v = p.Rows[0]["in_car3"].ToString();
                                amount = double.Parse(v);
                                final = amount - a;
                                car.update_in_car3(product_id, final.ToString());
                            }
                        }
                        bl.delete_sell_operations(int.Parse(textBox1.Text));

                        //insert new operations

                        for (int i = 0; i < x - 1; i++)
                        {
                            int order_id = int.Parse(textBox1.Text);
                            int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                            string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                            DateTime d = dateTimePicker1.Value.Date;
                            int clint_id = Convert.ToInt32(comboBox1.SelectedValue);
                            bl.sell_operations(order_id, clint_id, product_id, amount, d);

                            DataTable dt = b.select_product_by_id(product_id);
                            string val = "0";
                            if (dt.Rows[0]["amount"].ToString() != "")
                                val = dt.Rows[0]["amount"].ToString();
                            double am = double.Parse(val);
                            double final = am - double.Parse(amount);
                            b.inc_product(product_id, final.ToString());

                            ///////////incar//////////////
                            if (Convert.ToInt32(comboBox1.SelectedValue) == 1)
                            {
                                string v = "0";
                                if (dt.Rows[0]["in_car"].ToString() != "")
                                    v = dt.Rows[0]["in_car"].ToString();
                                am = double.Parse(v);
                                final = am + double.Parse(amount);
                                car.update_in_car(product_id, final.ToString());
                            }

                            else if (Convert.ToInt32(comboBox1.SelectedValue) == 3)
                            {
                                string v = "0";
                                if (dt.Rows[0]["in_car2"].ToString() != "")
                                    v = dt.Rows[0]["in_car2"].ToString();
                                am = double.Parse(v);
                                final = am + double.Parse(amount);
                                car.update_in_car2(product_id, final.ToString());
                            }

                            else if (Convert.ToInt32(comboBox1.SelectedValue) == 4)
                            {
                                string v = "0";
                                if (dt.Rows[0]["in_car3"].ToString() != "")
                                    v = dt.Rows[0]["in_car3"].ToString();
                                am = double.Parse(v);
                                final = am + double.Parse(amount);
                                car.update_in_car3(product_id, final.ToString());
                            }
                        }
                        //MessageBox.Show("تم التعديل");
                    }
                    else
                    {
                        //save header of order
                        if (total.Text == "")
                            total.Text = "0";
                        bl.sell_order_head(int.Parse(textBox1.Text), Convert.ToInt32(comboBox1.SelectedValue), dateTimePicker1.Value.Date,total.Text);


                        //add second part of buy order
                        for (int i = 0; i < x - 1; i++)
                        {
                            int order_id = int.Parse(textBox1.Text);
                            int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                            string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                            DateTime d = dateTimePicker1.Value.Date;
                            bl.sell_operations(order_id, Convert.ToInt32(comboBox1.SelectedValue), product_id, amount, d);

                            DataTable dt = b.select_product_by_id(product_id);
                            string val = "0";
                            if (dt.Rows[0]["amount"].ToString() != "")
                                val = dt.Rows[0]["amount"].ToString();
                            double am = double.Parse(val);
                            double final = am - double.Parse(amount);

                            b.inc_product(product_id, final.ToString());

                            ///////////incar//////////////
                            if (Convert.ToInt32(comboBox1.SelectedValue)==1)
                            {
                                string v = "0";
                                if (dt.Rows[0]["in_car"].ToString() != "")
                                    v = dt.Rows[0]["in_car"].ToString();
                                am = double.Parse(v);
                                final = am + double.Parse(amount);
                                car.update_in_car(product_id, final.ToString());
                            }

                            else if (Convert.ToInt32(comboBox1.SelectedValue) == 3)
                            {
                                string v = "0";
                                if (dt.Rows[0]["in_car2"].ToString() != "")
                                    v = dt.Rows[0]["in_car2"].ToString();
                                am = double.Parse(v);
                                final = am + double.Parse(amount);
                                car.update_in_car2(product_id, final.ToString());
                            }

                            else if (Convert.ToInt32(comboBox1.SelectedValue) == 4)
                            {
                                string v = "0";
                                if (dt.Rows[0]["in_car3"].ToString() != "")
                                    v = dt.Rows[0]["in_car3"].ToString();
                                am = double.Parse(v);
                                final = am + double.Parse(amount);
                                car.update_in_car3(product_id, final.ToString());
                            }
                        }

                        //MessageBox.Show("تم");
                    }
                }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                ////DataTable d = bl.max_sell_order();
                ////int x = int.Parse(d.Rows[0]["max"].ToString());
                ////int y = int.Parse(textBox1.Text);

                //if (!test_amount(int.Parse(textBox16.Text)))
                //{
                //    MessageBox.Show("الكميه لا تكفي");
                //}
                //int x, y;
                //DataTable d = bl.max_sell_order();
                //int c = d.Rows.Count;
                //if (d.Rows[0]["max"].ToString() == "")
                //{
                //    x = 0;
                //    y = 1;
                //}
                //else
                //{
                //    x = int.Parse(d.Rows[0]["max"].ToString());
                //    y = int.Parse(textBox1.Text);
                //}

                //if (!test_amount(int.Parse(textBox10.Text)))
                //{
                //    MessageBox.Show("الكميه لا تكفي");
                //}
                //else
                //{
                //    try
                //    {
                //        DataRow r = g.NewRow();
                //        r[0] = textBox10.Text;
                //        r[1] = comboBox3.Text;
                //        r[2] = textBox16.Text;

                //        g.Rows.Add(r);
                //        dataGridView2.DataSource = g;
                //        comboBox3.Text = "";
                //        textBox10.Text = "0";
                //        textBox16.Text = "0";
                //        comboBox3.Focus();
                //        nums.Text = (dataGridView2.Rows.Count - 1).ToString();
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("خطأ في ادخال البيانات");
                //    }
                //}
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
                        nums.Text = (dataGridView2.Rows.Count - 1).ToString();

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

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                //int x = Convert.ToInt32(comboBox3.SelectedValue);
                //textBox10.Text = x.ToString();
                //DataTable f = new DataTable();

                //f = b.select_product_by_id(x);
                //if (f.Rows.Count == 0)
                //{
                //    comboBox3.Focus();
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في ادخال البيانات");
                comboBox3.Focus();
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            //    int x,y;
            //    DataTable d = bl.max_sell_order();
            //    int c = d.Rows.Count;
            //    if (d.Rows[0]["max"].ToString()=="")
            //    {
            //        x = 0 ;
            //        y = 1;
            //    }
            //    else
            //    {
            //        x = int.Parse(d.Rows[0]["max"].ToString());
            //        y = int.Parse(textBox1.Text);
            //    }

            //    if (!test_amount(int.Parse(textBox10.Text))&& y>x )
            //    {
            //        MessageBox.Show("الكميه لا تكفي");
            //    }
            //    else
            //    {
            //        try
            //        {
            //            DataRow r = g.NewRow();
            //            r[0] = textBox10.Text;
            //            r[1] = comboBox3.Text;
            //            r[2] = textBox16.Text;

            //            g.Rows.Add(r);
            //            dataGridView2.DataSource = g;
            //            comboBox3.Text = "";
            //            textBox10.Text = "0";
            //            textBox16.Text = "0";
            //            comboBox3.Focus();
            //            nums.Text = (dataGridView2.Rows.Count - 1).ToString();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("خطأ في ادخال البيانات");
            //        }
                //}
                add_product();
                
            }
            
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            //textBox2.Focus();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    textBox10.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            //    comboBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            //    textBox16.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            //    dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
            //    comboBox3.Focus();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        public bool test_amount(double x)
        {
            try
            {
                DataTable f = new DataTable();
                f = b.select_product_by_id(int.Parse(textBox10.Text));
                double amount = double.Parse(f.Rows[0]["amount"].ToString());

                
                if (x > amount)
                    return false;
                else
                    return true;
                
            }
            catch(Exception ex)
            {
               
                return false;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button10_Click(object sender, EventArgs e)
        {
            new_order();
            compobox_back_color();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد الحذف", "fv", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
            try
            {
                DataTable all_operations = bl.get_sell_operations(int.Parse(textBox1.Text));

                for (int i = 0; i < all_operations.Rows.Count; i++)
                {
                    int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                    double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                    DataTable p = new DataTable();
                    p = b.select_product_by_id(product_id);
                    double amount = double.Parse(p.Rows[0]["amount"].ToString());

                    double final = amount + a;
                    b.inc_product(product_id, final.ToString());

                    //////////in car
                    if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 1)
                    {
                        string v = "0";
                        if (p.Rows[0]["in_car"].ToString() != "")
                            v = p.Rows[0]["in_car"].ToString();
                        amount = double.Parse(v);

                        final = amount - a;
                        car.update_in_car(product_id, final.ToString());
                    }

                    else if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 3)
                    {
                        string v = "0";
                        if (p.Rows[0]["in_car2"].ToString() != "")
                            v = p.Rows[0]["in_car2"].ToString();
                        amount = double.Parse(v);

                        final = amount - a;
                        car.update_in_car2(product_id, final.ToString());
                    }
                    else if (int.Parse(all_operations.Rows[i]["clint_id"].ToString()) == 4)
                    {
                        string v = "0";
                        if (p.Rows[0]["in_car3"].ToString() != "")
                            v = p.Rows[0]["in_car3"].ToString();
                        amount = double.Parse(v);

                        final = amount - a;
                        car.update_in_car3(product_id, final.ToString());
                    }

                }
                int x = int.Parse(textBox1.Text);
                bl.delete_sell_order(x);
                bl.delete_sell_operations(x);
                new_order();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                    d1 = bl.sell_order_by_id(x);
                    d2 = bl.sell_operations_arabic(x);

                    if (comboBox2.Text == "" || comboBox2.Text == "الكل")
                    { }
                    else if (d1.Rows[0]["clint_name"].ToString() != comboBox2.Text)
                        goto f;
                    total.Text = d1.Rows[0]["total"].ToString();
                    textBox1.Text = d1.Rows[0]["order_id"].ToString();
                    dateTimePicker1.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());
                    comboBox1.Text = d1.Rows[0]["clint_name"].ToString();
                    dataGridView2.DataSource = d2;
                    g = d2;
                    nums.Text = (dataGridView2.Rows.Count - 1).ToString();
                    compobox_back_color();


                    

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
            gg = bl.max_sell_order();
            if (gg.Rows[0]["max"].ToString() != "" && x < int.Parse(gg.Rows[0]["max"].ToString()))
            {
            f:
                try
                {
                    x++;
                    d1 = bl.sell_order_by_id(x);
                    d2 = bl.sell_operations_arabic(x);

                    if(comboBox2.Text==""||comboBox2.Text=="الكل")
                    { }
                    else if (d1.Rows[0]["clint_name"].ToString() != comboBox2.Text)
                        goto f;
                    total.Text = d1.Rows[0]["total"].ToString();
                    textBox1.Text = d1.Rows[0]["order_id"].ToString();
                    dateTimePicker1.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());
                    comboBox1.Text = d1.Rows[0]["clint_name"].ToString();
                    dataGridView2.DataSource = d2;
                    g = d2;
                    nums.Text = (dataGridView2.Rows.Count-1).ToString();
                    compobox_back_color();
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    if (x < int.Parse(gg.Rows[0]["max"].ToString()))
                        goto f;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(comboBox3.SelectedValue);
                textBox10.Text = x.ToString();
                DataTable f = new DataTable();

                f = b.select_product_by_id(x);
                if (f.Rows.Count == 0)
                {
                   // comboBox3.Focus();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في ادخال البيانات");
                comboBox3.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            compobox_back_color();
            //save_order();
        }

        public void compobox_back_color()
        {
            if (comboBox1.Text == "المحل")
            {
                comboBox1.BackColor = Color.Red;
            }
            else if (comboBox1.Text == "سياره 2")
            {
                comboBox1.BackColor = Color.Green;
                
            }

            else
            {
                comboBox1.BackColor = Color.White;
            }
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

        private void total_TextChanged(object sender, EventArgs e)
        {
            //save_order();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //save_order();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void nums_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                //PrintDialog printDialog = new PrintDialog();
                //if (printDialog.ShowDialog() == DialogResult.OK)
                //{
                //    int x = int.Parse(textBox1.Text);
                //    report.CrystalReport1 repor = new report.CrystalReport1();
                //    repor.SetDataSource(bl.print_order(x));
                //    report.form_report f = new report.form_report();
                //    repor.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                //    f.crystalReportViewer1.ReportSource = repor;
                //}

                report.CrystalReport1 repor = new report.CrystalReport1();
                int x = int.Parse(textBox1.Text);
                repor.SetDataSource(bl.print_order(x));
                report.form_report f = new report.form_report();
                f.crystalReportViewer1.ReportSource = repor;
                f.ShowDialog();
            }
            catch
            {

            }
                
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
