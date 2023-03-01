using ExcelData;
using GrapeCity.Documents.Excel;
using TeacherWorksheetCreate;
using TeacherWorksheetFill;

namespace TeacherServices
{
    public class TeacherServices
    {
        TeacherData[] _teachers;

        public TeacherServices(TeacherData[] teachers)
        {
            _teachers = teachers;
        }
        public void Execute()
        {
            TeacherWorksheetCreator ewc = new TeacherWorksheetCreator();
            ewc.Execute();

            TeacherWorksheetFiller ewf = new TeacherWorksheetFiller(ewc.Worksheet, _teachers);
            ewf.Execute();

            var workBook = ewc.Workbook;

            workBook.Save("Teachers.xlsx");
            workBook.Save("Teachers.pdf", SaveFileFormat.Pdf);
        }
    }
}