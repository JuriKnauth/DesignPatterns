using System;

namespace DesignPatterns.Creationals.Singeltons.Managers
{
    public class UpdateTask
    {
        public int Index { get; set; }
        public Action Task { get; set; }

        public UpdateTask(int index, Action task)
        {
            Index = index;
            Task = task;
        }
    }
}