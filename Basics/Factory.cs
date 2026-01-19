using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface IDocument
    {
        string DocName();
    }

    public class PdfDocument : IDocument
    {
        public string DocName()
        {
            string s = "PDF doc created";
            Console.WriteLine(s);
            return s;
        }
    }

    public class WordDocument : IDocument
    {
        public string DocName()
        {
            string s = "Word doc created";
            Console.WriteLine(s);
            return s;
        }
    }

    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }
    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    //The client should NOT know which concrete class is being created OR how it is created.
    // Client should not see PdfDocument or WordDocument classes
    // Should only see IDocument
    // We can add more document types without changing client code

    public class Program
    {
        static void Main()
        {
            DocumentFactory factory = new PdfDocumentFactory();
            IDocument document = factory.CreateDocument();
            document.DocName();
        }
    }

}
