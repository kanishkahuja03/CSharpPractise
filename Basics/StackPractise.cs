using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackPractise
{
    class EditorAction
    {
        public string? Text { get; set; }
        public int CursorPosition { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"Text: '{Text}', Cursor: {CursorPosition}, Time: {Timestamp:T}";
        }
    }

    class UndoRedoManager
    {
        private Stack<EditorAction> undoStack = new Stack<EditorAction>();
        private Stack<EditorAction> redoStack = new Stack<EditorAction>();

        // Perform a new action
        public void PerformAction(EditorAction action)
        {
            undoStack.Push(action);     // Push to undo
            redoStack.Clear();          // Clear redo history

            Console.WriteLine("Action performed:");
            Console.WriteLine(action);
        }

        // Undo last action
        public void Undo()
        {
            if (undoStack.Count == 0)
            {
                Console.WriteLine("Nothing to undo.");
                return;
            }

            EditorAction action = undoStack.Pop();
            redoStack.Push(action);

            Console.WriteLine("Undo:");
            Console.WriteLine(action);
        }

        // Redo last undone action
        public void Redo()
        {
            if (redoStack.Count == 0)
            {
                Console.WriteLine("Nothing to redo.");
                return;
            }

            EditorAction action = redoStack.Pop();
            undoStack.Push(action);

            Console.WriteLine("Redo:");
            Console.WriteLine(action);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UndoRedoManager manager = new UndoRedoManager();

            manager.PerformAction(new EditorAction
            {
                Text = "Hello",
                CursorPosition = 5,
                Timestamp = DateTime.Now
            });

            manager.PerformAction(new EditorAction
            {
                Text = " World",
                CursorPosition = 11,
                Timestamp = DateTime.Now
            });

            manager.Undo();
            manager.Undo();
            manager.Undo();   // invalid undo

            manager.Redo();
            manager.Redo();
            manager.Redo();   // invalid redo
        }
    }
}