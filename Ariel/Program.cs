using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Collections;
using System.IO;
using System.Threading;
using System.Data;
namespace Ariel
{



    static class Program
    {

       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        static Mutex m;
        [STAThread]
        
        static void Main()
        {

            bool first = false;
            m = new Mutex(true, Application.ProductName.ToString(), out first);
            if (first)
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                try
                {
                   
                        Application.Run(new PL.main());
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

            else
            {
                return;


            }


           
            //var fileName = Path.Combine(Environment.GetFolderPath(
            //Environment.SpecialFolder.ApplicationData), "DateLinks.txt");

            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));


            //Properties.Settings.Default.count = 0;
            //Properties.Settings.Default.Save();
            //Properties.Settings.Default.count++;
            //Properties.Settings.Default.Save();
            //MessageBox.Show(Properties.Settings.Default.count.ToString());
            //if (Properties.Settings.Default.count >= 3)
            //{
            //    MessageBox.Show("انتهت الفتره التجربيه");
            //    return;
            //}


           // ManagementObjectSearcher moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

           // ArrayList hardDriveDetails = new ArrayList();
           // int c = 0;
           // bool turn = false;
           // bool free = true;
           //foreach (ManagementObject wmi_HD in moSearcher.Get())  
           //{  
           //    HardDrive hd = new HardDrive();  // User Defined Class
           //    hd.Model = wmi_HD["Model"].ToString();  //Model Number
           //    hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
           //    hd.SerialNo= wmi_HD["SerialNumber"].ToString();  //Serial Number
           //    hardDriveDetails.Add(hd);
              

           //    if (Properties.Settings.Default.serial_number1.ToString() == "")
           //    {
                   
           //        turn = true;
           //        if (c == 0)
           //        {
           //            string s1 = hd.SerialNo.ToString();
           //            Properties.Settings.Default.serial_number1 = s1;

           //            Properties.Settings.Default.Save();
           //            c++;
           //        }
           //        else
           //        {
           //            string s1 = hd.SerialNo.ToString();
           //            Properties.Settings.Default.serial_number2 = s1;
           //            Properties.Settings.Default.Save();
           //        }
           //    }
           //    else
           //    {
           //        if (Properties.Settings.Default.serial_number1.ToString() == hd.SerialNo.ToString())
           //        {
           //            turn =true;
           //        }

           //    }
           //}
           //if (turn)
           //{
               
           //}
           //else
           //{
           //    MessageBox.Show("يجب الحصول علي رخصه اولا");
           //}



            

            
        }
       
    }
    class HardDrive
    {
        private string model = null;
        private string type = null;
        private string serialNo = null;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string SerialNo
        {
            get { return serialNo; }
            set { serialNo = value; }
        }
    }  
}
