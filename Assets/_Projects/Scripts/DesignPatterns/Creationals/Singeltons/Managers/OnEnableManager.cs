using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Creationals.Singeltons.Managers
{
    public class OnEnableManager : SingeltonMonoBehaviour<OnEnableManager>, ITaskManager
    {
        private static readonly TaskManager _taskManager = new();

        private static Coroutine _onEnableCoroutine;

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

            _taskManager.OrderedTasks = new Dictionary<int, Action>();
        }

        public void AddUpdateTask(UpdateTask updateTask)
        {
            _taskManager.AddUpdateTask(updateTask);

            StartOnEnableCoroutine();
        }

        public void RemoveUpdateTask(UpdateTask updateTask)
        {
            _taskManager.RemoveUpdateTask(updateTask);
        }

        private void StartOnEnableCoroutine()
        {
            StopOnEnableCoroutine();

            _onEnableCoroutine = Instance?.StartCoroutine(OnEnableCoroutine());
        }

        private void StopOnEnableCoroutine()
        {
            if (_onEnableCoroutine == null)
            {
                return;
            }

            Instance?.StopCoroutine(OnEnableCoroutine());
        }

        private IEnumerator OnEnableCoroutine()
        {
            yield return null;

            OrderTasks();

            InvokeTasks();
        }

        private void OnDisable()
        {
            StopOnEnableCoroutine();
        }
    }
}