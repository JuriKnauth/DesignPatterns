using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Creationals.Singeltons.Managers
{
    public class TaskManager : ITaskManager
    {
        public List<UpdateTask> _newTasks = new();

        public Dictionary<int, Action> OrderedTasks { get; set; } = new Dictionary<int, Action>();

        public virtual void InvokeTasks()
        {
            if (OrderedTasks == null || OrderedTasks.Count == 0)
            {
                return;
            }

            foreach (int key in OrderedTasks.Keys)
            {
                OrderedTasks[key]?.Invoke();
            }
        }

        public virtual void OrderTasks()
        {
            if (_newTasks == null || _newTasks.Count == 0)
            {
                return;
            }

            foreach (UpdateTask updateTask in _newTasks)
            {
                AddTask(updateTask);
            }

            OrderedTasks = OrderedTasks.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            _newTasks = new List<UpdateTask>();
        }

        protected void AddTask(UpdateTask updateTask)
        {
            if (OrderedTasks.ContainsKey(updateTask.Index))
            {
                OrderedTasks[updateTask.Index] += updateTask.Task;
            }
            else
            {
                OrderedTasks.Add(updateTask.Index, updateTask.Task);
            }
        }

        protected void RemoveTask(UpdateTask updateTask)
        {
            if (OrderedTasks.ContainsKey(updateTask.Index))
            {
                OrderedTasks[updateTask.Index] -= updateTask.Task;

                if (OrderedTasks[updateTask.Index].GetInvocationList().Length == 0)
                {
                    _ = OrderedTasks.Remove(updateTask.Index);
                }
            }
        }

        public virtual void AddUpdateTask(int index, Action action)
        {
            AddUpdateTask(index, action);
        }

        public virtual void AddUpdateTask(UpdateTask updateTask)
        {
            _newTasks.Add(updateTask);
        }

        public virtual void RemoveUpdateTask(UpdateTask updateTask)
        {
            _ = _newTasks.Remove(updateTask);

            RemoveTask(updateTask);
        }
    }
}