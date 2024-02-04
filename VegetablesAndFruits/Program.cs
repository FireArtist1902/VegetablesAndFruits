using System.Data.SqlClient;
using System.Threading.Channels;

namespace VegetablesAndFruits
{
    internal class Program
    {
        public static string StrConn => @"Data Source=DESKTOP-TD7GATJ\SQLEXPRESS;Initial Catalog=VegetablesAndFruits;Integrated Security=True;Connect Timeout=30;";
        private static SqlConnection _conn;
        static void Main(string[] args)
        {
            bool IsWork = true;
            using (SqlConnection con = new SqlConnection(StrConn))
            {
                while (IsWork)
                {
                    var query = "SELECT * FROM TableVegetablesAndFruits";
                    var cmd = new SqlCommand(query, con);
                    Console.WriteLine("Ви успішно під'єднались");
                    Console.WriteLine("0.Від'єднання");
                    Console.WriteLine("1.Відображення всієї інформації з таблиці овочів і фруктів.");
                    Console.WriteLine("2.Відображення усіх назв овочів і фруктів");
                    Console.WriteLine("3.Відображення усіх кольорів");
                    Console.WriteLine("4.Показати максимальну калорійність");
                    Console.WriteLine("5.Показати мінімальну калорійність.");
                    Console.WriteLine("6.Показати середню калорійність");
                    Console.WriteLine("7.Показати кількість овочів.");
                    Console.WriteLine("8.Показати кількість фруктів.");
                    Console.WriteLine("9.Показати кількість овочів і фруктів заданого кольору");
                    Console.WriteLine("10.Показати овочі та фрукти з калорійністю нижче вказаної");
                    Console.WriteLine("11.Показати овочі та фрукти з калорійністю вище вказаної.");
                    Console.WriteLine("12.Показати овочі та фрукти з калорійністю у вказаному діапазоні.");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 0)
                    {
                        IsWork = false;
                    }
                    else if (choice == 1)
                    {
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Name"]}, {reader["Type"]}, {reader["Color"]}, {reader["CalorieContent"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    }
                    else if (choice == 2)
                    {
                        query = "SELECT Name FROM TableVegetablesAndFruits";
                        cmd = new SqlCommand(query, con);
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Name"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    }
                    else if (choice == 3)
                    {
                        query = "SELECT Color FROM TableVegetablesAndFruits";
                        cmd = new SqlCommand(query, con);
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Color"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    }
                    else if (choice == 4)
                    {
                        query = "SELECT MAX(CalorieContent) AS 'Max Calorie' FROM TableVegetablesAndFruits";
                        cmd = new SqlCommand(query, con);
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Max Calorie"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    }
                    else if (choice == 5)
                    {
                        query = "SELECT MIN(CalorieContent) AS 'Min Calorie' FROM TableVegetablesAndFruits";
                        cmd = new SqlCommand(query, con);
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Min Calorie"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    } else if (choice == 6)
                    {
                        query = "SELECT AVG(CalorieContent) AS 'Avg Calorie' FROM TableVegetablesAndFruits";
                        cmd = new SqlCommand(query, con);
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Avg Calorie"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    } else if(choice == 7)
                    {
                        query = "SELECT COUNT(Id) AS 'Count vegetables' FROM VegetablesAndFruits.dbo.TableVegetablesAndFruits WHERE TableVegetablesAndFruits.Type = 'Vegetable'";
                        cmd = new SqlCommand(query, con);
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Count vegetables"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    } else if( choice == 8)
                    {
                        query = "SELECT COUNT(Id) AS 'Count fruits' FROM VegetablesAndFruits.dbo.TableVegetablesAndFruits WHERE TableVegetablesAndFruits.Type = 'Fruit'";
                        cmd = new SqlCommand(query, con);
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Count fruits"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    } else if (choice == 9)
                    {
                        Console.Clear();
                        Console.WriteLine("Введіть потрібний Вам колір");
                        string color = Console.ReadLine();
                        query = $"SELECT COUNT(Id) AS 'Count' FROM VegetablesAndFruits.dbo.TableVegetablesAndFruits WHERE TableVegetablesAndFruits.Color = '{color}'";
                        cmd = new SqlCommand(query, con);
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Count"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    } else if (choice == 10)
                    {
                        Console.Clear();
                        Console.WriteLine("Введіть потрібну Вам кількість калорій");
                        int cal =Convert.ToInt32(Console.ReadLine());
                        query = $"SELECT Name FROM VegetablesAndFruits.dbo.TableVegetablesAndFruits WHERE TableVegetablesAndFruits.CalorieContent < {cal}";
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Name"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    } else if (choice == 11)
                    {
                        Console.Clear();
                        Console.WriteLine("Введіть потрібну Вам кількість калорій");
                        int cal = Convert.ToInt32(Console.ReadLine());
                        query = $"SELECT Name FROM VegetablesAndFruits.dbo.TableVegetablesAndFruits WHERE TableVegetablesAndFruits.CalorieContent > {cal}";
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Name"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    } else if(choice == 12)
                    {
                        Console.Clear();
                        Console.WriteLine("Від");
                        int first = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("До");
                        int second = Convert.ToInt32(Console.ReadLine());
                        query = $"SELECT Name FROM VegetablesAndFruits.dbo.TableVegetablesAndFruits WHERE TableVegetablesAndFruits.CalorieContent BETWEEN {first} AND {second}";
                        Console.Clear();
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Name"]}");

                            }
                        }
                        Console.WriteLine("Для повернення натисніть ENTER");
                        Console.ReadLine();
                        Console.Clear();
                        con.Close();
                    }
                }
                con.Close();
            } 

        }
    }
}