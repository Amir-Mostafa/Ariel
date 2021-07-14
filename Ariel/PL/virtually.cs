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
    public partial class virtually : Form
    {

        BL.buy_orders b = new BL.buy_orders();
        BL.car_virtually bl = new BL.car_virtually();
        BL.sell_order clint = new BL.sell_order();
        BL.validation vald = new BL.validation();
        public DataTable g = new DataTable();
        public DataTable cado = new DataTable();

        public virtually()
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


                DataTable cc = clint.all_clints();
                car_name.DataSource = cc;
                car_name.DisplayMember = "clint_name";
                car_name.ValueMember = "clint_id";


                g.Columns.Add("رقم الصنف");
                g.Columns.Add("اسم الصنف");
                g.Columns.Add("عدد الصنف");
                dataGridView2.DataSource = g;


                DataTable dd = new DataTable();
                dd = bl.get_max_car_order();
                int y = dd.Rows.Count;
                if (dd.Rows.Count > 0)
                {
                    if (dd.Rows[0]["max"].ToString() == "")
                        order_id.Text = "1";
                    else
                    {
                        int x = int.Parse(dd.Rows[0]["max"].ToString()) + 1;
                        order_id.Text = x.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void virtually_Load(object sender, EventArgs e)
        {

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
                        //save_free_product();
                        count.Text = (dataGridView2.Rows.Count - 1).ToString();
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
                    a = f.Rows[0]["in_car"].ToString();

                if (Convert.ToInt32(car_name.SelectedValue) == 3)
                    a = f.Rows[0]["in_car2"].ToString();

                if (Convert.ToInt32(car_name.SelectedValue) == 4)
                    a = f.Rows[0]["in_car3"].ToString();
                amount = double.Parse(a);
                //decimal request = decimal.Parse(textBox16.Text);

                if (amount.ToString() == x.ToString())
                {
                    return true;
                }

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
        public void save_order()
        {
            try
            {

                DataTable q = new DataTable();
                q = bl.get_max_car_order();
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
                if (int.Parse(order_id.Text) <= m)
                {
                    //update first part 

                    bl.update_car_order(int.Parse(order_id.Text), total.Text, date.Value.Date, Convert.ToInt32(car_name.SelectedValue));

                    //update second part

                    //delete all operations
                    DataTable all_operations = bl.get_all_car_operations(int.Parse(order_id.Text));

                    for (int i = 0; i < all_operations.Rows.Count; i++)
                    {
                        if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 1)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = 0;
                            if(p.Rows[0]["postponed1"].ToString()!="")
                             amount = double.Parse(p.Rows[0]["postponed1"].ToString());
                            double final = amount - a;
                            if(final<0)
                            MessageBox.Show("يجب ادخال قيمه اكبر من او تساوي هذه القيمه لتجنب حدوث عمليات غير منطقيه ");
                            bl.update_in_car(product_id, final.ToString());

                        }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 3)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = 0;
                            if (p.Rows[0]["postponed2"].ToString() != "")
                                amount = double.Parse(p.Rows[0]["postponed2"].ToString());
                            double final = amount-a;
                            if (final < 0)
                                MessageBox.Show("يجب ادخال قيمه اكبر من او تساوي هذه القيمه لتجنب حدوث عمليات غير منطقيه ");
                            bl.update_in_car2(product_id, final.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 4)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = 0;
                            if (p.Rows[0]["postponed3"].ToString() != "")
                                amount = double.Parse(p.Rows[0]["postponed3"].ToString());
                            double final = amount - a;
                            if (final < 0)
                                MessageBox.Show("يجب ادخال قيمه اكبر من او تساوي هذه القيمه لتجنب حدوث عمليات غير منطقيه ");
                            bl.update_in_car3(product_id, final.ToString());
                        }
                    }
                    bl.delete_all_car_operations(int.Parse(order_id.Text));

                    //insert new operations

                    for (int i = 0; i < x - 1; i++)
                    {
                        int id = int.Parse(order_id.Text);
                        int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                        string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        DateTime d = date.Value.Date;


                        DataTable dt = b.select_product_by_id(product_id);
                        
                        if (Convert.ToInt32(car_name.SelectedValue) == 1)
                        {
                            double am = 0;
                            if(dt.Rows[0]["postponed1"].ToString()!="")
                             am = double.Parse(dt.Rows[0]["postponed1"].ToString());


                            double am1 = 0;
                            if (dt.Rows[0]["in_car"].ToString() != "")
                                am1 = double.Parse(dt.Rows[0]["in_car"].ToString());

                            double final = am + double.Parse(amount);
                            //if (double.Parse(amount) > am1)
                            //{
                            //    dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            //}
                            //else
                            //{
                                bl.add_car_operations(id, product_id, amount, d, Convert.ToInt32(car_name.SelectedValue));
                                bl.update_in_car(product_id, final.ToString());
                            //}
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 3)
                        {
                            double am = 0;
                            if (dt.Rows[0]["postponed2"].ToString() != "")
                                am = double.Parse(dt.Rows[0]["postponed2"].ToString());

                            double am1 = 0;
                            if (dt.Rows[0]["in_car2"].ToString() != "")
                                am1 = double.Parse(dt.Rows[0]["in_car2"].ToString());
                            double final = am + double.Parse(amount);
                            //if (double.Parse(amount) > am1)
                            //{
                            //    dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            //}
                            //else
                            //{
                                bl.add_car_operations(id, product_id, amount, d, Convert.ToInt32(car_name.SelectedValue));
                                bl.update_in_car2(product_id, final.ToString());
                           // }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 4)
                        {
                            double am = 0;
                            if (dt.Rows[0]["postponed3"].ToString() != "")
                                am = double.Parse(dt.Rows[0]["postponed3"].ToString());

                            double am1 = 0;
                            if (dt.Rows[0]["in_car3"].ToString() != "")
                                am1 = double.Parse(dt.Rows[0]["in_car3"].ToString());

                            double final = am + double.Parse(amount);
                            //if (double.Parse(amount) > am1)
                            //{
                            //    dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            //}
                            //else
                            //{
                                bl.add_car_operations(id, product_id, amount, d, Convert.ToInt32(car_name.SelectedValue));
                                bl.update_in_car3(product_id, final.ToString());
                            //}
                        }
                    }
                }
                else
                {
                    //save header of order
                    bl.add_car_order(int.Parse(order_id.Text), total.Text, date.Value.Date, Convert.ToInt32(car_name.SelectedValue));


                    //add second part of car order
                    for (int i = 0; i < x - 1; i++)
                    {
                        int id = int.Parse(order_id.Text);
                        int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                        string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        DateTime d = date.Value.Date;
                        bl.add_car_operations(id, product_id, amount, d, Convert.ToInt32(car_name.SelectedValue));

                        DataTable dt = b.select_product_by_id(product_id);

                        if (Convert.ToInt32(car_name.SelectedValue) == 1)
                        {
                            double am = 0;
                            if (dt.Rows[0]["postponed1"].ToString() != "")
                                am = double.Parse(dt.Rows[0]["postponed1"].ToString());
                            double final = am + double.Parse(amount);

                            double am1 = 0;
                            if (dt.Rows[0]["in_car"].ToString() != "")
                                am1 = double.Parse(dt.Rows[0]["in_car"].ToString());

                            //if (double.Parse(amount) > am1)
                            //{
                            //    dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            //}
                            //else
                            //if (final < 0)
                            //    MessageBox.Show("يجب ادخال قيمه اكبر من او تساوي هذه القيمه لتجنب حدوث عمليات غير منطقيه ");
                            bl.update_in_car(product_id, final.ToString());
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 3)
                        {
                            double am = 0;
                            if (dt.Rows[0]["postponed2"].ToString() != "")
                                am = double.Parse(dt.Rows[0]["postponed2"].ToString());
                            double final = am + double.Parse(amount);

                            double am1 = 0;
                            if (dt.Rows[0]["in_car2"].ToString() != "")
                                am1 = double.Parse(dt.Rows[0]["in_car2"].ToString());
                            //if (double.Parse(amount) > am1)
                            //{
                            //    dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            //}
                            //else
                            //if (final < 0)
                            //    MessageBox.Show("يجب ادخال قيمه اكبر من او تساوي هذه القيمه لتجنب حدوث عمليات غير منطقيه ");
                            bl.update_in_car2(product_id, final.ToString());
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 4)
                        {
                            double am = 0;
                            if (dt.Rows[0]["postponed3"].ToString() != "")
                                am = double.Parse(dt.Rows[0]["postponed3"].ToString());
                            double final = am + double.Parse(amount);

                            double am1 = 0;
                            if (dt.Rows[0]["in_car3"].ToString() != "")
                                am1 = double.Parse(dt.Rows[0]["in_car3"].ToString());
                            //if (double.Parse(amount) > am1)
                            //{
                            //    dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            //}
                            //else
                            //if (final < 0)
                            //    MessageBox.Show("يجب ادخال قيمه اكبر من او تساوي هذه القيمه لتجنب حدوث عمليات غير منطقيه ");
                            bl.update_in_car3(product_id, final.ToString());
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

        private void button4_Click(object sender, EventArgs e)
        {
            save_order();
            //save_free_product();
        }

        
        public void new_order()
        {
            comboBox3.Text = "";
            date.Value = DateTime.Now;
            g.Clear();
            total.Text = "";
            textBox10.Text = "0";
            count.Text = "0";
            

            try
            {
                DataTable dd = new DataTable();
                dd = bl.get_max_car_order();
                int y = dd.Rows.Count;
                if (dd.Rows.Count > 0)
                {
                    if (dd.Rows[0]["max"].ToString() == "")
                        order_id.Text = "1";
                    else
                    {
                        int x = int.Parse(dd.Rows[0]["max"].ToString()) + 1;
                        order_id.Text = x.ToString();
                    }
                }
                g.Clear();
                cado.Clear();
                //dataGridView1.DataSource = cado;
                dataGridView2.DataSource = g;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد الحذف", "fv", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    DataTable all_operations = bl.get_all_car_operations(int.Parse(order_id.Text));

                    for (int i = 0; i < all_operations.Rows.Count; i++)
                    {
                        if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 1)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["postponed1"].ToString());
                            double final = amount - a;
                            bl.update_in_car(product_id, final.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 3)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["postponed2"].ToString());
                            double final = amount - a;
                            bl.update_in_car2(product_id, final.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 4)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["postponed3"].ToString());
                            double final = amount - a;
                            bl.update_in_car3(product_id, final.ToString());
                        }

                    }
                    int x = int.Parse(order_id.Text);

                    //all_operations = bl.get_all_order_gifts(int.Parse(order_id.Text));

                    //for (int i = 0; i < all_operations.Rows.Count; i++)
                    //{
                    //    if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 1)
                    //    {
                    //        int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                    //        double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                    //        DataTable p = new DataTable();
                    //        p = b.select_product_by_id(product_id);
                    //        double amount = double.Parse(p.Rows[0]["in_car"].ToString());
                    //        int c_num = int.Parse(p.Rows[0]["num_in_packet"].ToString());
                    //        a = a / (double)c_num;
                    //        double final = amount + a;
                    //        bl.update_in_car(product_id, final.ToString());
                    //    }
                    //    else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 3)
                    //    {
                    //        int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                    //        double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                    //        DataTable p = new DataTable();
                    //        p = b.select_product_by_id(product_id);
                    //        double amount = double.Parse(p.Rows[0]["in_car2"].ToString());
                    //        int c_num = int.Parse(p.Rows[0]["num_in_packet"].ToString());
                    //        a = a / (double)c_num;
                    //        double final = amount + a;
                    //        bl.update_in_car2(product_id, final.ToString());
                    //    }

                    //    else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 4)
                    //    {
                    //        int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                    //        double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                    //        DataTable p = new DataTable();
                    //        p = b.select_product_by_id(product_id);
                    //        double amount = double.Parse(p.Rows[0]["in_car3"].ToString());
                    //        int c_num = int.Parse(p.Rows[0]["num_in_packet"].ToString());
                    //        a = a / (double)c_num;
                    //        double final = amount + a;
                    //        bl.update_in_car3(product_id, final.ToString());
                    //    }
                    // }
                    // bl.delete_free_product(int.Parse(order_id.Text));
                    bl.delete_car_order(x);
                    bl.delete_all_car_operations(x);
                    new_order();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_product();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new_order();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            save_order();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(order_id.Text);
            if (x > 0)
            {
            f:
                try
                {

                    DataTable d1, d2, d3;
                    d1 = new DataTable();
                    d2 = new DataTable();

                    x--;
                    d1 = bl.car_order_by_id(x);
                    d2 = bl.car_operation_arabic(x);
                    order_id.Text = d1.Rows[0]["order_id"].ToString();
                    date.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());
                    total.Text = d1.Rows[0]["total"].ToString();
                    
                    car_name.SelectedValue = Convert.ToInt32(d1.Rows[0]["car_id"].ToString());
                    dataGridView2.DataSource = d2;
                    g = d2;

                   // cado = bl.gifts_of_only_order(int.Parse(order_id.Text));
                    //dataGridView1.DataSource = cado;
                    count.Text = (dataGridView2.Rows.Count - 1).ToString();

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

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable d1, d2;
            d1 = new DataTable();
            d2 = new DataTable();
            int x = int.Parse(order_id.Text);
            DataTable gg = new DataTable();
            gg = bl.get_max_car_order();
            if (gg.Rows[0]["max"].ToString() != "" && x < int.Parse(gg.Rows[0]["max"].ToString()))
            {
            f:
                try
                {
                    x++;
                    d1 = bl.car_order_by_id(x);
                    d2 = bl.car_operation_arabic(x);


                    order_id.Text = d1.Rows[0]["order_id"].ToString();
                    date.Value = DateTime.Parse(d1.Rows[0]["time"].ToString());
                    total.Text = d1.Rows[0]["total"].ToString();
                    
                    car_name.SelectedValue = Convert.ToInt32(d1.Rows[0]["car_id"].ToString());
                    dataGridView2.DataSource = d2;
                    g = d2;

                   // cado = bl.gifts_of_only_order(int.Parse(order_id.Text));
                    //dataGridView1.DataSource = cado;
                    count.Text = (dataGridView2.Rows.Count - 1).ToString();
                }
                catch
                {
                    //   MessageBox.Show("لا نوجد فاتوره برقم " + "  " + x);
                    if (x < int.Parse(gg.Rows[0]["max"].ToString()))
                        goto f;
                }
            }
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
                    textBox10.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في ادخال البيانات");
                comboBox3.Focus();
            }
        }

        private void car_name_Leave(object sender, EventArgs e)
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

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                double num;
                if (double.TryParse(dataGridView2.CurrentCell.Value.ToString(), out num))
                {

                    int num_in_packet;

                    DataTable d = b.select_product_by_id(int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()));

                    if (d.Rows[0]["num_in_packet"].ToString() != "")
                        num_in_packet = int.Parse(d.Rows[0]["num_in_packet"].ToString());
                    else
                        num_in_packet = 0;

                    int p = (int)double.Parse(dataGridView2.CurrentCell.Value.ToString());

                    double s = Math.Round((double.Parse(dataGridView2.CurrentCell.Value.ToString()) - p) * num_in_packet);

                    if (d != null)
                    {
                        label17.Text = p.ToString();
                        label18.Text = s.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
