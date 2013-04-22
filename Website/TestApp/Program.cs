using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Odbc;
using System.Data;
using MyBlog.Model;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
           /* string local = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
            string remote = ConfigurationManager.ConnectionStrings["remote"].ConnectionString;
            OdbcDataAdapter adapter1 = new OdbcDataAdapter("SELECT * FROM user", remote);
            DataSet set1 = new DataSet();
            adapter1.Fill(set1, "set1");


            foreach (DataRow row in set1.Tables["set1"].Rows)
            {
                Console.Write(row["iduser"] + " ");
            }

            if (set1.Tables["set1"].Rows.Count > 0)
            {
                Console.WriteLine("Welcome!");
            }
            else
            {
                Console.WriteLine("Not connected!");
            }*/
            User newuser = new User("Bla", "12345", "bla@localhost", 1);

            Console.ReadKey();
        }
    }
}
