using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

/*
Логика работы - C#
    Linq to Object
    Linq to SQL
    Linq to XML
Базы данных - MS SQL Server
Внешнее представление - WPF
Среда разработки - Net.Framewok
Dot.Net -> Ado.Net - часть Framewok (механизм провайдера)

Механизм работы:
1. Connection - соединение с БД
2. Query - запросы, команды (View, Function(), хранимые процедуры, триггеры)
3. Read query data - чтение данных
4. Disconnection - разъединение с БД

Режимы работы:
- присоединенный
- отсоединенный

Базовые классы:
--DbConnection
--DbCommand - ExecuteReader() -table,
              ExecuteNonQuery() - возвращает кол-во обработанных(измененных) строк
              ExecuteScalar() - функции агрегирования
--DbDataReader
--DbDataAdapter
--DataTable
--DataSet

Виды работ с БД:
DBFirst - БД есть
ModelFirst - создаем модель БД в С# через конструктор
CodeFirst - создаем БД через код С#

Допы:
    DataLayer
    Linq_to_Sql
    Async
*/



namespace Lesson_1_connection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // явный подход
            ////1 вариант
            ////string connect = "Server=Shamil;Database=PV425_Company_DB;Trusted_Connection=True;";
            ////SqlConnection conn = new SqlConnection();
            ////conn.ConnectionString = connect;

            ////2 вариант
            //string connect = "Server=Shamil;Database=PV425_Company_DB;Trusted_Connection=True;";
            //SqlConnection conn = new SqlConnection(connect);

            ////3 вариант
            ////SqlConnection conn = new SqlConnection("Server=Shamil;Database=PV425_Company_DB;Trusted_Connection=True;");

            //правильный подход
            //1 вариант
            string constr = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                ////1 - ExecuteReader()
                //string sqlCommand = "select * from [PV425_Company_DB].[dbo].[Employee]";
                //// необязательно экранировать квадратными скобками (PV425_Company_DB.dbo.Epmployee)
                //SqlCommand cmd = new SqlCommand(sqlCommand, conn);

                //SqlDataReader dataReader;
                //dataReader = cmd.ExecuteReader();

                //while (dataReader.Read())
                //{
                //    //var f0 = dataReader["EmployeeID"];
                //    //var f1 = dataReader["LastName"];
                //    //var f2 = dataReader["Salary"];

                //    Console.WriteLine($"{dataReader["EmployeeID"],4}{dataReader["LastName"],15}{dataReader["Salary"],10}");
                //}
                //Console.WriteLine("\n-----------------------------------------------------------------\n");

                //dataReader.Close();


                ////2 - ExecuteScalar()
                //string sqlCommand2 = "select sum(Salary) as SalaryTotal from Employee";
                //SqlCommand cmd2 = new SqlCommand(sqlCommand2, conn);
                //object res = cmd2.ExecuteScalar();
                //Console.WriteLine($"SalaryTotal = {res}");

                //Console.WriteLine("\n-----------------------------------------------------------------\n");


                ////3 - ExecuteNonQuery()
                //string sqlCommand3 = "insert into Position (PositionName) values('Director')";
                //SqlCommand cmd3 = new SqlCommand(sqlCommand3, conn);

                //int res2 = cmd3.ExecuteNonQuery();
                //Console.WriteLine(res2);



                // ДЗ
                //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

                SqlDataReader dataReader;

                string sqlCommand1 = "select LastName, FirstName, Salary\r\nfrom PV425_Company_DB.dbo.Employee\r\nwhere Salary between\r\n    (select (min(salary) + 1) from PV425_Company_DB.dbo.Employee)\r\n    and\r\n    (select (max(salary) - 1) from PV425_Company_DB.dbo.Employee)";
                SqlCommand cmd1 = new SqlCommand(sqlCommand1, conn);
                dataReader = cmd1.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader["LastName"], 10}{dataReader["FirstName"], 10}{dataReader["Salary"],10}");
                }

                dataReader.Close();

                Console.WriteLine("\n-----------------------------------------------------------------\n");

                string sqlCommand2 = "select FirstName, LastName\r\nfrom PV425_Company_DB.dbo.Employee\r\nwhere LastName like '%ov'";
                SqlCommand cmd2 = new SqlCommand(sqlCommand2, conn);
                dataReader = cmd2.ExecuteReader();

                while (dataReader.Read())
                {
                    var value1 = dataReader.GetValue(0);
                    var value2 = dataReader.GetValue(1);

                    Console.WriteLine($"{value1, 10}{value2, 10}");
                }

                dataReader.Close();

                Console.WriteLine("\n-----------------------------------------------------------------\n");

                string sqlCommand3 = "select\r\n    FirstName,\r\n    LastName,\r\n    (select PositionName from PV425_Company_DB.dbo.Position\r\n    where PV425_Company_DB.dbo.Position.PositionID = PV425_Company_DB.dbo.Employee.PositionID) as PositionName\r\nfrom PV425_Company_DB.dbo.Employee";
                SqlCommand cmd3 = new SqlCommand(sqlCommand3, conn);
                dataReader = cmd3.ExecuteReader();

                while (dataReader.Read())
                {
                    var value1 = dataReader.GetValue(0).ToString();
                    var value2 = dataReader.GetValue(1).ToString();
                    var value3 = dataReader.GetValue(2).ToString();

                    Console.WriteLine($"{value1,10}{value2,10}{value3, 15}");
                }

                dataReader.Close();

                Console.WriteLine("\n-----------------------------------------------------------------\n");

                string sqlCommand4 = "select\r\n    LastName,\r\n    FirstName,\r\n    datediff(year, BirthDate, getdate()) - case\r\n        when\r\n            (month(BirthDate) > month(getdate())) or\r\n            (month(BirthDate) = month(getdate()) and\r\n            day(BirthDate) > day(getdate()))\r\n        then 1\r\n        else 0\r\n    end as Age\r\nfrom PV425_Company_DB.dbo.Employee";
                SqlCommand cmd4 = new SqlCommand(sqlCommand4, conn);
                dataReader = cmd4.ExecuteReader();


                while (dataReader.Read())
                {
                    Console.WriteLine($"{dataReader["LastName"],10}{dataReader["FirstName"],10}{dataReader["Age"],10}");
                }

                dataReader.Close();
            }
        }
    }
}
