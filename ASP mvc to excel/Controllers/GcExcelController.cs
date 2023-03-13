using Microsoft.AspNetCore.Mvc;
using GrapeCity.Documents.Excel;
using System.Drawing;
using GrapeCity.DataVisualization.TypeScript;
using ExcelData;
//using ExcelServices;
using System.Net;
using System.Text;
using System.Web;
using Nancy.Json;
using GrapeCity.Documents.DX.Direct2D;
using ExcelLanguagePackage;


namespace ASP_mvc_to_excel.Controllers
{
    public class GcExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public void PostStudentInfo(StudentInfoModel[] studenten)
        //{
        //    var excelServices = new ExcelServices.ExcelServices(studenten);

        //    excelServices.Execute();
        //}

        [HttpPost]
        public void PostStudentInfo(StudentInfoModel[] studenten)
        {      
            string apiUrl = "https://localhost:7158/swagger/index.html";
                                
            object info = studenten;
            
            string inputJson = (new JavaScriptSerializer()).Serialize(info);//Makes sure data is translated into a format suitable for transfer over a network.
            WebClient client = new WebClient();//provides common methods for sending data to or receiving data from any local or Internet resource.
            client.Headers["Content-type"] = "application/json";//Changes the sending data to json string.
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString(apiUrl, inputJson);//uploads the apiUrl + the string of the function with the student data.
        }    
                           
        public IActionResult Teachers()
        {   
            return View();
        }
        
        public IActionResult Contact()
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