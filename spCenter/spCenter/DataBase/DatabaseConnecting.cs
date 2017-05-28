using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Collections;

namespace spCenter.DataBase
{
    class DatabaseConnecting
    {
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataReader dr;
        string oradb = "DATA SOURCE=155.158.112.45:1521/OLTPSTUD;PERSIST SECURITY INFO=True;USER ID=MSBD9;PASSWORD=now123";

        public DatabaseConnecting()
        {
            /* to działa!!!!
            try
            {
                string oradb = "DATA SOURCE=155.158.112.45:1521/OLTPSTUD;PERSIST SECURITY INFO=True;USER ID=MSBD9;PASSWORD=now123";

                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = oradb;

                conn.Open();

                OracleCommand cmd = conn.CreateCommand();


                cmd.CommandText = "SELECT NAME FROM DEPT WHERE ID = 10";


                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    g = dr.GetString(0);
                conn.Close();
            }
            catch (Exception ex)
            {
                g = ex.Message;
            }*/
            
        }
        public List<string> Select(string qerry)
        {
            List<string> selectList = new List<string>();
            try
            {
                

                conn = new OracleConnection();
                conn.ConnectionString = oradb;

                conn.Open();

                cmd = conn.CreateCommand();


                cmd.CommandText = qerry;


                dr = cmd.ExecuteReader();

                for(int i = 0; dr.Read(); i++)
                    selectList.Add(dr.GetString(0));
                conn.Close();
            }
            catch (Exception ex)
            {
               
            }
            return selectList;
        }
        public void insert(string querry)
        {

        }
    }
}
