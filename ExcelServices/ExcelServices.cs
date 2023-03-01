using ExcelData;
using GrapeCity.Documents.Excel;
using ExcelWorksheet;
using ExcelWorksheetFill;

namespace ExcelServices
{
    public class ExcelServices
    {
        StudentInfoModel[] _studenten;

        public ExcelServices(StudentInfoModel[] studenten)
        {
            _studenten = studenten;
        }
        public void Execute()
        {
            ExcelWorksheetCreator ewc = new ExcelWorksheetCreator();
            ewc.Execute();

            ExcelWorksheetFiller ewf = new ExcelWorksheetFiller(ewc.Worksheet, _studenten);
            ewf.Execute();

            var workBook = ewc.Workbook;

            workBook.Save("Students.xlsx");
            workBook.Save("students.pdf", SaveFileFormat.Pdf);
        }
    }
}