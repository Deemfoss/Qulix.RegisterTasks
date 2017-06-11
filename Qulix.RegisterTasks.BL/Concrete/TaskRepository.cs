using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using TaskP = Qulix.RegisterTasks.Dal;

namespace Qulix.RegisterTasks.BL.Concrete
{
    public class TasksRepository : Repository<TaskP.Task, int>, GetAllRep<TaskP.TaskGetAll>
    {


        public override TaskP.Task GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, Name, Size, Start_date,End_date,Employe_id,Status FROM Tasks WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                TaskP.Task emp = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                emp = new TaskP.Task();

                                emp.Id = (int)reader["Id"];
                                emp.Name = reader["Name"].ToString();
                                emp.Size = reader["Size"].ToString();
                                emp.Start_date = (DateTime)reader["Start_Date"];
                                emp.End_Date = (DateTime)reader["End_Date"];
                                emp.Status = reader["Status"].ToString();
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









        public List<TaskP.TaskGetAll> GetAll()
        {
            string StringConnection = ConfigurationManager.ConnectionStrings["ContextRegisterTasks"].ConnectionString;

            string sql = "Select Tasks.Id, Name, Start_date, End_date,Size,Employees.First_Name,Employees.Last_Name,Status  FROM Tasks INNER JOIN Employees ON Tasks.Employe_id=Employees.Id  ORDER BY Name";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<TaskP.TaskGetAll> list = new List<TaskP.TaskGetAll>();
                TaskP.TaskGetAll emp = null;


                conn.Open();
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        emp = new TaskP.TaskGetAll();
                        emp.Id = (int)reader["Id"];
                        emp.Name = reader["Name"].ToString();
                        emp.Size = reader["Size"].ToString();
                        emp.Start_date = (DateTime)reader["Start_Date"];
                        emp.End_Date = (DateTime)reader["End_Date"];
                        emp.First_name = reader["First_name"].ToString();
                        emp.Last_name = reader["Last_name"].ToString();
                        emp.Status = reader["Status"].ToString();
                        list.Add(emp);
                    }
                }


                return list;
            }
        }


        public override void Delete(int id)
        {

            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Tasks Where Id=@id";
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



        public override void Save(TaskP.Task task)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Tasks (Name, Size, Start_date,End_date,Employe_id,Status) VALUES (@Name, @Size, @Start_date,@End_date,@Employe_id,@Status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", task.Name);
                cmd.Parameters.AddWithValue("@Size", task.Size);
                cmd.Parameters.AddWithValue("@Start_date", task.Start_date);
                cmd.Parameters.AddWithValue("@End_date", task.End_Date);
                cmd.Parameters.AddWithValue("@Employe_id", task.Employee_Id);
                cmd.Parameters.AddWithValue("@Status", task.Status);


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

        public override void Update(TaskP.Task task)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Tasks SET Name=@Name, Size=@Size, Start_date=@Start_date, End_date=@End_date,Employe_id=@Employe_id,Status=@Status Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", task.Id);
                cmd.Parameters.AddWithValue("@Name", task.Name);
                cmd.Parameters.AddWithValue("@Size", task.Size);
                cmd.Parameters.AddWithValue("@Start_date", task.Start_date);
                cmd.Parameters.AddWithValue("@End_date", task.End_Date);
                cmd.Parameters.AddWithValue("@Employe_id", task.Employee_Id);
                cmd.Parameters.AddWithValue("@Status", task.Status);

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
