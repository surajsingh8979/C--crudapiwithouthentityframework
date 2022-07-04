using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApitoConnectDatabase
{
    public class FetchData
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["conMySql"].ConnectionString;
        }

        public DataSet GetDataSet(string query)
        {

            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    using (DataSet ds = new DataSet())
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        da.Fill(ds);
                        return ds;

                    }
                }
            }
        } //end GetDataSet
        public DataTable GetDataTable(string query)
        {

            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.SelectCommand.CommandTimeout = 120;
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    con.Close();
                }

                
            }
        } //end GetDataTable
        public DataTable GetDataTable(MySqlCommand cmd)
        {
            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                cmd.Connection = con;
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.SelectCommand.CommandTimeout = 120;
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        } //end GetDataTable
        public string GetScalar(string query)
        {
            string result = string.Empty;
            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    object resobj = cmd.ExecuteScalar();
                    if (resobj != null)
                        result = resobj.ToString();
                    else
                        result = "";
                    return result;
                }
            }
        } //end GetScalar
        public string GetScalar(MySqlCommand cmd)
        {

            string result = string.Empty;

            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                con.Open();
                cmd.Connection = con;
                // using (MySqlCommand cmd = new MySqlCommand(query, con))
                //{

                object resobj = cmd.ExecuteScalar();
                if (resobj != null)
                    result = resobj.ToString();
                else
                    result = "";
                return result;

                // }
            }
        } //end GetScalar
        public int InsertCommand(MySqlCommand cmd)
        {
            // System.Configuration.ConfigurationManager.ConnectionStrings["Confillose"].ConnectionString
            var conn = GetConnectionString();
            string result = string.Empty;
            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                cmd.Connection = con;
                con.Open();
                cmd.CommandTimeout = int.MaxValue;
                int res = cmd.ExecuteNonQuery();
                return res;
            }
        } //end InsertCommand
        public int InsertCommand(MySqlCommand cmd, MySqlConnection con)
        {
            //var conn = GetConnectionString();
            string result = string.Empty;
            //using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            //{
            //    cmd.Connection = con;
            //    con.Open();
            cmd.CommandTimeout = int.MaxValue;
            int res = cmd.ExecuteNonQuery();

            return res;
            //}
        }
        public int ExecuteQuery(string query)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    con.Open();
                    cmd.CommandTimeout = int.MaxValue;
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        } //end ExecuteQuery
        public int ExecuteQuery(MySqlCommand cmd)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                cmd.Connection = con;
                con.Open();
                cmd.CommandTimeout = int.MaxValue;
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }
    }
}