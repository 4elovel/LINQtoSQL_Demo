using System;
using System.Data.SQLite;

namespace LINQtoSQL_Demo
{

    internal class Program
    {
        static void Main(string[] args)
        {

            DataBase SQLitedb = new DataBase(new SQLiteConnection(@"Data Source=DataBase.sqlite"));
            SQLitedb.SelectAll();
            Console.ReadKey();
        }
    }
}
