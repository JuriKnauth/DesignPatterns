using UnityEngine;

namespace DesignPatterns.Creationals.Singeltons.Managers
{
    public class TimeManager : SingeltonMonoBehaviour<TimeManager>
    {
        [RuntimeInitializeOnLoadMethod]
        private static void RuntimeInitializeOnLoadMethodAttribute()
        {
            _ = CreateInstance();
        }

        public static float DeltaTime { get; private set; }
        public static float TimeTime => Time.time;
        public static float TimeSinceLevelLoad => Time.timeSinceLevelLoad;

        private void OnEnable()
        {
            OnEnableManager.Instance?.AddUpdateTask(new UpdateTask(0, OnEnableTask));
        }

        private void OnEnableTask()
        {
            UpdateManager.Instance?.AddUpdateTask(new UpdateTask(0, DoUpdate));
        }

        public static void DoUpdate()
        {
            DeltaTime = Time.deltaTime;
        }
    }
}