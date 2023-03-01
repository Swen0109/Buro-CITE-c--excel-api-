using ExcelHelper;
using GrapeCity.Documents.Excel;

namespace ExcelWorksheet
{

    public class ExcelWorksheetCreator : ExcelHelperBase
    {
        Workbook _workbook = new Workbook();

        public override void Execute()
        {
            _workbook.Worksheets[0].Range["J10:M10"].Value = new object[,] {
                { "Id", "Name", "Age", "Year" },
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