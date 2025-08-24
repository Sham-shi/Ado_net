using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Adapter
{
    /*
     * Отсоединенный режим
     * 1) создать адаптер
     * 2) какую таблицу читать
     * 3) DataSet читаем в DataTable
     * 4) из DataTable берем DataRow
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            string constr = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                ////1 allPosition через запрос
                //string query = "select * from dbo.Position order by 2";
                //SqlDataAdapter positionAllAdapter = new SqlDataAdapter(query, conn);

                //SqlCommandBuilder cmdbPosition = new SqlCommandBuilder(positionAllAdapter);

                //DataSet dsPos = new DataSet();
                //positionAllAdapter.Fill(dsPos, "Positions");
                //DataTable dtPos = dsPos.Tables["Positions"];

                //foreach (DataRow item in dtPos.Rows)
                //{
                //    Console.WriteLine($"{item[0], -5}{item[1], -15}");
                //}


                ////2 stp_CustomerAll через хран. процедуру
                //SqlDataAdapter customerAllAdapter = new SqlDataAdapter();
                //customerAllAdapter.InsertCommand = new SqlCommand("dbo.stp_CustomerAll", conn);
                //customerAllAdapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                //customerAllAdapter.SelectCommand = customerAllAdapter.InsertCommand;

                //SqlCommandBuilder cmdbCustomer = new SqlCommandBuilder(customerAllAdapter);

                //DataSet dsCus = new DataSet();
                //customerAllAdapter.Fill(dsCus, "Customers");
                //DataTable dtCus = dsCus.Tables["Customers"];

                //foreach (DataRow item in dtCus.Rows)
                //{
                //    Console.WriteLine($"{item[0],-5} {item[2],-15} {Convert.ToDateTime(item[3]).ToShortDateString(),-10}");
                //}


                ////3 add customer
                //SqlDataAdapter customerAddAdapter = new SqlDataAdapter("select * from Customers", conn);
                //SqlCommandBuilder cmdCustomerAdd = new SqlCommandBuilder(customerAddAdapter);

                //DataSet dsCusAdd = new DataSet();
                //customerAddAdapter.Fill(dsCusAdd, "Customers");

                //DataTable dtCusAdd = dsCusAdd.Tables["Customers"];

                //DataRow newCustomer = dtCusAdd.NewRow();
                //newCustomer[1] = "New_cus_FN";
                //newCustomer[2] = "New_cus_LN";
                //newCustomer[3] = DateTime.Now.ToShortDateString();

                //dtCusAdd.Rows.Add(newCustomer);

                ////foreach (DataRow item in dtCusAdd.Rows)
                ////{
                ////    Console.WriteLine($"{item[0],-5} {item[1],-15} {item[2],-15} {Convert.ToDateTime(item[3]).ToShortDateString(),-10}");
                ////}

                ////update DB
                //customerAddAdapter.Update(dsCusAdd, "Customers");
                //dtCusAdd.Clear();
                //customerAddAdapter.Fill(dsCusAdd, "Customers");

                //foreach (DataRow item in dtCusAdd.Rows)
                //{
                //    Console.WriteLine($"{item[0],-5} {item[1],-15} {item[2],-15} {Convert.ToDateTime(item[3]).ToShortDateString(),-10}");
                //}

                //4 delete customer
                SqlDataAdapter customerDeleteAdapter = new SqlDataAdapter("select * from Customers", conn);
                SqlCommandBuilder cmdCustomerDelete = new SqlCommandBuilder(customerDeleteAdapter);

                DataSet dsCusDelete = new DataSet();
                customerDeleteAdapter.Fill(dsCusDelete, "Customers");

                DataTable dtCusDelete = dsCusDelete.Tables["Customers"];
                dtCusDelete.PrimaryKey = new DataColumn[] { dtCusDelete.Columns["id"] };

                DataRow customerToDelete = dtCusDelete.Rows.Find(1007);
                if (customerToDelete != null)
                {
                    customerToDelete.Delete();
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("Error");
                }

                customerDeleteAdapter.Update(dsCusDelete, "Customers");
                dtCusDelete.Clear();
                customerDeleteAdapter.Fill(dsCusDelete, "Customers");

                foreach (DataRow item in dtCusDelete.Rows)
                {
                    Console.WriteLine($"{item[0],-5} {item[1],-15} {item[2],-15} {Convert.ToDateTime(item[3]).ToShortDateString(),-10}");
                }

            }
        }
    }
}
