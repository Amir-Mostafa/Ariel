using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ariel.BL
{
    class car
    {
        DAL.DataAccesLier DAL = new DAL.DataAccesLier();
        public void add_car_order(int id, string total, DateTime time, string total_free, string total_pdf, string total_baka, int car_id,string disc)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@total", SqlDbType.NVarChar, 20);
            param[1].Value = total;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            param[3] = new SqlParameter("@total_free", SqlDbType.NVarChar,50);
            param[3].Value = total_free;

            param[4] = new SqlParameter("@total_pdf", SqlDbType.NVarChar, 50);
            param[4].Value = total_pdf;
            param[5] = new SqlParameter("@total_baka", SqlDbType.NVarChar, 50);
            param[5].Value = total_baka;
            param[6] = new SqlParameter("@car_id", SqlDbType.Int);
            param[6].Value = car_id;

            param[7] = new SqlParameter("@disc", SqlDbType.NVarChar, 50);
            param[7].Value = disc;
            DAL.open();
            DAL.executenonquery("add_car_order", param);
            DAL.close();
        }
        public void add_car_operations(int order_id, int product_id, string amount, DateTime time ,int car_id )
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
            DAL.executenonquery("add_car_operations", param);
            DAL.close();
        }
        public DataTable get_max_car_order()
        {

            return DAL.selectdata("get_max_car_order", null);


        }
        public void update_in_car(int id, string amount)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@amount", SqlDbType.NVarChar,20);
            param[1].Value = amount;
            DAL.open();
            DAL.executenonquery("update_in_car", param);
            DAL.close();
        }
        public void update_in_car2(int id, string amount)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@amount", SqlDbType.NVarChar, 20);
            param[1].Value = amount;
            DAL.open();
            DAL.executenonquery("update_in_car2", param);
            DAL.close();
        }
        public void update_in_car3(int id, string amount)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@amount", SqlDbType.NVarChar, 20);
            param[1].Value = amount;
            DAL.open();
            DAL.executenonquery("update_in_car3", param);
            DAL.close();
        }
        public void update_car_order(int id, string total, DateTime time,string total_free,string total_pdf,string total_baka,int car_id,string disc)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@total", SqlDbType.NVarChar, 20);
            param[1].Value = total;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            param[3] = new SqlParameter("@total_free", SqlDbType.NVarChar, 50);
            param[3].Value = total_free;
            param[4] = new SqlParameter("@total_pdf", SqlDbType.NVarChar, 50);
            param[4].Value = total_pdf;
            param[5] = new SqlParameter("@total_baka", SqlDbType.NVarChar, 50);
            param[5].Value = total_baka;
            param[6] = new SqlParameter("@car_id", SqlDbType.Int);
            param[6].Value = car_id;
            param[7] = new SqlParameter("@disc", SqlDbType.NVarChar,50);
            param[7].Value = disc;

            DAL.open();
            DAL.executenonquery("update_car_order", param);
            DAL.close();
        }
        public DataTable get_all_car_operations(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("get_all_car_operations", param);

        }
        public void delete_all_car_operations(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_all_car_operations", param);
            DAL.close();
        }
        public void delete_car_order(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_car_order", param);
            DAL.close();
        }
        public DataTable car_operation_arabic(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("car_operation_arabic", param);
        }
        public DataTable car_order_by_id(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("car_order_by_id", param);
        }
        public DataTable sell_car_report(DateTime d1,DateTime d2,int car_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[0].Value = d1;
            param[1] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[1].Value = d2;
            param[2] = new SqlParameter("@car_id", SqlDbType.Int);
            param[2].Value = car_id;



            return  DAL.selectdata("sell_car_report", param);
        }

        public void mony_operations(string add, string take)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@add_mony", SqlDbType.NVarChar,50);
            param[0].Value = add;

            param[1] = new SqlParameter("@take_mony", SqlDbType.NVarChar, 20);
            param[1].Value = take;
            DAL.open();
            DAL.executenonquery("mony_operations", param);
            DAL.close();
        }
        public DataTable all_car_orders()
        {

            return DAL.selectdata("all_car_orders", null);


        }
        public void save_free_product(int order_id,DateTime date,int product_id,string amount,string total,int car_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;
            param[1] = new SqlParameter("@date", SqlDbType.DateTime);
            param[1].Value = date;
            param[2] = new SqlParameter("@product_id", SqlDbType.Int);
            param[2].Value = product_id;

            param[3] = new SqlParameter("@amount", SqlDbType.NVarChar,50);
            param[3].Value = amount;
            param[4] = new SqlParameter("@total", SqlDbType.NVarChar, 50);
            param[4].Value = total;
            param[5] = new SqlParameter("@car_id", SqlDbType.Int);
            param[5].Value = car_id;
            DAL.open();
            DAL.executenonquery("add_gift", param);
            DAL.close();
        }

        public void delete_free_product(int order_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;
            DAL.open();
            DAL.executenonquery("delete_gift", param);
            DAL.close();
        }
        public DataTable get_all_order_gifts(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("get_all_order_gifts", param);
        }

        public DataTable gifts_of_only_order(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("gifts_of_only_order", param);
        }

        public DataTable get_all_cars()
        {
            
            return DAL.selectdata("get_all_cars", null);
        }

        public DataTable all_gifts(DateTime date1,DateTime date2)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[0].Value = date1;
            param[1] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[1].Value = date2;
            return DAL.selectdata("all_gifts", param);
        }
        public DataTable print_car_order(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("print_car_order", param);

        }

        public DataTable print_gifts(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("print_gifts", param);

        }

        public DataTable all_pdf(int id,DateTime date1, DateTime date2)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@from", SqlDbType.DateTime);
            param[0].Value = date1;
            param[1] = new SqlParameter("@to", SqlDbType.DateTime);
            param[1].Value = date2;
            param[2] = new SqlParameter("@car_id", SqlDbType.Int);
            param[2].Value = id;
            return DAL.selectdata("pdf_in_date", param);
        }

        public DataTable all_disc(DateTime date1, DateTime date2)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@from", SqlDbType.DateTime);
            param[0].Value = date1;
            param[1] = new SqlParameter("@to", SqlDbType.DateTime);
            param[1].Value = date2;
            return DAL.selectdata("disc_in_date", param);
        }

    }
}
