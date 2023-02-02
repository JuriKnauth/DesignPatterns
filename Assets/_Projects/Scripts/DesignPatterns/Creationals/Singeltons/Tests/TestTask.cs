using DesignPatterns.Creationals.Singeltons.Managers;
using UnityEngine;

namespace DesignPatterns.Creationals.Singeltons.Tests
{
    public class TestTask : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private float time;

        private void OnEnable()
        {
            OnEnableManager.Instance?.AddUpdateTask(new UpdateTask(_index, () => OnEnableTask()));

            DontDestroyOnLoad(gameObject);
        }

        public void UpdateTask()
        {
            Debug.Log($"UpdateTask {_index}");
            time += TimeManager.DeltaTime;
        }

        public void OnEnableTask()
        {
            Debug.Log($"OnEnableTask {_index}");

            UpdateManager.Instance?.AddUpdateTask(new UpdateTask(_index, () => UpdateTask()));
            OnSceneLoadManager.Instance?.AddUpdateTask(new UpdateTask(_index, () => OnSceneLoadTask()));
        }

        public void OnSceneLoadTask()
        {
            Debug.Log($"OnSceneLoadTask {_index}");
        }
    }
}