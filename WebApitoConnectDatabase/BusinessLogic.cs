using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebApitoConnectDatabase;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WebApitoConnectDatabase
{
    public class BusinessLogic
    {
        FetchData fd = new FetchData();
        public DataTable GetData()
        {
            string Query = @"SELECT * FROM emp";
            DataTable dt = new DataTable();
            dt = fd.GetDataTable(Query);
            return dt;
        }
        public void PostDatas(Employee emps)
        {
            string Query = @"insert into emp(id,name,age)values('"+emps.Id+"','"+emps.Name+"','"+emps.age+"')";
            fd.ExecuteQuery(Query);
           
        }
        public void UpdateData(Employee emps)
        {
            string Query = @"UPDATE emp  SET name='" + emps.Name + "' , age= '" + emps.age + "'  WHERE id= '" + emps.Id + "' ";
          
            fd.ExecuteQuery(Query);

        

            //cmd.Parameters.AddWithValue("@name", emps.Name.ToString());
            //cmd.ExecuteQuery.Parameters.AddWithValue("@age", emps.age.ToString());
            //cmd.ExecuteQuery(Query);
        }

        public void Delete(Employee emps)
        {
            string Query = @"DELETE FROM emp WHERE id='" + emps.Id + "'";
            fd.ExecuteQuery(Query); ;

    }
}
}
