using Microsoft.AspNetCore.Mvc;
using Cumulative01.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Cumulative01.Controllers
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

        /// <summary>
        /// Retrieves a list of all teachers in the system.
        /// </summary>
        /// <example>
        /// GET api/TeacherAPI/Teacher -> Returns a list of teacher objects.
        /// </example>
        /// <returns>
        /// A list of <see cref="Teacher"/> objects containing teacher details.
        /// </returns>
        [HttpGet(template: "Teacher")]
        public List<Teacher> ListTeacherNames()
        {
            List<Teacher> teachers = new List<Teacher>();
            MySqlConnection Connection = _context.AccessDatabase();
            Connection.Open();
            string Query = "SELECT * FROM teachers";
            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = Query;
            MySqlDataReader DataReader = Command.ExecuteReader();

            
            
            
            while (DataReader.Read())
            {
                int TeacherId = Convert.ToInt32(DataReader["teacherid"]);
                string TeacherFName = DataReader["teacherfname"].ToString();
                string TeacherLName = DataReader["teacherlname"].ToString();
                string EmployeeID = DataReader["employeeid"].ToString();
                DateTime HireDate = Convert.ToDateTime(DataReader["hiredate"]);
                double Salary = Convert.ToDouble(DataReader["salary"]);

               
                
                Teacher teacher = new Teacher
                {
                    TeacherId = TeacherId,
                    TeacherFName = TeacherFName,
                    TeacherLName = TeacherLName,
                    EmployeeID = EmployeeID,
                    HireDate = HireDate,
                    Salary = Salary
              
                
                };

                teachers.Add(teacher);
          
            
            }
            Connection.Close();
            return teachers;
        }

        /// <summary>
        /// Retrieves details of a specific teacher based on their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the teacher.</param>
        /// <example>
        /// GET api/TeacherAPI/Teacher/1 -> Returns details of the teacher with ID 1.
        /// </example>
        /// <returns>
        /// A <see cref="Teacher"/> object containing teacher details.
        /// </returns>
        [HttpGet(template: "Teacher/{id}")]
        public Teacher GetTeacher(int id)
        {
            Teacher teacher = new Teacher();
            MySqlConnection Connection = _context.AccessDatabase();
            Connection.Open();
            string Query = "SELECT * FROM teachers WHERE teacherId = " + id;
            MySqlCommand Command = Connection.CreateCommand();
            Command.CommandText = Query;
            MySqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                int TeacherId = Convert.ToInt32(DataReader["teacherid"]);
                string TeacherFName = DataReader["teacherfname"].ToString();
                string TeacherLName = DataReader["teacherlname"].ToString();
                string EmployeeID = DataReader["employeeid"].ToString();
                DateTime HireDate = Convert.ToDateTime(DataReader["hiredate"]);
                double Salary = Convert.ToDouble(DataReader["salary"]);

                teacher.TeacherId = TeacherId;
                teacher.TeacherFName = TeacherFName;
                teacher.TeacherLName = TeacherLName;
                teacher.EmployeeID = EmployeeID;
                teacher.HireDate = HireDate;
                teacher.Salary = Salary;
            }
            Connection.Close();
            return teacher;
        }
    }
}
