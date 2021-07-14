using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Collections;
namespace Ariel.PL
{
    public partial class user_data : Form
    {
        public user_data()
        {
            InitializeComponent();
             try
            {
                ManagementObjectSearcher mosDisks = new ManagementObjectSearcher("" +
                    "SELECT * FROM win32_DiskDrive " +
                    "where SerialNumber IS NOT NULL AND " +
                    "MediaType = 'Fixed hard disk media'");
                foreach (ManagementObject moDisk in mosDisks.Get())
                {
                    if (Properties.Settings.Default.serial_number1.ToString() != "")
                    {

                        if ((moDisk["SerialNumber"].ToString() == Properties.Settings.Default.serial_number1))
                        {
                            this.Hide();
                            Form f = new main();
                            f.Show();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("يجب الحصول علي رخصه اولا");
                        }

                    }
                    else
                    {
                        Properties.Settings.Default.serial_number1 = moDisk["SerialNumber"].ToString();
                        Form f = new main();
                        f.Show();
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void user_data_Load(object sender, EventArgs e)
        {
           
        }
    }
}
