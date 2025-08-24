using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Lesson_4_DataLayer.Models;
using Lesson_4_DataLayer.DataLayer;


//DataLayer, DataAccessLayer, DL, DAL
namespace Lesson_4_DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomerModel cust1 = DL.Customer.ByID(1);
            //CustomerModel cust2 = DL.Customer.ByID(2);

            //Console.WriteLine(cust1);
            //Console.WriteLine(cust2);

            //int id = DL.Customer.Insert(new CustomerModel(0, "FN", "LN", new DateTime(2025, 3, 15)));
            //Console.WriteLine(id);

            List<CustomerModel> allCustomers = DL.Customer.All();
            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
