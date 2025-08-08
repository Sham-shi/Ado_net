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

                //1 - ExecuteReader()
                string sqlCommand = "select * from [PV425_Company_DB].[dbo].[Employee]";
                // необязательно экранировать квадратными скобками (PV425_Company_DB.dbo.Epmployee)
                SqlCommand cmd = new SqlCommand(sqlCommand, conn);

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    //var f0 = dataReader["EmployeeID"];
                    //var f1 = dataReader["LastName"];
                    //var f2 = dataReader["Salary"];

                    Console.WriteLine($"{dataReader["EmployeeID"],4}{dataReader["LastName"],15}{dataReader["Salary"],10}");
                }
                Console.WriteLine("\n-----------------------------------------------------------------\n");

                dataReader.Close();


                //2 - ExecuteScalar()
                string sqlCommand2 = "select sum(Salary) as SalaryTotal from Employee";
                SqlCommand cmd2 = new SqlCommand(sqlCommand2, conn);
                object res = cmd2.ExecuteScalar();
                Console.WriteLine($"SalaryTotal = {res}");

                Console.WriteLine("\n-----------------------------------------------------------------\n");


                //3 - ExecuteNonQuery()
                string sqlCommand3 = "insert into Position (PositionName) values('Director')";
                SqlCommand cmd3 = new SqlCommand(sqlCommand3, conn);

                int res2 = cmd3.ExecuteNonQuery();
                Console.WriteLine(res2);
            }
        }
    }
}
