using System.Globalization;

namespace HBPP
{
    public class PrintItem
    {
        public string Code { get; set; }
        public string EmployeeName { get; set; }
        public string AccountNumber { get; set; }
        public double Loan { get; set; }
        public double Interest { get; set; }
        public double Contribution { get; set; }
        public string Station { get; set; }
        public double Total => this.Loan + this.Contribution;
    }
}