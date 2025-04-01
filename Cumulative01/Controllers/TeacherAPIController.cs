using Microsoft.AspNetCore.Mvc;
using Cumulative01.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using MySql.Data.MySqlClient;
namespace  Cumulative01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private SchoolDbContext _context;
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }
        [HttpGet(template:"Teacher")]
        public List<Teacher>   ListTeacherNames()
        {
            List<Teacher> teachers = new List<Teacher>();
            MySqlConnection Connection = _context.AccessDatabase();
            Connection.Open();
            string Query = "SELECT * FROM teachers";
            MySqlCommand Command=Connection.CreateCommand();
            Command.CommandText = Query;
            MySqlDataReader DataReader = Command.ExecuteReader();
            
            while(DataReader.Read())
            {
                int TeacherId=Convert.ToInt32(DataReader["teacherid"]);
                string TeacherFName=DataReader["teacherfname"].ToString();
                string TeacherLName=DataReader["teacherlname"].ToString();
                string EmployeeID=DataReader["employeeid"].ToString();
                DateTime HireDate=Convert.ToDateTime(DataReader["hiredate"]);
                double Salary=Convert.ToDouble(DataReader["salary"]);

                Teacher teacher = new Teacher();
                
                teacher.TeacherId = TeacherId;
                teacher.TeacherFName = TeacherFName;
                teacher.TeacherLName = TeacherLName;
                teacher.EmployeeID=EmployeeID;
                teacher.HireDate=HireDate;
                teacher.Salary=Salary;
                teacher.TeacherId=Convert.ToInt32(DataReader["teacherid"]);
               
                teachers.Add(teacher);
            }
            Connection.Close();
            return teachers;

        }
        [HttpGet(template:"Teacher/{id}")]
        public Teacher GetTeacher(int id)
        {
            Teacher teacher = new Teacher();
            MySqlConnection Connection = _context.AccessDatabase();
            Connection.Open();
            string Query = "SELECT * FROM teachers WHERE teacherId = "+id;
            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = Query;
            MySqlDataReader DataReader = Command.ExecuteReader();
        
            while(DataReader.Read())
            {
                int TeacherId=Convert.ToInt32(DataReader["teacherid"]);
                string TeacherFName=DataReader["teacherfname"].ToString();
                string TeacherLName=DataReader["teacherlname"].ToString();
                string EmployeeID=DataReader["employeeid"].ToString();
                DateTime HireDate=Convert.ToDateTime(DataReader["hiredate"]);
                double Salary=Convert.ToDouble(DataReader["salary"]);
                
                teacher.TeacherId = TeacherId;
                teacher.TeacherFName = TeacherFName;
                teacher.TeacherLName = TeacherLName;
                teacher.EmployeeID=EmployeeID;
                teacher.HireDate=HireDate;
                teacher.Salary=Salary;
                teacher.TeacherId=Convert.ToInt32(DataReader["teacherid"]);
               
            }
            Connection.Close();
            return teacher;
        }
        
    }
    
}
