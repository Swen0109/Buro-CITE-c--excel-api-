using ExcelData;
using GrapeCity.Documents.Excel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherHelperBase;

namespace TeacherWorksheetFill
{
    public class TeacherWorksheetFiller : TeacherHelperBase.TeacherHelperBase
    {
        private IWorksheet _ws;
        private TeacherData[] _teachers;

        public TeacherWorksheetFiller(IWorksheet ws, TeacherData[] teachers)
        {
            _ws = ws;
            _teachers = teachers;
        }

        public override void Execute()
        {
            for (int i = 0; i < _teachers.Length;)
            {

                if (_teachers.Length < 2)
                {
                    var oneTeacher = _teachers[i];
                    _ws.Range["A2:C2"].Value = new object[,]
                 {
                        { oneTeacher.id, oneTeacher.TeacherName, oneTeacher.TeacherAge, oneTeacher.TeacherExperience},
                     };
                }

                else
                {
                    var teacher = _teachers[i];
                    var column = "J" + (i + 11);
                    var row = "M" + (i + 11);

                    _ws.Range[column + ":" + row].Value = new object[,]
                    {
                        { teacher.id, teacher.TeacherName, teacher.TeacherAge, teacher.TeacherExperience },
                    };
                    i++;
                }
            }
        }
    }
}
