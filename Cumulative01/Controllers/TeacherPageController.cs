using Cumulative01.Controllers;
using Cumulative01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative01.Controllers

{
    public class TeacherPageController : Controller
    {
        private readonly TeacherAPIController _teacherAPIController;
        public TeacherPageController(TeacherAPIController teacherAPIController)
        {
            _teacherAPIController = teacherAPIController;
        }
        public IActionResult List()
        {
            List<Teacher> teachers = _teacherAPIController.ListTeacherNames();
            return View(teachers);  
        }
        public IActionResult Show(int id)
        {
            Teacher teacher = _teacherAPIController.GetTeacher(id);
            return View(teacher);
        }
    }
}
