using ExcelData;
using ExcelHelper;
using GrapeCity.Documents.Excel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWorksheetFill
{

    public class ExcelWorksheetFiller : ExcelHelperBase
    {
        private IWorksheet _ws;
        private StudentInfoModel[] _studenten;

        public ExcelWorksheetFiller(IWorksheet ws, StudentInfoModel[] studenten)
        {
            _ws = ws;
            _studenten = studenten;
        }

        public override void Execute()
        {
            for (int i = 0; i < _studenten.Length;)
            {

                if (_studenten.Length < 2)
                {
                    var oneStudent = _studenten[i];
                    _ws.Range["A2:C2"].Value = new object[,]
                 {
                    { oneStudent.id, oneStudent.StudentName, oneStudent.StudentAge, oneStudent.StudentYear},
                     };
                }

                else
                {
                    var student = _studenten[i];
                    var column = "J" + (i + 11);
                    var row = "M" + (i + 11);

                    _ws.Range[column + ":" + row].Value = new object[,]
                    {
                    { student.id, student.StudentName, student.StudentAge, student.StudentYear },
                    };
                    i++;
                }
            }
        }
    }
}
