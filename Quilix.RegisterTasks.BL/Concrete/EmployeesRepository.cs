using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Quilix.RegisterTasks.Dal;
namespace Quilix.RegisterTasks.BL.Concrete
{
   
    public class EmployeesRepository : Repository<Employee, int>, GetAllRep<Employee>
    {


        public override Employee GetById(int id)
        {




            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, First_name, Middle_name,Last_name FROM Employees WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                Employee emp = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                emp = new Employee();

                                emp.Id = (int)reader["Id"];
                                emp.First_name = reader["First_name"].ToString();
                                emp.Middle_name = reader["Middle_name"].ToString();
                                emp.Last_name = reader["Last_name"].ToString();

                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return emp;
            }




        }





        public List<Employee> GetAll()
        {
            string sql = "Select Id, First_name, Middle_name, Last_name FROM Employees ORDER BY First_name";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Employee> list = new List<Employee>();
                Employee emp = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            emp = new Employee();
                            emp.Id = (int)reader["Id"];
                            emp.First_name = reader["First_Name"].ToString();
                            emp.Middle_name = reader["Middle_Name"].ToString();
                            emp.Last_name = reader["Last_Name"].ToString();

                            list.Add(emp);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }



        public override void Delete(int id)
        {

            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Employees Where Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }



        public override void Save(Employee emp)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Employees (First_name, Middle_name, Last_name) VALUES (@First_name, @Middle_name, @Last_name)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@First_name", emp.First_name);
                cmd.Parameters.AddWithValue("@Middle_name", emp.Middle_name);
                cmd.Parameters.AddWithValue("@Last_name", emp.Last_name);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public override void Update(Employee emp)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Employees SET First_name=@First_name, Middle_name= @Middle_name, Last_name=@Last_name Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@First_name", emp.First_name);
                cmd.Parameters.AddWithValue("@Middle_name", emp.Middle_name);
                cmd.Parameters.AddWithValue("@Last_name", emp.Last_name);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
