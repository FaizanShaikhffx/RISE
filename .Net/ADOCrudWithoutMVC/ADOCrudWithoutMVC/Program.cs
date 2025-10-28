using System;
using System.Data;
using System.Data.SqlClient;
class Program {

    static string ConnectionString = "Data Source=LAPTOP-ASRK055L\\SQLEXPRESS;Initial Catalog=crud;Integrated Security=True;Encrypt=False";
    
    

    public static void Main(string[] agrs) {
        while (true) {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1: Add a new student (Create)");
            Console.WriteLine("2: View all students (Read)");
            Console.WriteLine("3: Update a student's name (Update)");
            Console.WriteLine("4: Delete a student (Delete)");
            Console.WriteLine("5: Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ViewStudents();
                    break;
                case "3":
                    UpdateStudent();
                    break;
                case "4":
                    DeleteStudent();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddStudent() {
        Console.Write("Enter first name: ");
        string firstname = Console.ReadLine();
        Console.Write("Enter last name: ");
        string lastname = Console.ReadLine();

        string sqlQuery = "insert into students (firstname, lastname, EnrollmentDate) values(@firstName, @lastName, @enrollmentDate)";


        using (SqlConnection connection = new SqlConnection(ConnectionString)) {
            using (SqlCommand command = new SqlCommand(sqlQuery, connection)) {
                command.Parameters.AddWithValue("@firstName", firstname);
                command.Parameters.AddWithValue("@lastName", lastname);
                command.Parameters.AddWithValue("@enrollmentDate", DateTime.Now);

                try {
                    connection.Open();
                    int rowAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowAffected} row(s) inserted successfully.");
                }
                catch (Exception ex) {
                    Console.WriteLine("Error : " + ex);
                }
            }
        }
    }

    static void ViewStudents() {
        Console.WriteLine();
        Console.WriteLine("--- All Students ---");
        string sqlQuery = "select studentId, firstname, lastname, enrollmentdate from students";

        using (SqlConnection connection = new SqlConnection(ConnectionString)) {
            using (SqlCommand command = new SqlCommand(sqlQuery, connection)) {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["StudentID"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Enrolled: {((DateTime)reader["EnrollmentDate"]).ToShortDateString()}");
                        }
                    }
                }
                catch (Exception e) {
                    Console.WriteLine("Error : " + e); 
                }
            }
            
        }
    }

    static void UpdateStudent() {
        Console.Write("Enter student ID to update: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the new First Name : "); 
        string newFirstname = Console.ReadLine();
        Console.WriteLine("Enter the new Last Name : ");
        string newLastname = Console.ReadLine();

        string sqlQuery = "update students set firstname =  @newFirstname, lastname = @newLastname where studentid = @studentId ";

        using (SqlConnection connection = new SqlConnection(ConnectionString)) {

            using (SqlCommand command = new SqlCommand(sqlQuery, connection)) {
                    command.Parameters.AddWithValue("@newFirstname", newFirstname);
                    command.Parameters.AddWithValue("@newLastname", newLastname);
                    command.Parameters.AddWithValue("@studentId", studentId);
                try
                {
                    connection.Open();
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine("Student updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }
                }
                catch (Exception e) {
                    Console.WriteLine("Error : " + e);
                }
            }
        }


    }


    static void DeleteStudent() {
        Console.WriteLine("Enter The Id of student to delete");
        int studentId = int.Parse(Console.ReadLine());

        string sqlQuery = "delete from students where studentid = @studentId";

        using (SqlConnection connection = new SqlConnection(ConnectionString)) {
            using (SqlCommand command = new SqlCommand(sqlQuery, connection)) {
                command.Parameters.AddWithValue("@studentId", studentId); 
                try
                {
                    connection.Open();
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine("Student deleted successfully");
                    }
                    else {
                        Console.WriteLine("Student not found"); 
                    }
                }
                catch (Exception e) { 
                    Console.WriteLine("Error : " + e);
                }
            }
        }

    }



}