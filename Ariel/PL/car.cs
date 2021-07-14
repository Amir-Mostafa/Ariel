using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BunifuAnimatorNS;

namespace Ariel.PL
{
    public partial class car : Form
    {
        BL.buy_orders b = new BL.buy_orders();
        BL.car bl = new BL.car();
        BL.sell_order clint = new BL.sell_order();
        BL.validation vald = new BL.validation();
        public DataTable g = new DataTable();
        public DataTable cado = new DataTable();

        int mov, mx, my;
        
        public car()
        {
           
            InitializeComponent();
            
            try
            {

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.FromArgb(119, 200, 255);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 16);
            dataGridView1.RowTemplate.Height = 30;

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

            free_product.DataSource = t;
            free_product.DisplayMember = "product_name";
            free_product.ValueMember = "product_id";


            try
            {
                DataTable cc = clint.all_clints();
                car_name.DataSource = cc;
                car_name.DisplayMember = "clint_name";
                car_name.ValueMember = "clint_id";

                
            }
                catch
            {

            }
            
            g.Columns.Add("رقم الصنف");
            g.Columns.Add("اسم الصنف");
            g.Columns.Add("عدد الصنف");
            dataGridView2.DataSource = g;

            cado.Columns.Add("رقم الصنف");
            cado.Columns.Add("اسم الصنف");
            cado.Columns.Add("عدد الصنف");
            cado.Columns.Add("الاجمالي");
            dataGridView1.DataSource = cado;

       
            
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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.Red;
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Black;
            label1.ForeColor = Color.Red;

        }

        private void car_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void bunifuMetroTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((!char.IsDigit(c) && c != 8 && c != 46 && c != '.') || (c == '.' && total.Text.Contains('.')))
                e.Handled = true;
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
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

                        //if (Convert.ToInt32(car_name.SelectedValue) == 3)
                        //{
                        //    if (!test_amount(calc)||!test_amount_postponed(calc))
                        //    {

                        //        MessageBox.Show("الكميه لا تكفي");
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                            if (!test_amount(calc))
                            {

                                MessageBox.Show("الكميه لا تكفي");
                                return;
                            }
                       // }
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
                        save_free_product();
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

        public void save_free_product()
        {
            try
            {
                  //delete all operations
                    DataTable all_operations = bl.get_all_order_gifts(int.Parse(order_id.Text));

                    for (int i = 0; i < all_operations.Rows.Count; i++)
                    {
                        int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                        double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                        DataTable p = new DataTable();
                        p = b.select_product_by_id(product_id);
                        if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 1)
                        {
                            double amount = double.Parse(p.Rows[0]["in_car"].ToString());
                            int c_num = int.Parse(p.Rows[0]["num_in_packet"].ToString());
                            a = a / (double)c_num;
                            double final = amount + a;
                            bl.update_in_car(product_id, final.ToString());



                        //update post
                        //double amm = 0;
                        //if (p.Rows[0]["postponed1"].ToString() != "")
                        //    amm = double.Parse(p.Rows[0]["postponed1"].ToString());
                        //double f = amm + a;
                        //BL.car_virtually bll = new BL.car_virtually();
                        //bll.update_in_car(product_id, f.ToString());


                    }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 3)
                        {
                            double amount = double.Parse(p.Rows[0]["in_car2"].ToString());
                            int c_num = int.Parse(p.Rows[0]["num_in_packet"].ToString());
                            a = a / (double)c_num;
                            double final = amount + a;
                            bl.update_in_car2(product_id, final.ToString());


                        //update post
                        //double amm = 0;
                        //if (p.Rows[0]["postponed2"].ToString() != "")
                        //    amm = double.Parse(p.Rows[0]["postponed2"].ToString());
                        //double f = amm + a;
                        //BL.car_virtually bll = new BL.car_virtually();
                        //bll.update_in_car2(product_id, f.ToString());
                    }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 4)
                        {
                            double amount = double.Parse(p.Rows[0]["in_car3"].ToString());
                            int c_num = int.Parse(p.Rows[0]["num_in_packet"].ToString());
                            a = a / (double)c_num;
                            double final = amount + a;
                            bl.update_in_car3(product_id, final.ToString());


                        //update post
                        //double amm = 0;
                        //if (p.Rows[0]["postponed3"].ToString() != "")
                        //    amm = double.Parse(p.Rows[0]["postponed3"].ToString());
                        //double f = amm + a;
                        //BL.car_virtually bll = new BL.car_virtually();
                        //bll.update_in_car3(product_id, f.ToString());
                    }
                    }
                    bl.delete_free_product(int.Parse(order_id.Text));

