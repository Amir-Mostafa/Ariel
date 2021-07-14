using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Ariel.BL
{
    class buy_orders
    {
        DAL.DataAccesLier DAL = new DAL.DataAccesLier();
        public DataTable all_products_name()
        {
          
            return DAL.selectdata("all_products_name", null);

        }
        public DataTable select_product_by_id(int id)
        {
            SqlParameter []param=new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("select_product_by_id", param);
        }
        public DataTable get_max_id()
        {

            return DAL.selectdata("get_max_id", null);


        }
        public void add_buy_order(int id, string total, DateTime time)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@total", SqlDbType.NVarChar, 20);
            param[1].Value = total;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            DAL.open();
            DAL.executenonquery("add_buy_order", param);
            DAL.close();
        }
        public void add_buy_operation(int order_id, int product_id,string amount, DateTime time)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;
            param[1] = new SqlParameter("@product_id", SqlDbType.Int);
            param[1].Value = product_id;
            param[2] = new SqlParameter("@amount", SqlDbType.NVarChar,20);
            param[2].Value = amount;
            param[3] = new SqlParameter("@time", SqlDbType.DateTime);
            param[3].Value = time;
            DAL.open();
            DAL.executenonquery("add_buy_operation", param);
            DAL.close();
        }
        public void inc_product(int id, string amount)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@amount", SqlDbType.NVarChar,50);
            param[1].Value = amount;
            DAL.open();
            DAL.executenonquery("dec_product", param);
            DAL.close();
        }
        public void update_in_car(int id, string amount)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@amount", SqlDbType.NVarChar);
            param[1].Value = amount;
            DAL.open();
            DAL.executenonquery("update_in_car", param);
            DAL.close();
        }

        public void update_buy_order(int id,string total,DateTime time)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@total", SqlDbType.NVarChar,50);
            param[1].Value = total;
            param[2] = new SqlParameter("@time", SqlDbType.DateTime);
            param[2].Value = time;
            DAL.open();
            DAL.executenonquery("update_buy_order", param);
            DAL.close();
        }
        public void delete_all_buy_operation(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_all_buy_operation", param);
            DAL.close();
        }
        public void delete_buy_order(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_buy_order", param);
            DAL.close();
        }

        public DataTable get_buy_operations(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("get_buy_operations", param);
        }
        public DataTable bu_order_by_id(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("bu_order_by_id", param);
        }
        public DataTable get_arabic_operation(int id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = id;
            return DAL.selectdata("get_arabic_operation", param);
        }
        public DataTable all_buy_order()
        {

            return DAL.selectdata("all_buy_order", null);


        }
        public DataTable search_buy_order(string id)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,20);
            param[0].Value = id;
            return DAL.selectdata("search_buy_order", param);
        }
        public DataTable reort_buy_orders(DateTime d1, DateTime d2)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@start_date", SqlDbType.DateTime);
            param[0].Value = d1;

            param[1] = new SqlParameter("@end_date", SqlDbType.DateTime);
            param[1].Value = d2;
            
           return DAL.selectdata("reort_buy_orders", param);
            
        }
    }
}

