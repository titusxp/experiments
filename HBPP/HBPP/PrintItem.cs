namespace HBPP
{
    public class PrintItem
    {
        public string Code { get; set; }
        public string EmployeeName { get; set; }
        public string AccountNumber { get; set; }
        public string Loan { get; set; }
        public string Interest { get; set; }
        public string Contribution { get; set; }
        public string Station { get; set; }

        public string LoanInteger
        {
            get { return string.IsNullOrWhiteSpace(this.Loan) ? "0" : this.Loan; }
        }

        public string Total
        {
            get
            {
                int loan = 0;
                int contri = 0;
                int.TryParse(this.Loan, out loan);
                int.TryParse(this.Contribution, out contri);
                return (loan + contri).ToString();
            }
        }
    }
}