                    //insert new operations

                    double total_free = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        int id = int.Parse(order_id.Text);
                        int product_id = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        string amount = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        
                        DateTime d = date.Value.Date;
                        string total = dataGridView1.Rows[i].Cells[3].Value.ToString();
                       
                        total_free += double.Parse(total);

                        DataTable product = b.select_product_by_id(product_id);
                        if (Convert.ToInt32(car_name.SelectedValue) == 1)
                        {
                            int c_num = int.Parse(product.Rows[0]["num_in_packet"].ToString());
                            double am = double.Parse(product.Rows[0]["in_car"].ToString());
                            double c = double.Parse(amount) / (double)c_num;
                            double final = am - c;
                            if (c > am)
                            {
                                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                            }
                            else
                            {
                                bl.save_free_product(id, d, product_id, amount, total, Convert.ToInt32(car_name.SelectedValue));
                                bl.update_in_car(product_id, final.ToString());


                            //update post
                            //double amm = 0;
                            //if (product.Rows[0]["postponed1"].ToString() != "")
                            //    amm = double.Parse(product.Rows[0]["postponed1"].ToString());
                            //double f = amm - c;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car(product_id, f.ToString());
                        }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 3)
                        {
                            int c_num = int.Parse(product.Rows[0]["num_in_packet"].ToString());
                            double am = double.Parse(product.Rows[0]["in_car2"].ToString());
                            double c = double.Parse(amount) / (double)c_num;
                            double final = am - c;
                            if (c > am)
                            {
                                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                            }
                            else
                            {
                                bl.save_free_product(id, d, product_id, amount, total, Convert.ToInt32(car_name.SelectedValue));
                                bl.update_in_car2(product_id, final.ToString());


                            //update post
                            //double amm = 0;
                            //if (product.Rows[0]["postponed2"].ToString() != "")
                            //    amm = double.Parse(product.Rows[0]["postponed2"].ToString());
                            //double f = amm - c;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car2(product_id, f.ToString());
                        }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 4)
                        {
                            int c_num = int.Parse(product.Rows[0]["num_in_packet"].ToString());
                            double am = double.Parse(product.Rows[0]["in_car3"].ToString());
                            double c = double.Parse(amount) / (double)c_num;
                            double final = am - c;
                            if (c > am)
                            {
                                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                            }
                            else
                            {
                                bl.save_free_product(id, d, product_id, amount, total, Convert.ToInt32(car_name.SelectedValue));
                                bl.update_in_car3(product_id, final.ToString());


                            //update post
                            //double amm = 0;
                            //if (product.Rows[0]["postponed3"].ToString() != "")
                            //    amm = double.Parse(product.Rows[0]["postponed3"].ToString());
                            //double f = amm - c;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car3(product_id, f.ToString());
                        }
                        }

                    }
                    total_gifs.Text = total_free.ToString() ;
                   // save_order();

            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public void add_free_product()
        {

            DataTable dd = bl.get_max_car_order();
            int x = int.Parse(dd.Rows[0]["max"].ToString());
            if (int.Parse(order_id.Text) <= x)
            {
                if (free_p.Text == "")
                    free_p.Text = "0";
                if (free_p.Text != "0")
                {
                    try
                    {

                        int bb = Convert.ToInt32(comboBox3.SelectedValue);
                        textBox10.Text = bb.ToString();
                        DataTable f = new DataTable();

                        f = b.select_product_by_id(bb);
                        if (f.Rows.Count == 0)
                        {
                            MessageBox.Show("يجب اضافه الصنف ");
                        }
                        else
                        {
                            if (!vald.is_int(free_p.Text) || vald.is_zero(free_p.Text))
                            {
                                MessageBox.Show("ادخل بيانات صحيحه");
                                return;
                            }

                            DataTable d = b.select_product_by_id(int.Parse(textBox10.Text));

                            int c_num = int.Parse(d.Rows[0]["num_in_packet"].ToString());

                            int p = int.Parse(free_p.Text);
                            double calc = (p / (double)c_num);
                            if (!test_amount(calc))
                            {
                                MessageBox.Show("الكميه لا تكفي");
                                return;
                            }

                            double price = double.Parse(d.Rows[0]["price"].ToString());
                            DataRow r = cado.NewRow();
                            r[0] = textBox10.Text;
                            r[1] = free_product.Text;
                            r[2] = free_p.Text;
                            r[3] = (calc * price).ToString();
                            //r[3] = textBox2.Text;

                            if (index.Text != "")
                            {
                                cado.Rows.InsertAt(r, int.Parse(index.Text));
                                index.Text = "";
                            }
                            else
                                cado.Rows.InsertAt(r, 0);
                            dataGridView1.DataSource = cado;
                            dataGridView1.Columns["رقم الصنف"].Visible = false;
                            free_product.Text = "";
                            textBox10.Text = "";
                            free_p.Text = "";
                            save_free_product();
                            save_order();
                            //count.Text = (dataGridView2.Rows.Count - 1).ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("خطأ في ادخال البيانات");
                    }


                    free_p.Text = "";
                }
                
            }
            else
            {
                MessageBox.Show("يجب حفظ الفاتوره اولا");
            }
        
            
        }
        public bool test_amount(double x)
        {
            double amount = 0;
            try
            {
                DataTable f = new DataTable();
                f = b.select_product_by_id(int.Parse(textBox10.Text));
                string a = "0";
                if(Convert.ToInt32(car_name.SelectedValue)==1)
                a = f.Rows[0]["in_car"].ToString();

                if (Convert.ToInt32(car_name.SelectedValue) == 3)
                    a = f.Rows[0]["in_car2"].ToString();

                if (Convert.ToInt32(car_name.SelectedValue) == 4)
                    a = f.Rows[0]["in_car3"].ToString();
                amount = double.Parse(a);
                //decimal request = decimal.Parse(textBox16.Text);

                if(amount.ToString()==x.ToString())
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


        public bool test_amount_postponed(double x)
        {
            double amount = 0;
            try
            {
                DataTable f = new DataTable();
                f = b.select_product_by_id(int.Parse(textBox10.Text));
                string a = "0";
                if (Convert.ToInt32(car_name.SelectedValue) == 1)
                    a = f.Rows[0]["postponed1"].ToString();

                if (Convert.ToInt32(car_name.SelectedValue) == 3)
                    a = f.Rows[0]["postponed2"].ToString();

                if (Convert.ToInt32(car_name.SelectedValue) == 4)
                    a = f.Rows[0]["postponed3"].ToString();
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

        private void comboBox3_Leave(object sender, EventArgs e)
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
            //textBox2.Focus();
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

            //    save_order();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            
        }

        private void 
            
            
            
            ifuThinButton22_Click(object sender, EventArgs e)
        {
           
        }
        public void new_order()
        {
            comboBox3.Text = "";
            date.Value = DateTime.Now;
            g.Clear();
            total.Text = "";
            textBox10.Text = "0";
            count.Text = "0";
            total_pdf.Text = "0";
            disc.Text = "0";
            total_baka.Text = "0";
            total_gifs.Text = "0";

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
                dataGridView1.DataSource = cado;
                dataGridView2.DataSource = g;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            new_order();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new_order();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save_order();
            save_free_product();
        }

        public void save_order()
        {
            try
            {
                double total_order = 0;
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

                    bl.update_car_order(int.Parse(order_id.Text), total.Text, date.Value.Date, total_gifs.Text, total_pdf.Text, total_baka.Text, Convert.ToInt32(car_name.SelectedValue));

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
                            double amount = double.Parse(p.Rows[0]["in_car"].ToString());
                            double final = amount + a;
                            bl.update_in_car(product_id, final.ToString());

                            //update post
                            //double am = 0;
                            //if (p.Rows[0]["postponed1"].ToString() != "")
                            //    am = double.Parse(p.Rows[0]["postponed1"].ToString());
                            //double f = am + a;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car(product_id, f.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 3)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car2"].ToString());
                            double final = amount + a;
                            bl.update_in_car2(product_id, final.ToString());

                            //update post
                            //double am = 0;
                            //if (p.Rows[0]["postponed2"].ToString() != "")
                            //    am = double.Parse(p.Rows[0]["postponed2"].ToString());
                            //double f = am + a;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car2(product_id, f.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 4)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car3"].ToString());
                            double final = amount + a;
                            bl.update_in_car3(product_id, final.ToString());

                            //update post
                            //double am = 0;
                            //if (p.Rows[0]["postponed3"].ToString() != "")
                            //    am = double.Parse(p.Rows[0]["postponed3"].ToString());
                            //double f = am + a;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car3(product_id, f.ToString());
                        }
                    }
                    bl.delete_all_car_operations(int.Parse(order_id.Text));

                    //insert new operations

                     total_order = 0;
                    for (int i = 0; i < x - 1; i++)
                    {
                        int id = int.Parse(order_id.Text);
                        int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                        string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        DateTime d = date.Value.Date;


                        DataTable p = b.select_product_by_id(product_id);

                        double price = double.Parse(p.Rows[0]["price"].ToString());
                        //MessageBox.Show(price.ToString());
                        total_order += price * double.Parse(amount);

                        DataTable dt = b.select_product_by_id(product_id);
                        if (Convert.ToInt32(car_name.SelectedValue) == 1)
                        {
                            
                            double am = double.Parse(dt.Rows[0]["in_car"].ToString());

                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            }
                            else
                            {
                                bl.add_car_operations(id, product_id, amount, d, Convert.ToInt32(car_name.SelectedValue));
                                bl.update_in_car(product_id, final.ToString());

                                //update post
                                //double amm = 0;
                                //if (dt.Rows[0]["postponed1"].ToString() != "")
                                //    amm = double.Parse(dt.Rows[0]["postponed1"].ToString());
                                //double f = amm - double.Parse(amount);
                                //BL.car_virtually bll = new BL.car_virtually();
                                //bll.update_in_car(product_id, f.ToString());
                            }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 3)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car2"].ToString());
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            }
                            else
                            {
                                bl.add_car_operations(id, product_id, amount, d, Convert.ToInt32(car_name.SelectedValue));
                                bl.update_in_car2(product_id, final.ToString());

                                //update post
                                //double amm = 0;
                                //if (dt.Rows[0]["postponed2"].ToString() != "")
                                //    amm = double.Parse(dt.Rows[0]["postponed2"].ToString());
                                //double f = amm - double.Parse(amount);
                                //BL.car_virtually bll = new BL.car_virtually();
                                //bll.update_in_car2(product_id, f.ToString());
                            }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 4)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car3"].ToString());
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                            }
                            else
                            {
                                bl.add_car_operations(id, product_id, amount, d, Convert.ToInt32(car_name.SelectedValue));
                                bl.update_in_car3(product_id, final.ToString());

                                //update post
                                //double amm = 0;
                                //if (dt.Rows[0]["postponed3"].ToString() != "")
                                //    amm = double.Parse(dt.Rows[0]["postponed3"].ToString());
                                //double f = amm - double.Parse(amount);
                                //BL.car_virtually bll = new BL.car_virtually();
                                //bll.update_in_car3(product_id, f.ToString());
                            }
                        }
                    }
                }
                else
                {
                    //save header of order
                    bl.add_car_order(int.Parse(order_id.Text), total.Text, date.Value.Date, total_gifs.Text, total_pdf.Text, total_baka.Text, Convert.ToInt32(car_name.SelectedValue));


                    //add second part of car order
                    for (int i = 0; i < x - 1; i++)
                    {
                        int id = int.Parse(order_id.Text);
                        int product_id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                        string amount = dataGridView2.Rows[i].Cells[2].Value.ToString();
                        DateTime d = date.Value.Date;
                        bl.add_car_operations(id, product_id, amount, d,Convert.ToInt32(car_name.SelectedValue));

                        DataTable dt = b.select_product_by_id(product_id);

                        if (Convert.ToInt32(car_name.SelectedValue) == 1)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car"].ToString());
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                            }
                            else
                            {
                                bl.update_in_car(product_id, final.ToString());

                                //update post
                                //double amm = 0;
                                //if (dt.Rows[0]["postponed1"].ToString() != "")
                                //    amm = double.Parse(dt.Rows[0]["postponed1"].ToString());
                                //double f = amm - double.Parse(amount);
                                //BL.car_virtually bll = new BL.car_virtually();
                                //bll.update_in_car(product_id, f.ToString());
                            }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 3)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car2"].ToString());
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                            }
                            else
                            {
                                bl.update_in_car2(product_id, final.ToString());

                                //update post
                                //double amm = 0;
                                //if (dt.Rows[0]["postponed2"].ToString() != "")
                                //    amm = double.Parse(dt.Rows[0]["postponed2"].ToString());
                                //double f = amm - double.Parse(amount);
                                //BL.car_virtually bll = new BL.car_virtually();
                                //bll.update_in_car2(product_id, f.ToString());
                            }
                        }
                        else if (Convert.ToInt32(car_name.SelectedValue) == 4)
                        {
                            double am = double.Parse(dt.Rows[0]["in_car3"].ToString());
                            double final = am - double.Parse(amount);
                            if (double.Parse(amount) > am)
                            {
                                dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                            }
                            else
                            {
                                bl.update_in_car3(product_id, final.ToString());

                                //update post
                                //double amm = 0;
                                //if (dt.Rows[0]["postponed3"].ToString() != "")
                                //    amm = double.Parse(dt.Rows[0]["postponed3"].ToString());
                                //double f = amm - double.Parse(amount);
                                //BL.car_virtually bll = new BL.car_virtually();
                                //bll.update_in_car3(product_id, f.ToString());
                            }
                        }
                    }

                    //add mony operations 
                    

                }
                total.Text = total_order.ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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
                            double amount = double.Parse(p.Rows[0]["in_car"].ToString());
                            double final = amount + a;
                            bl.update_in_car(product_id, final.ToString());

                            //update post
                            //double amm = 0;
                            //if (p.Rows[0]["postponed1"].ToString() != "")
                            //    amm = double.Parse(p.Rows[0]["postponed1"].ToString());
                            //double f = amm + a;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car(product_id, f.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 3)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car2"].ToString());
                            double final = amount + a;
                            bl.update_in_car2(product_id, final.ToString());


                            //update post
                            //double amm = 0;
                            //if (p.Rows[0]["postponed2"].ToString() != "")
                            //    amm = double.Parse(p.Rows[0]["postponed2"].ToString());
                            //double f = amm + a;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car2(product_id, f.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 4)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car3"].ToString());
                            double final = amount + a;
                            bl.update_in_car3(product_id, final.ToString());


                            //update post
                            //double amm = 0;
                            //if (p.Rows[0]["postponed3"].ToString() != "")
                            //    amm = double.Parse(p.Rows[0]["postponed3"].ToString());
                            //double f = amm + a;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car3(product_id, f.ToString());
                        }

                    }
                    int x = int.Parse(order_id.Text);

                    all_operations = bl.get_all_order_gifts(int.Parse(order_id.Text));

                    for (int i = 0; i < all_operations.Rows.Count; i++)
                    {
                        if(int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 1)
                            {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car"].ToString());
                            int c_num = int.Parse(p.Rows[0]["num_in_packet"].ToString());
                            a = a / (double)c_num;
                            double final = amount + a;
                            bl.update_in_car(product_id, final.ToString());


                            //update post
                            //double amm = 0;
                            //if (p.Rows[0]["postponed1"].ToString() != "")
                            //    amm = double.Parse(p.Rows[0]["postponed1"].ToString());
                            //double f = amm + a;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car(product_id, f.ToString());
                        }
                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 3)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car2"].ToString());
                            int c_num = int.Parse(p.Rows[0]["num_in_packet"].ToString());
                            a = a / (double)c_num;
                            double final = amount + a;
                            bl.update_in_car2(product_id, final.ToString());


                            //update post
                            //double amm = 0;
                            //if (p.Rows[0]["postponed2"].ToString() != "")
                            //    amm = double.Parse(p.Rows[0]["postponed2"].ToString());
                            //double f = amm + a;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car2(product_id, f.ToString());
                        }

                        else if (int.Parse(all_operations.Rows[i]["car_id"].ToString()) == 4)
                        {
                            int product_id = int.Parse(all_operations.Rows[i]["product_id"].ToString());
                            double a = double.Parse(all_operations.Rows[i]["amount"].ToString());
                            DataTable p = new DataTable();
                            p = b.select_product_by_id(product_id);
                            double amount = double.Parse(p.Rows[0]["in_car3"].ToString());
                            int c_num = int.Parse(p.Rows[0]["num_in_packet"].ToString());
                            a = a / (double)c_num;
                            double final = amount + a;
                            bl.update_in_car3(product_id, final.ToString());


                            //update post
                            //double amm = 0;
                            //if (p.Rows[0]["postponed3"].ToString() != "")
                            //    amm = double.Parse(p.Rows[0]["postponed3"].ToString());
                            //double f = amm + a;
                            //BL.car_virtually bll = new BL.car_virtually();
                            //bll.update_in_car3(product_id, f.ToString());
                        }
                    }
                    bl.delete_free_product(int.Parse(order_id.Text));
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
                    total_gifs.Text = d1.Rows[0]["total_free"].ToString();
                    total_pdf.Text = d1.Rows[0]["total_pdf"].ToString();
                    total_baka.Text = d1.Rows[0]["total_baka"].ToString();
                    car_name.SelectedValue = Convert.ToInt32(d1.Rows[0]["car_id"].ToString());
                    dataGridView2.DataSource = d2;
                    g = d2;

                    cado = bl.gifts_of_only_order(int.Parse(order_id.Text));
                    dataGridView1.DataSource = cado;
                    count.Text = (dataGridView2.Rows.Count-1).ToString();

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
                    total_gifs.Text = d1.Rows[0]["total_free"].ToString();
                    total_pdf.Text = d1.Rows[0]["total_pdf"].ToString();
                    total_baka.Text = d1.Rows[0]["total_baka"].ToString();
                    car_name.SelectedValue = Convert.ToInt32(d1.Rows[0]["car_id"].ToString());
                    dataGridView2.DataSource = d2;
                    g = d2;

                    cado = bl.gifts_of_only_order(int.Parse(order_id.Text));
                    dataGridView1.DataSource = cado;
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

        private void total_TextChanged(object sender, EventArgs e)
        {

        }

        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    double t1, t2;
        //    //    if (textBox1.Text == "")
        //    //        t1 = 0;
        //    //    else
        //    //        t1 = double.Parse(textBox1.Text);

        //    //    if (textBox6.Text == "")
        //    //        t2 = 0;
        //    //    else
        //    //        t2 = double.Parse(textBox6.Text);

        //    //    textBox3.Text = (t2 / (double)t1).ToString();
        //    //}
        //    //catch
        //    //{

        //    //}



        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    double t1, t2;
        //    //    if (textBox1.Text == "")
        //    //        t1 = 0;
        //    //    else
        //    //        t1 = double.Parse(textBox1.Text);

        //    //    if (textBox6.Text == "")
        //    //        t2 = 0;
        //    //    else
        //    //        t2 = double.Parse(textBox6.Text);

        //    //    textBox3.Text = (t2 / (double)t1).ToString();
        //    //}
        //    //catch
        //    //{

        //    //}
        //}

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

        private void textBox16_TextChanged(object sender, EventArgs e)
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

        private void free_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(free_product.SelectedValue);
                textBox10.Text = x.ToString();
                DataTable f = new DataTable();

                f = b.select_product_by_id(x);
                if (f.Rows.Count == 0)
                {
                    //free_product.Focus();
                    textBox10.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في ادخال البيانات");
                free_product.Focus();
            }
        }

        private void free_product_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                add_free_product();
        }

        private void free_p_Leave(object sender, EventArgs e)
        {
            free_product.Focus();
        }

        private void free_p_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                add_free_product();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip my_menu = new System.Windows.Forms.ContextMenuStrip();

                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    my_menu.Items.Add("تعديل").Name = "تحديث";
                    my_menu.Items.Add("حذف").Name = "حذف";
                }

                my_menu.Show(dataGridView1, new Point(e.X, e.Y));

                my_menu.ItemClicked += new ToolStripItemClickedEventHandler(my_menu2_ItemClicked);

            }
        }
        private void my_menu2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Name.ToString() == "تحديث")
                {


                    textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    free_product.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    index.Text = dataGridView1.CurrentRow.Index.ToString();

                    free_p.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    free_product.Focus();
                }


                else
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    free_product.Focus();
                }
                save_free_product();    
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void car_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save_free_product();
            //save_order();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                report.car_order repor = new report.car_order();
                int x = int.Parse(order_id.Text);
                repor.SetDataSource(bl.print_car_order(x));
                report.form_report f = new report.form_report();
                f.crystalReportViewer1.ReportSource = repor;
                f.ShowDialog();
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                report.gifts repor = new report.gifts();
                int x = int.Parse(order_id.Text);
                repor.SetDataSource(bl.print_gifts(x));
                report.form_report f = new report.form_report();
                f.crystalReportViewer1.ReportSource = repor;
                f.ShowDialog();
            }
            catch
            {

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

                    double total = double.Parse(dataGridView2.CurrentCell.Value.ToString()) * double.Parse(d.Rows[0]["price"].ToString());
                    
                    //packet.Text = p.ToString();
                    //small.Text = s.ToString();

                    //MessageBox.Show(p.ToString() + "\n" + s.ToString());

                    // Get a reference to the cell

                    //DataGridViewCell cell = dataGridView2.CurrentCell;
                    // Set the Cell's ToolTipText.  In this case we're retrieving the value stored in 
                    // another cell in the same row (see my note below).
                    // cell.ToolTipText = (p.ToString() + "\n" + s.ToString());
                    if (d != null)
                    {
                        label17.Text = p.ToString();
                        label18.Text = s.ToString();
                        label22.Text = total.ToString();
                    }






                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dataGridView2_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView2_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            
        }
         

    }
}