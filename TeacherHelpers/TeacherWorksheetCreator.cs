using GrapeCity.Documents.Excel;
using TeacherHelperBase;


namespace TeacherWorksheetCreate
{
    public class TeacherWorksheetCreator : TeacherHelperBase.TeacherHelperBase
    {
        Workbook _workbook = new Workbook();

        public override void Execute()
        {
            _workbook.Worksheets[0].Range["J10:M10"].Value = new object[,] {
                    { "Id", "Name", "Age", "Experience" },
                };
        }

        public IWorkbook Workbook
        {
            get
            {
                return _workbook;
            }
        }

        public IWorksheet Worksheet
        {
            get
            {
                return _workbook.Worksheets[0];
            }
        }
    }
}