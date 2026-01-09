using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePractise
{
    public class PrintJob
    {
        public int JobId { get; }
        public string DocumentName { get; }
        public int PageCount { get; }
        public DateTime SubmittedTime { get; }

        public PrintJob(int jobId, string documentName, int pageCount)
        {
            JobId = jobId;
            DocumentName = documentName;
            PageCount = pageCount;
            SubmittedTime = DateTime.Now;
        }
    }

    public class PrinterScheduler
    {
        private readonly Queue<PrintJob> _queue = new Queue<PrintJob>();

        public void EnqueueJob(PrintJob job)
        {
            _queue.Enqueue(job);
            Console.WriteLine($"[ENQUEUED] Job {job.JobId} - {job.DocumentName}");
        }

        public PrintJob DequeueJob()
        {
            if (_queue.Count == 0)
                return null;

            return _queue.Dequeue();
        }

        public PrintJob PeekNextJob()
        {
            if (_queue.Count == 0)
                return null;

            return _queue.Peek();
        }

        public void ProcessJobs()
        {

            while (_queue.Count > 0)
            {
                PrintJob job = _queue.Dequeue();

                Console.WriteLine($"[START] Printing Job {job.JobId} ({job.DocumentName}, {job.PageCount} pages)");

                // Simulate printing time (1 sec per page)
                Thread.Sleep(job.PageCount * 1000);

                Console.WriteLine($"[DONE] Completed Job {job.JobId} at {DateTime.Now}");
            }

            Console.WriteLine("[IDLE] Printer is idle (no jobs in queue)");
        }
    }

    class Program
    {
        static void Main()
        {
            var scheduler = new PrinterScheduler();

            scheduler.EnqueueJob(new PrintJob(1, "Invoice.pdf", 2));
            scheduler.EnqueueJob(new PrintJob(2, "Report.docx", 5));
            scheduler.EnqueueJob(new PrintJob(3, "Presentation.pptx", 3));

            Console.WriteLine($"Next job: {scheduler.PeekNextJob().DocumentName}");

            scheduler.ProcessJobs();
        }
    }
}