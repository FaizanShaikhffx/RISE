using CRUDWithMVCAndADO.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDWithMVCAndADO.Data
{
    public class EmployeeDataAccessLayer
    {
        string cs = ConnectionString.dbcs;

        
        public List<Employees> getAllEmployees() {

            List<Employees> empList = new List<Employees>();
            using (SqlConnection connection = new SqlConnection(cs)) {

                using (SqlCommand command = new SqlCommand("spGetAllEmployee", connection)) { 
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open(); 
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        Employees emp = new Employees();
                        emp.Id = Convert.ToInt32(reader["Id"]);
                        emp.Name = reader["Name"].ToString() ?? "";
                        emp.Gender = reader["Gender"].ToString() ?? "";
                        emp.Age = Convert.ToInt32(reader["Age"]); 
                        emp.Designation = reader["Designation"].ToString() ?? "";
                        emp.City = reader["City"].ToString() ?? "";
                        empList.Add(emp); 
                    }
                }

            return empList; 
            }
        
        }




        public Employees getEmployeeById(int? id)
        {
            Employees emp = new Employees();
            using (SqlConnection connection = new SqlConnection(cs)) {
                SqlCommand command = new SqlCommand("select * from employees where id = @id", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", id); 
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";
                }
            }
            return emp;

        }







        public void AddEmployee(Employees emp)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("spAddEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", emp.Name);
                    command.Parameters.AddWithValue("@Gender", emp.Gender);
                    command.Parameters.AddWithValue("@Age", emp.Age);
                    command.Parameters.AddWithValue("@Designation", emp.Designation);
                    command.Parameters.AddWithValue("@City", emp.City);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }



        public void UpdateEmployee(Employees emp)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("spUpdateEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", emp.Id);
                    command.Parameters.AddWithValue("@Name", emp.Name);
                    command.Parameters.AddWithValue("@Gender", emp.Gender);
                    command.Parameters.AddWithValue("@Age", emp.Age);
                    command.Parameters.AddWithValue("@Designation", emp.Designation);
                    command.Parameters.AddWithValue("@City", emp.City);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int? id) {
            using (SqlConnection connection = new SqlConnection(cs)) {

                using (SqlCommand command = new SqlCommand("spDeleteEmployee", connection)) { 
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();

                }



            }
            
        }

    }    
}
