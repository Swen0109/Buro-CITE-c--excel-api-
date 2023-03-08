namespace ExcelData
{
    public class StudentInfoModel
    {
        public int? id { get; set; }

        public string? StudentName
        {
            get;
            set;
        }

        public int? StudentAge
        {
            get;
            set;
        }

        public int? StudentYear
        {
            get;
            set;
        }
    }
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }


}