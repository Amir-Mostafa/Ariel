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
using System.Management;
using System.Collections;

namespace Ariel.PL
{
    public partial class main : Form
    {
        string serial = "";
        public main()
        {
            InitializeComponent();

            
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new PL.products();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new buy_order();
            f.Show();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new all_buy_order();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new orders_form();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f = new car();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form f = new car_now();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form f = new all_order();
            f.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form f = new all_reports();
            f.Show();
        }

        private void ملفToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تغييرالخلفيهToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void اعداداتالاتصالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new form_config();
            f.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form f = new copy_system();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form f = new notifications();
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form f = new add_employee();
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form f = new costs();
            f.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Location.X > this.Width)
            {
                label1.Location = new Point(0-label1.Width,label1.Location.Y);
            }
            label1.Location = new Point(label1.Location.X + 10, label1.Location.Y);
            

        }

        private void main_Load(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.is_lic != true)
            //{
            //    login f = new login();
            //    f.Show();
            //    this.Hide();
            //}

            //BL.sell_order bl = new BL.sell_order();
            //DataTable d = bl.max_sell_order();
            //int x = 0;
            //if ((d.Rows[0]["max"].ToString()) != "")
            //    x = int.Parse(d.Rows[0]["max"].ToString());
            //MessageBox.Show(Properties.Settings.Default.serial.ToString());
            //double se = double.Parse(Properties.Settings.Default.serial.ToString());
            //MessageBox.Show(se.ToString());
            //if (x >= 15 && !get_serial(se.ToString()))
            //{
            //    this.Hide();

            //    login f = new login();
            //    f.Show();
            //}
            timer1.Start();
        }
        bool get_serial(string s)
        {



            try
            {

                ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                ArrayList hardDriveDetails = new ArrayList();
                int c = 0;
                bool turn = false;
                bool free = true;
                foreach (ManagementObject wmi_HD in moSearcher.Get())
                {
                    HardDrive hd = new HardDrive();  // User Defined Class
                    hd.Model = wmi_HD["Model"].ToString();  //Model Number
                    hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString();  //Serial Number
                    hardDriveDetails.Add(hd);

                    if (c == 0)
                    {
                        if (hd.SerialNo.ToString().Length > 14)
                            serial = hd.SerialNo.ToString().Substring(0, 14);
                        else
                            serial = hd.SerialNo.ToString();
                    }
                    c++;
                }

                string temp = "";
                BL.validation vald = new BL.validation();
                for (int i = 0; i < serial.Length; i++)
                {
                    if (vald.is_int(serial[i].ToString()))
                        temp += serial[i];
                }
                serial = temp;



                double original = double.Parse(serial);
                original *= 5;
                original += 5;
                original *= 3;
                original -= 3;
                double ss = double.Parse(s);
                if (original.ToString() == ss.ToString())
                    return true;
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
   
                //try
                //{

                    
                        

                //    MailMessage msg = new MailMessage();
                //    msg.From = new MailAddress("mostafaahmed123339@gmail.com");
                //    msg.To.Add("mustafa2791967@yahoo.com");
                //    //karem.m@elyaddak.com
                //    //msg.To.Add("mostafaamir339@gmail.com");
                //    msg.Subject = "اصناف تحت الحد الادني بمخزن ابو كريم - معصره ملوي";
                //    msg.Body = "اسم الصنف \t  الكميه في المخزن  \n";
                //    BL.products bl = new BL.products();
                    
                //    DataTable d = bl.all_products_name();
                //    double inc = 100 / d.Rows.Count;

                    
                //    for (int i = 0; i < d.Rows.Count;i++ )
                //    {
                        
                //        double amount = double.Parse(d.Rows[i]["amount"].ToString());
                //        double low = double.Parse(d.Rows[i]["min_amount"].ToString());
                //        int is_send = int.Parse(d.Rows[i]["is_send"].ToString());

                //        if (amount < low && is_send == 0)
                //        {
                //            msg.Body += d.Rows[i]["amount"].ToString() + "\t" + d.Rows[i]["product_name"].ToString() + "\n";
                //            //bl.update_is_send(int.Parse(d.Rows[i]["product_id"].ToString()), 1);
                //        }

                //    }


                //    if (msg.Body != "اسم الصنف \t  الكميه في المخزن  \n")
                //    {
                //        SmtpClient smt = new SmtpClient();
                //        smt.Host = "smtp.gmail.com";
                //        System.Net.NetworkCredential ntcd = new NetworkCredential();
                //        ntcd.UserName = "mostafaahmed123339@gmail.com";
                //        ntcd.Password = "mostafamostafa123";
                //        smt.Credentials = ntcd;
                //        smt.EnableSsl = true;
                //        smt.Port = 587;
                //        smt.Send(msg);
                //    }

                //    //WebClient clint = new WebClient();
                //    //Stream s = clint.OpenRead(string.Format("https://platform.clickatell.com/messages/http/send?apikey=adkzdkrqq0crgsm6nldb1w==&to=201203153992&content=test+message+text", "01555422138", "hi amir"));
                //    //StreamReader reader = new StreamReader(s);
                //    //string result = reader.ReadToEnd();



                //}
                //catch (Exception ex)
                //{

                //    //MessageBox.Show(ex.Message);
                //}



                //try
                //{

                //    MailMessage msg = new MailMessage();
                //    msg.From = new MailAddress("mostafaahmed123339@gmail.com");
                //    msg.To.Add("mostafaamir339@gmail.com");
                //    //karem.m@elyaddak.com
                //    //msg.To.Add("mostafaamir339@gmail.com");
                //    msg.Subject = "اصناف تحت الحد الادني بمخزن ابو كريم - معصره ملوي";
                //    msg.Body = "اسم الصنف \t  الكميه في المخزن  \n";
                //    BL.products bl = new BL.products();

                //    DataTable d = bl.all_products_name();
                //    double inc = 100 / d.Rows.Count;


                //    for (int i = 0; i < d.Rows.Count; i++)
                //    {

                //        double amount = double.Parse(d.Rows[i]["amount"].ToString());
                //        double low = double.Parse(d.Rows[i]["min_amount"].ToString());
                //        int is_send = int.Parse(d.Rows[i]["is_send"].ToString());

                //        if (amount < low && is_send == 0)
                //        {
                //            msg.Body += d.Rows[i]["amount"].ToString() + "\t" + d.Rows[i]["product_name"].ToString() + "\n";
                //           // bl.update_is_send(int.Parse(d.Rows[i]["product_id"].ToString()), 1);
                //        }

                //    }


                //    if (msg.Body != "اسم الصنف \t  الكميه في المخزن  \n")
                //    {
                //        SmtpClient smt = new SmtpClient();
                //        smt.Host = "smtp.gmail.com";
                //        System.Net.NetworkCredential ntcd = new NetworkCredential();
                //        ntcd.UserName = "mostafaahmed123339@gmail.com";
                //        ntcd.Password = "mostafamostafa123";
                //        smt.Credentials = ntcd;
                //        smt.EnableSsl = true;
                //        smt.Port = 587;
                //        smt.Send(msg);
                //    }

                //    //WebClient clint = new WebClient();
                //    //Stream s = clint.OpenRead(string.Format("https://platform.clickatell.com/messages/http/send?apikey=adkzdkrqq0crgsm6nldb1w==&to=201203153992&content=test+message+text", "01555422138", "hi amir"));
                //    //StreamReader reader = new StreamReader(s);
                //    //string result = reader.ReadToEnd();



                //}
                //catch (Exception ex)
                //{

                //    //MessageBox.Show(ex.Message);
                //}


                //try
                //{

                //    MailMessage msg = new MailMessage();
                //    msg.From = new MailAddress("mostafaahmed123339@gmail.com");
                //    msg.To.Add("karem.m@elyaddak.com");
                //    //karem.m@elyaddak.com
                //    //msg.To.Add("mostafaamir339@gmail.com");
                //    msg.Subject = "اصناف تحت الحد الادني بمخزن ابو كريم - معصره ملوي";
                //    msg.Body = "اسم الصنف \t  الكميه في المخزن  \n";
                //    BL.products bl = new BL.products();

                //    DataTable d = bl.all_products_name();
                //    double inc = 100 / d.Rows.Count;


                //    for (int i = 0; i < d.Rows.Count; i++)
                //    {

                //        double amount = double.Parse(d.Rows[i]["amount"].ToString());
                //        double low = double.Parse(d.Rows[i]["min_amount"].ToString());
                //        int is_send = int.Parse(d.Rows[i]["is_send"].ToString());

                //        if (amount < low && is_send == 0)
                //        {
                //            msg.Body += d.Rows[i]["amount"].ToString() + "\t" + d.Rows[i]["product_name"].ToString() + "\n";
                //            bl.update_is_send(int.Parse(d.Rows[i]["product_id"].ToString()), 1);
                //        }

                //    }


                //    if (msg.Body != "اسم الصنف \t  الكميه في المخزن  \n")
                //    {
                //        SmtpClient smt = new SmtpClient();
                //        smt.Host = "smtp.gmail.com";
                //        System.Net.NetworkCredential ntcd = new NetworkCredential();
                //        ntcd.UserName = "mostafaahmed123339@gmail.com";
                //        ntcd.Password = "mostafamostafa123";
                //        smt.Credentials = ntcd;
                //        smt.EnableSsl = true;
                //        smt.Port = 587;
                //        smt.Send(msg);
                //    }

                //    //WebClient clint = new WebClient();
                //    //Stream s = clint.OpenRead(string.Format("https://platform.clickatell.com/messages/http/send?apikey=adkzdkrqq0crgsm6nldb1w==&to=201203153992&content=test+message+text", "01555422138", "hi amir"));
                //    //StreamReader reader = new StreamReader(s);
                //    //string result = reader.ReadToEnd();



                //}
                //catch (Exception ex)
                //{

                //    MessageBox.Show(ex.Message);
                //}  







        }

        private void شهرجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new new_month();
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            returned f = new returned();
            f.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            Form f = new virtually();
            f.Show();
        }
    }
}
