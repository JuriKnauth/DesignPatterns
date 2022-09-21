namespace DesignPatterns.Creationals.Singeltons.Managers
{
    public interface ITaskManager
    {
        void OrderTasks();

        void InvokeTasks();

        void AddUpdateTask(UpdateTask updateTask);

        void RemoveUpdateTask(UpdateTask updateTask);
    }
}