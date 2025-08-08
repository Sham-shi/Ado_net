using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Lesson_2_Stored_procedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string constr = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                //1 [dbo].[stp_CustomerAll] ------------------------------------------------------------------------------
                string customerAll = "[dbo].[stp_CustomerAll]";
                SqlCommand cmd = new SqlCommand(customerAll, conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    //var f0 = dataReader["EmployeeID"];
                    //var f1 = dataReader["LastName"];
                    //var f2 = dataReader["Salary"];

                    Console.WriteLine($"{dataReader["id"],4}{dataReader["LastName"],15}{dataReader["DateOfBirth"],20}");
                }
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                dataReader.Close();

                //2 [dbo].[stp_CustomerAdd] ------------------------------------------------------------------------------
                string cust_add = "[dbo].[stp_CustomerAdd]";
                SqlCommand cmd2 = new SqlCommand(cust_add, conn);
                
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@FirstName", "Ella");
                cmd2.Parameters.AddWithValue("@LastName", "Chornogor");
                cmd2.Parameters.AddWithValue("@DateOfBirth", DateTime.Now.ToShortDateString());
                
                SqlParameter cust_id = cmd2.Parameters.Add("@CustomerID", System.Data.SqlDbType.Int);
                cust_id.Direction = ParameterDirection.Output; //определяем параметр как выходной
                
                cmd2.ExecuteNonQuery();
                
                Console.WriteLine((int)cust_id.Value);
                Console.WriteLine("\n-----------------------------------------------------------------\n");

            }
        }
    }
}
