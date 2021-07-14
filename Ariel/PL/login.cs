using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Management;
using System.Collections;

namespace Ariel.PL
{
      
    public partial class login : Form
    {
        BL.validation vld = new BL.validation();
        double result = 0;
        string serial="";
        public login()
        {
            InitializeComponent();

            
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
                
                if(c==0)
                {
                    if (hd.SerialNo.ToString().Length > 14)
                        serial = hd.SerialNo.ToString().Substring(0, 14);
                    else
                        serial = hd.SerialNo.ToString();
                }
                c++;
            }

            string temp = "";
            BL.validation vald=new BL.validation();
            label1.Text = serial;
            for (int i = 0; i < serial.Length;i++ )
            {
                if (vald.is_int(serial[i].ToString()))
                    temp += serial[i];
            }
            serial = temp;
                
              
        }

        void calculator()
        {
            if(vld.is_int(txtserial1.Text)&&vld.is_int(txtserial2.Text)&&vld.is_int(txtserial3.Text)&&vld.is_int(txtserial4.Text))
            {
                Double serial1 = Convert.ToDouble(txtserial1.Text);
                Double serial2 = Convert.ToDouble(txtserial2.Text);
                Double serial3 = Convert.ToDouble(txtserial3.Text);
                Double serial4 = Convert.ToDouble(txtserial4.Text);
                result = (serial1 + serial2) - (serial3 + serial4);
            }
        }
        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //6524  2276  3594  4851
           // calculator();
            //if(result==355)
            //{
            //    main f = new main();
            //    Properties.Settings.Default.is_lic = true;
            //    Properties.Settings.Default.Save();
            //    f.Show();
            //}
            //else
            //{
            //    MessageBox.Show("سيريال غير صحيح");
            //    txtserial1.Text = "";
            //    txtserial2.Text = "";
            //    txtserial3.Text = "";
            //    txtserial4.Text = "";
            //}
            if(get_serial(textBox1.Text))
            {
                this.Hide();
                main f = new main();
                
                Properties.Settings.Default.serial = serial.ToString();
                Properties.Settings.Default.Upgrade();
                f.Show();
            }
            else
            {
                MessageBox.Show("سيريال غير صحيح");
            }


        }
        private bool get_serial(string s)
        {
            try
            {
                BL.validation vald = new BL.validation();

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

        private void txtserial1_Leave(object sender, EventArgs e)
        {
            if (!check4(txtserial4.Text))
            {
                txtserial4.Focus();
            }
        }

        private void txtserial4_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtserial4_Validated(object sender, EventArgs e)
         {
            
        }

        bool check4(string s)
        {
            Regex r = new Regex("[0-9]{4}");
            if (r.IsMatch(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (!check4(txtserial1.Text))
            {
                txtserial1.Focus();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!check4(txtserial2.Text))
            {
                txtserial2.Focus();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!check4(txtserial3.Text))
            {
                txtserial3.Focus();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!check4(txtserial4.Text))
            {
                txtserial4.Focus();
            }
        }
    }
}
