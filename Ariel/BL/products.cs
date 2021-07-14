using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Ariel.BL
{
    class products
    {

        public void insert(string name,string price ,int num,int min,string code)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@product_name", SqlDbType.NVarChar , 50);
            param[0].Value = name;
            param[1] = new SqlParameter("@num", SqlDbType.Int);
            param[1].Value = num;
            param[2] = new SqlParameter("@min", SqlDbType.Int);
            param[2].Value = min;
            param[3] = new SqlParameter("@price", SqlDbType.NVarChar,50);
            param[3].Value = price;
            param[4] = new SqlParameter("@code", SqlDbType.NVarChar, 50);
            param[4].Value = code;
            DAL.open();

            DAL.executenonquery("sp_insert_product", param);
            DAL.close();
        }
        public DataTable all(string name)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            return DAL.selectdata("all_products", param);
        }
        public DataTable all_products_name()
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            return DAL.selectdata("all_products_name", null);
        }
        public DataTable products_name()
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            return DAL.selectdata("products_name", null);
        }
        public DataTable search(string name)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@product_name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            return DAL.selectdata("product_search", param);
        }
        public void update_prduct(int id,string name,string price,int num,int min,string code)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@id", SqlDbType.Float);
            param[0].Value = id;
            param[1] = new SqlParameter("@product_name", SqlDbType.NVarChar, 50);
            param[1].Value = name;
            param[2] = new SqlParameter("@num", SqlDbType.Int);
            param[2].Value = num;
            param[3] = new SqlParameter("@price", SqlDbType.NVarChar);
            param[3].Value = price;
            param[4] = new SqlParameter("@min", SqlDbType.Int);
            param[4].Value = min;
            param[5] = new SqlParameter("@code", SqlDbType.NVarChar);
            param[5].Value = code;
            DAL.open();
            DAL.executenonquery("update_proc", param);
            DAL.close();
        }
        public void delete(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
             DAL.executenonquery("delete_proc", param);
             DAL.close();
        }
        public DataTable car_now()
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            return DAL.selectdata("car_now", null);

        }
        public DataTable select_products_for_mony()
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            return DAL.selectdata("select_products_for_mony", null);

        }
        public DataTable buy_operations_by_product_id(int id, DateTime d1, DateTime d2)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[1].Value = d1;
            param[2] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[2].Value = d2;
            return DAL.selectdata("buy_operations_by_product_id", param);
            
        }

        public DataTable sell_operations_by_product_id(int id, DateTime d1, DateTime d2)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[1].Value = d1;
            param[2] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[2].Value = d2;
            return DAL.selectdata("sell_operations_by_product_id", param);

        }

        public DataTable sell_operations_by_product_id_in_car(int id,int clint_id, DateTime d1, DateTime d2)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@clint_id", SqlDbType.Int);
            param[1].Value = clint_id;
            param[2] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[2].Value = d1;
            param[3] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[3].Value = d2;
            return DAL.selectdata("sell_operations_by_product_id_in_car", param);

        }
        public void update_free(int id,string free)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@product_id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@free", SqlDbType.NVarChar,50);
            param[1].Value = free;
            DAL.open();
            DAL.executenonquery("update_free", param);
            DAL.close();
        }
        public DataTable get_free_products()
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            return DAL.selectdata("get_free_products", null);
        }

        public void delet_all_free()
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            DAL.open();
            DAL.executenonquery("delet_all_free", null);
            DAL.close();
        }

        public void new_notification(string desc, string value, string order_id,DateTime date)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@desc", SqlDbType.NVarChar,50);
            param[0].Value = desc;
            param[1] = new SqlParameter("@value", SqlDbType.NVarChar, 50);
            param[1].Value = value;
            param[2] = new SqlParameter("@order_id", SqlDbType.NVarChar,50);
            param[2].Value = order_id;
            param[3] = new SqlParameter("@date", SqlDbType.DateTime);
            param[3].Value = date;
            DAL.open();
            DAL.executenonquery("new_notification", param);
            DAL.close();
        }
        public DataTable report_notifications(DateTime d1, DateTime d2)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[0].Value = d1;
            param[1] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[1].Value = d2;
            return DAL.selectdata("report_notifications", param);

        }

        public void delete_notification(int id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DAL.open();
            DAL.executenonquery("delete_notification", param);
            DAL.close();
        }


        public DataTable product_in_date(DateTime d1, DateTime d2,int product_id, int clint_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[0].Value = d1;
            param[1] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[1].Value = d2;
            param[2] = new SqlParameter("@product_id", SqlDbType.Int);
            param[2].Value = product_id;

            param[3] = new SqlParameter("@clint_id", SqlDbType.Int);
            param[3].Value = clint_id;
            return DAL.selectdata("product_in_date", param);

        }
        public DataTable get_car_sells_products(DateTime d1, DateTime d2, int product_id,int car_id)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@date1", SqlDbType.DateTime);
            param[0].Value = d1;
            param[1] = new SqlParameter("@date2", SqlDbType.DateTime);
            param[1].Value = d2;
            param[2] = new SqlParameter("@product_id", SqlDbType.Int);
            param[2].Value = product_id;
            param[3] = new SqlParameter("@car_id", SqlDbType.Int);
            param[3].Value = car_id;
            return DAL.selectdata("get_car_sells_products", param);

        }

        public void update_is_send(int id,int val)
        {
            DAL.DataAccesLier DAL = new DAL.DataAccesLier();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@val", SqlDbType.Int);
            param[1].Value = val;
            DAL.open();
            DAL.executenonquery("update_is_send", param);
            DAL.close();
        }


        
    }
}
