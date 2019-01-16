using ReportTool.DomainClasses;
using ReportTool.Model;
using ReportTool.NewClasses.Collections.Implementations;
using ReportTool.NewClasses.Collections.Interfaces;
using ReportTool.NewClasses.Formatters.Domain;
using ReportTool.NewClasses.Formatters.Interfaces;
using ReportTool.NewClasses.Formatters.Utility;
using ReportTool.NewClasses.Reports;
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

            // Test of new report generator
            ITextElementFormatterFactory teff = new TextElementFormatterFactoryPadRight();
            IEnumerableCollectionFactory ecf = new EnumerableCollectionFactorySimple();
            IItemFormatter<Customer> ifc = new CustomerFormatter(teff, ReportGeneratorSetup.ReportWidth);
            IItemFormatter<Product> ifp = new ProductFormatter(teff, ReportGeneratorSetup.ReportWidth);
            IItemFormatter<ShippingBox> ifsb = new ShippingBoxFormatter(teff, ReportGeneratorSetup.ReportWidth);
            IReportGenerator irgBetter = new BetterReportGenerator(ifc, ifp, ifsb, ecf);
            dm.GenerateReports(irgBetter);
        }
    }
}