using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public interface IExportStrategy
    {
        void Export(string data);
    }
    public class CsvExportStrategy : IExportStrategy
    {
        public void Export(string data)
        {
            Console.WriteLine($"Exporting data in CSV format: {data}");
        }
    }
    public class JsonExportStrategy : IExportStrategy
    {
        public void Export(string data)
        {
            Console.WriteLine($"Exporting data in JSON format: {data}");
        }
    }
    public class XmlExportStrategy : IExportStrategy
    {
        public void Export(string data)
        {
            Console.WriteLine($"Exporting data in XML format: {data}");
        }
    }
    public class PdfExportStrategy : IExportStrategy
    {
        public void Export(string data)
        {
            Console.WriteLine($"Exporting data in PDF format: {data}");
        }
    }
    public class DataExporterContext
    {
        private readonly IExportStrategy _exportStrategy;
        public DataExporterContext(IExportStrategy exportStrategy)
        {
            _exportStrategy = exportStrategy;
        }
        public void ExportData(string data)
        {
            _exportStrategy.Export(data);
        }
    }

    public class Program
    {
        static void Main()
        {
            string data = "Sample Data";
            IExportStrategy csvStrategy = new CsvExportStrategy();
            DataExporterContext csvExporter = new DataExporterContext(csvStrategy);
            csvExporter.ExportData(data);
            IExportStrategy jsonStrategy = new JsonExportStrategy();
            DataExporterContext jsonExporter = new DataExporterContext(jsonStrategy);
            jsonExporter.ExportData(data);
            IExportStrategy xmlStrategy = new XmlExportStrategy();
            DataExporterContext xmlExporter = new DataExporterContext(xmlStrategy);
            xmlExporter.ExportData(data);
            IExportStrategy pdfStrategy = new PdfExportStrategy();
            DataExporterContext pdfExporter = new DataExporterContext(pdfStrategy);
            pdfExporter.ExportData(data);
        }
    }
}
