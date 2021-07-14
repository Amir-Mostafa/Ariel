using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariel.BL
{
    class car_virtually
    {

        DAL.DataAccesLier DAL = new DAL.DataAccesLier();

        //done
        public void add_car_order(int id, string total, DateTime time, int car_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@total", SqlDbType.NVarChar, 20);
            param[1].Value = total;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            param[3] = new SqlParameter("@car_id", SqlDbType.Int);
            param[3].Value = car_id;
            DAL.open();
            DAL.executenonquery("add_car_order_virtually", param);
            DAL.close();
        }
        //done
        public void add_car_operations(int order_id, int product_id, string amount, DateTime time, int car_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;
            param[1] = new SqlParameter("@product_id", SqlDbType.Int);
            param[1].Value = product_id;
            param[2] = new SqlParameter("@amount", SqlDbType.NVarChar, 20);
            param[2].Value = amount;
            param[3] = new SqlParameter("@time", SqlDbType.DateTime);
            param[3].Value = time;
            param[4] = new SqlParameter("@car_id", SqlDbType.Int);
            param[4].Value = car_id;
            DAL.open();
            DAL.executenonquery("add_car_operations_virtually", param);
            DAL.close();
        }

        //done
        public DataTable get_max_car_order()
        {

            return DAL.selectdata("get_max_car_order_virtually", null);


        }
        //done
        public void update_in_car(int id, string amount)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@amount", SqlDbType.NVarChar, 20);
            param[1].Value = amount;
            DAL.open();
            DAL.executenonquery("update_in_car_virtually", param);
            DAL.close();
        }
        //done
        public void update_in_car2(int id, string amount)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@amount", SqlDbType.NVarChar, 20);
            param[1].Value = amount;
            DAL.open();
            DAL.executenonquery("update_in_car2_virtually", param);
            DAL.close();
        }
        //done
        public void update_in_car3(int id, string amount)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@amount", SqlDbType.NVarChar, 20);
            param[1].Value = amount;
            DAL.open();
            DAL.executenonquery("update_in_car3_virtually", param);
            DAL.close();
        }
        //done
        public void update_car_order(int id, string total, DateTime time, int car_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@total", SqlDbType.NVarChar, 20);
            param[1].Value = total;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            param[3] = new SqlParameter("@car_id", SqlDbType.Int);
            param[3].Value = car_id;
            DAL.open();
            DAL.executenonquery("update_car_order_virtually", param);
            DAL.close();
        }
        //done
        public DataTable get_all_car_operations(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("get_all_car_operations_virtually", param);

        }
        //done
        public void delete_all_car_operations(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_all_car_operations_virtually", param);
            DAL.close();
        }
        //done
        public void delete_car_order(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_car_order_virtually", param);
            DAL.close();
        }
        //done
        public DataTable car_operation_arabic(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("car_operation_arabic_virtually", param);
        }
        //done
        public DataTable car_order_by_id(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("car_order_by_id_virtually", param);
        }

        public DataTable supplies_report(DateTime d1, DateTime d2, int car_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[0].Value = d1;
            param[1] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[1].Value = d2;
            param[2] = new SqlParameter("@car_id", SqlDbType.Int);
            param[2].Value = car_id;



            return DAL.selectdata("supplies_report", param);
        }
    }
}
