using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lesson_3_CommandBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string constr = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                //2 [dbo].[stp_CustomerAdd] ------------------------------------------------------------------------------
                //string cust_add = "[dbo].[stp_CustomerAdd]";
                //SqlCommand cmd2 = new SqlCommand(cust_add, conn);
                //cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd2.Parameters.AddWithValue("@FirstName", "Ella");
                //cmd2.Parameters.AddWithValue("@LastName", "Chornogor");
                //cmd2.Parameters.AddWithValue("@DateOfBirth", DateTime.Now.ToShortDateString());
                //SqlParameter cust_id = cmd2.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int);
                //cust_id.Direction = ParameterDirection.Output; //определяем параметр как выходной
                //cmd2.ExecuteNonQuery();
                //Console.WriteLine((int)cust_id.Value);

                //with output dbo.stp_CustomerAdd ------------------------------------------------------------------------------
                //string custAdd = "dbo.stp_CustomerAdd";
                //SqlCommand cmd = new SqlCommand(custAdd, conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                //SqlCommandBuilder.DeriveParameters(cmd);
                //cmd.Parameters[4].Value = DBNull.Value;
                //cmd.Parameters[1].Value = "NewFirstName";
                //cmd.Parameters[2].Value = "NewLastName";
                //cmd.Parameters[3].Value = DateTime.Now.AddYears(-1).ToShortDateString();

                //cmd.ExecuteNonQuery();
                //int new_id = (int)cmd.Parameters[4].Value;

                //Console.WriteLine(new_id);

                //with return dbo.stp_CustomerAdd_2 ------------------------------------------------------------------------------
                string custAdd = "dbo.stp_CustomerAdd_2";
                SqlCommand cmd = new SqlCommand(custAdd, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlCommandBuilder.DeriveParameters(cmd);
                cmd.Parameters[0].Value = DBNull.Value;
                cmd.Parameters[1].Value = "NewFirstName2";
                cmd.Parameters[2].Value = "NewLastName2";
                cmd.Parameters[3].Value = DateTime.Now.AddYears(-1).ToShortDateString();

                cmd.ExecuteNonQuery();
                int new_id = (int)cmd.Parameters[0].Value;

                Console.WriteLine(new_id);
            }
        }
    }
}
