using UnityEngine;

namespace DesignPatterns.Creationals.Singeltons.Managers
{
    public class UpdateManager : SingeltonMonoBehaviour<UpdateManager>, ITaskManager
    {
        private static readonly TaskManager _taskManager = new();

        [RuntimeInitializeOnLoadMethod]
        private static void RuntimeInitializeOnLoadMethodAttribute()
        {
            _ = CreateInstance();
        }

        public void OrderTasks()
        {
            _taskManager.OrderTasks();
        }

        public void InvokeTasks()
        {
            _taskManager.InvokeTasks();
        }

        public void AddUpdateTask(UpdateTask updateTask)
        {
            _taskManager.AddUpdateTask(updateTask);
        }

        public void RemoveUpdateTask(UpdateTask updateTask)
        {
            _taskManager.AddUpdateTask(updateTask);
        }

        private void Update()
        {
            OrderTasks();

            InvokeTasks();
        }
    }
}