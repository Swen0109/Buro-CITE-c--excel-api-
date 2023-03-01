using ExcelData;
using ExcelServices;

namespace MyExcelWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentInfoModel[] studenten = new StudentInfoModel[1];

            studenten[0] = new StudentInfoModel()
            {
                id = 1,
                StudentName = "Anand Shyamnarain",
                StudentAge = 47,
            };

            var services = new ExcelServices.ExcelServices(studenten);

            services.Execute();
        }
    }
}