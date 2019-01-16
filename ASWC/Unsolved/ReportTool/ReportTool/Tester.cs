using ReportTool.Model;
using ReportTool.Reporting;

namespace ReportTool
{
    public class Tester
    {
        public void Run()
        {
            DomainModel dm = new DomainModel();

            // Test of existing report generator
            IReportGenerator irg = new ReportGenerator();
            dm.GenerateReports(irg);
        }
    }
}