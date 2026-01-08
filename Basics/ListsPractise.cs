using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsPractise
{
    enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
    class DevTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Priority Priority { get; set; }
        public int EstimatedHours { get; set; }
        public string Requirements { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, Title:{Title}, Priority:{Priority}, Hours:{EstimatedHours}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Collection that maintains order and index access
            List<DevTask> tasks = new List<DevTask>();

            // Add new tasks
            tasks.Add(new DevTask { Id = 1, Title = "Fix Bug", Priority = Priority.High, EstimatedHours = 3, Requirements = "Debug skills" });
            tasks.Add(new DevTask { Id = 2, Title = "Write API", Priority = Priority.Medium, EstimatedHours = 6, Requirements = "REST knowledge" });
            tasks.Add(new DevTask { Id = 3, Title = "UI Design", Priority = Priority.Low, EstimatedHours = 4, Requirements = "C++" });

            // Insert urgent task at specific index
            tasks.Insert(1, new DevTask
            {
                Id = 4,
                Title = "Production",
                Priority = Priority.High,
                EstimatedHours = 2,
                Requirements = "Critical"
            });

            Console.WriteLine("All Tasks after Insertion:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }

            // Remove completed task by Id
            tasks.RemoveAll(t => t.Id == 2);

            // Sort by Priority then EstimatedHours
            tasks = tasks
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.EstimatedHours)
                .ToList();

            Console.WriteLine("Sorted Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }

            // Get next task by index
            int index = 0;
            DevTask nextTask = tasks[index];
            Console.WriteLine("Next Task:");
            Console.WriteLine(nextTask);

            // Update task at given index
            tasks[index] = new DevTask
            {
                Id = nextTask.Id,
                Title = "Updated Hotfix Task",
                Priority = Priority.High,
                EstimatedHours = 1,
                Requirements = "Immediate attention"
            };

            Console.WriteLine("After Updating Task:");
            Console.WriteLine(tasks[index]);
            Console.WriteLine(tasks[index].Requirements);
        }
    }
}