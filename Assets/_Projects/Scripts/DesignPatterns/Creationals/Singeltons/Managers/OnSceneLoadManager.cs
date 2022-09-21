using UnityEngine;
using UnityEngine.SceneManagement;

namespace DesignPatterns.Creationals.Singeltons.Managers
{
    public static class ExtendedSceneManager
    {
        public static bool IsValidSceneIndex(int sceneIndex)
        {
            return sceneIndex < SceneManager.sceneCountInBuildSettings;
        }

        public static void LoadScene(int sceneIndex)
        {
            if (!IsValidSceneIndex(sceneIndex))
            {
                return;
            }

            SceneManager.LoadScene(sceneIndex);
        }

        public static void ReloadScene()
        {
            if (!IsValidSceneIndex(SceneManager.GetActiveScene().buildIndex))
            {
                return;
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public class OnSceneLoadManager : SingeltonMonoBehaviour<OnSceneLoadManager>, ITaskManager
    {
        private static readonly TaskManager _taskManager = new();

        [RuntimeInitializeOnLoadMethod]
        private static void RuntimeInitializeOnLoadMethodAttribute()
        {
            _ = CreateInstance();
        }

        public OnSceneLoadManager()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            OrderTasks();

            InvokeTasks();
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
            if (Input.GetKey(KeyCode.F1))
            {
                ExtendedSceneManager.ReloadScene();
            }
        }
    }
}