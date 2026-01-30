using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class TextEditor
    {
        private string _text = "";

        public void Insert(string text)
        {
            _text += text;
            Console.WriteLine($"Text after insert: {_text}");
        }

        public void Delete(int length)
        {
            if (length <= 0 || length > _text.Length)
                return;

            _text = _text.Substring(0, _text.Length - length);
            Console.WriteLine($"Text after undo: {_text}");
        }
    }

    public class InsertTextCommand : ICommand
    {
        private readonly TextEditor _editor;
        private readonly string _text;

        public InsertTextCommand(TextEditor editor, string text)
        {
            _editor = editor;
            _text = text;
        }

        public void Execute()
        {
            _editor.Insert(_text);
        }

        public void Undo()
        {
            _editor.Delete(_text.Length);
        }
    }

    public class EditorInvoker
    {
        private readonly Stack<ICommand> _history = new();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public void Undo()
        {
            if (_history.Count == 0)
                return;

            ICommand command = _history.Pop();
            command.Undo();
        }
    }

    class Program
    {
        static void Main()
        {
            TextEditor editor = new TextEditor();
            EditorInvoker invoker = new EditorInvoker();

            ICommand insertHello = new InsertTextCommand(editor, "Hello ");
            ICommand insertWorld = new InsertTextCommand(editor, "World!");

            invoker.ExecuteCommand(insertHello);
            invoker.ExecuteCommand(insertWorld);

            Console.WriteLine("Undo last command:");
            invoker.Undo();

            Console.WriteLine("Undo again:");
            invoker.Undo();
        }
    }
}
