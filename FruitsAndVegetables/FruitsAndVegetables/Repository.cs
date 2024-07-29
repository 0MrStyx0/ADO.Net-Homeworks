using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsAndVegetables.Repository
{
    internal class Repository
    {
        public string connectionString {  get; set; }
        public SqlConnection connection { get; set; }
        public Repository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["localDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
            //connection.Open();
            //Console.WriteLine("Connection is open");
            //Thread.Sleep(1000);
            //Console.WriteLine("Connection properties:");
            //Thread.Sleep(1000);
            //Console.WriteLine("Connection string: {0}", connection.ConnectionString);
            //Thread.Sleep(1000);
            //Console.WriteLine("Database: {0}", connection.Database);
            //Thread.Sleep(1000);
            //Console.WriteLine("Server: {0}", connection.DataSource);
            //Thread.Sleep(1000);
            //Console.WriteLine("Server version: {0}", connection.ServerVersion);
            //Thread.Sleep(1000);
            //Console.WriteLine("State: {0}", connection.State);
            //Thread.Sleep(1000);
            //Console.WriteLine("WorkstationId: {0}\n", connection.WorkstationId);
            //Thread.Sleep(1000);
            //connection.Close();
        }

        public void ShowInfo()
        {
            string request = "select * from Plants";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request,connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);
                    string columnName3 = reader.GetName(2);
                    string columnName4 = reader.GetName(3);
                    string columnName5 = reader.GetName(4);

                    Console.WriteLine($"{columnName1} {columnName2} {columnName3} {columnName4} {columnName5}\n");
                    while (reader.Read())
                    {
                        int Id=reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Type = reader.GetString(2);
                        string Color = reader.GetString(3);
                        int CalorieContent = reader.GetInt32(4);
                        Console.WriteLine($"{Id}. {Name}, {Type}, {Color}, {CalorieContent}\n");
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void ShowNames()
        {
            string request = "select Name from Plants";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);

                    Console.WriteLine($"{columnName1}\n");
                    while (reader.Read())
                    {
                        string Name = reader.GetString(0);
                        Console.WriteLine($"{Name}\n");
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void ShowColors()
        {
            string request = "select distinct Color from Plants";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);

                    Console.WriteLine($"{columnName1}\n");
                    while (reader.Read())
                    {
                        string Color = reader.GetString(0);
                        Console.WriteLine($"{Color}\n");
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void MaxCalorieContent()
        {
            string request = "select max(CalorieContent) from Plants";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                object reader = command.ExecuteScalar();
                Console.WriteLine("Max Calorie Content: " + reader);
            }
            finally
            {
                connection.Close();
            }
        }

        public void MinCalorieContent()
        {
            string request = "select min(CalorieContent) from Plants";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                object reader = command.ExecuteScalar();
                Console.WriteLine("Min Calorie Content: " + reader);
            }
            finally
            {
                connection.Close();
            }
        }

        public void AverageCalorieContent()
        {
            string request = "select avg(CalorieContent) from Plants";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                object reader = command.ExecuteScalar();
                Console.WriteLine("Average Calorie Content: " + reader);
            }
            finally
            {
                connection.Close();
            }
        }

        public void VegetableCount()
        {
            string request = "select count(*) from Plants where [Type] = 'Vegetable' ";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                object reader = command.ExecuteScalar();
                Console.WriteLine("Vegetable Count: " + reader);
            }
            finally
            {
                connection.Close();
            }
        }

        public void FruitsCount()
        {
            string request = "select count(*) from Plants where [Type] = 'Fruit' ";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                object reader = command.ExecuteScalar();
                Console.WriteLine("Fruits Count: " + reader);
            }
            finally
            {
                connection.Close();
            }
        }

        public void SelectedColorCount(string Color)
        {
            string request = $"select count(*) from Plants where Color = '{Color}' ";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                object reader = command.ExecuteScalar();
                Console.WriteLine($"{Color} Count: " + reader);
            }
            finally
            {
                connection.Close();
            }
        }

        public void ColorCount()
        {
            string request = $"select Color, count(*) as [Count] from Plants group by Color";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string ColumnName1 = reader.GetName(0);
                    string ColumnName2 = reader.GetName(1);
                    Console.WriteLine($"{ColumnName1}\t {ColumnName2}");

                    while (reader.Read())
                    {
                        string Color = reader.GetString(0);
                        object Count = reader.GetInt32(1);
                        Console.WriteLine($"{Color}\t {Count}");
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void CalorieCountLowerThan(int value)
        {
            string request = $"select [Name],CalorieContent from Plants where CalorieContent < {value}";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string ColumnName1 = reader.GetName(0);
                    string ColumnName2 = reader.GetName(1);
                    Console.WriteLine($"{ColumnName1}\t {ColumnName2}");

                    while (reader.Read())
                    {
                        string Name = reader.GetString(0);
                        object CalorieContent = reader.GetInt32(1);
                        Console.WriteLine($"{Name}\t {CalorieContent}");
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void CalorieCountHigherThan(int value)
        {
            string request = $"select [Name],CalorieContent from Plants where CalorieContent > {value}";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string ColumnName1 = reader.GetName(0);
                    string ColumnName2 = reader.GetName(1);
                    Console.WriteLine($"{ColumnName1}\t {ColumnName2}");

                    while (reader.Read())
                    {
                        string Name = reader.GetString(0);
                        object CalorieContent = reader.GetInt32(1);
                        Console.WriteLine($"{Name}\t {CalorieContent}");
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void CalorieCountInDiapason(int value1,int value2)
        {
            string request = $"select [Name],CalorieContent from Plants where CalorieContent between {value1} and {value2}";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string ColumnName1 = reader.GetName(0);
                    string ColumnName2 = reader.GetName(1);
                    Console.WriteLine($"{ColumnName1}\t {ColumnName2}");

                    while (reader.Read())
                    {
                        string Name = reader.GetString(0);
                        object CalorieContent = reader.GetInt32(1);
                        Console.WriteLine($"{Name}\t {CalorieContent}");
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void RedOrYellow()
        {
            string request = $"select [Name], Color from Plants where Color = 'Red' or Color = 'Yellow'";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string ColumnName1 = reader.GetName(0);
                    string ColumnName2 = reader.GetName(0);
                    Console.WriteLine($"{ColumnName1}\t {ColumnName2}");

                    while (reader.Read())
                    {
                        string Name = reader.GetString(0);
                        string Color = reader.GetString(1);
                        Console.WriteLine($"{Name}\t {Color}");
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
