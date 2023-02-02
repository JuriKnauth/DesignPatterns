using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Creationals.Commands
{
    public interface IExecutable
    {
        void Execute();
    }

    public class CommandManager : MonoBehaviour
    {
        private static Queue<IExecutable> _executables = new Queue<IExecutable>();

        private void Update()
        {
            Queue<IExecutable>.Enumerator enumerator = _executables.GetEnumerator();

            while (_executables.Count > 0)
            {
                _executables.Dequeue()?.Execute();
            }
        }

        public static void Enqueue(IExecutable executable)
        {
            _executables.Enqueue(executable);
        }

        private void Start()
        {
            Enqueue(new ConsoleWriteLineCommand("Hello"));
            Enqueue(new ToStringCommand(this));
            Enqueue(new Command(() => Debug.Log(name)));
        }
    }

    public class ConsoleWriteLineCommand : IExecutable
    {
        private string _message;

        public ConsoleWriteLineCommand(string message)
        {
            _message = message;
        }

        public void Execute()
        {
            Debug.Log(_message);
        }
    }

    public class ToStringCommand : IExecutable
    {
        private object _object;

        public ToStringCommand(object argumentObject)
        {
            _object = argumentObject;
        }

        public void Execute()
        {
            Debug.Log(_object.ToString());
        }
    }

    public class Command : IExecutable
    {
        private Action _action;

        public Command(Action action)
        {
            _action = action;
        }

        public void Execute()
        {
            _action?.Invoke();
        }
    }
}
