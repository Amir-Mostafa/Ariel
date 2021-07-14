using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Ariel.BL
{
    class validation
    {

       public bool is_int(string x)
        {
            Regex regex = new Regex(@"^\d+$");

            if (regex.IsMatch(x))
                return true;
            else
                return false;
        }
        public bool is_zero(string x)
       {
           Regex regex = new Regex(@"^\d+$");

           if (regex.IsMatch(x) && int.Parse(x) == 0)
           {
               //MessageBox.Show(int.Parse(x).ToString());
               return true;
           }
           else
               return false;
       }
    }
}
