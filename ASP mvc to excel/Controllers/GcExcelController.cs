using Microsoft.AspNetCore.Mvc;
using GrapeCity.Documents.Excel;
using System.Drawing;
using GrapeCity.DataVisualization.TypeScript;
using ExcelData;
using ExcelServices;
using TeacherServices;

namespace ASP_mvc_to_excel.Controllers
{
    public class GcExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public void PostStudentInfo(StudentInfoModel[] studenten)
        {
            var services = new ExcelServices.ExcelServices(studenten);
        
            services.Execute();
        }

        public IActionResult Teachers()
        {
            return View();
        }
        
        public void PostTeacherInfo(TeacherData[] teachers)
        {
            var teacherService = new TeacherServices.TeacherServices(teachers);
        
            teacherService.Execute();
        }
    }
}