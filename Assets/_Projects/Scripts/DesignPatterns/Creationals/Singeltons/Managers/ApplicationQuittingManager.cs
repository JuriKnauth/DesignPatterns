using UnityEngine;

namespace DesignPatterns.Creationals.Singeltons.Managers
{
    public class ApplicationQuittingManager : SingeltonMonoBehaviour<ApplicationQuittingManager>
    {
        public static bool IsApplicationQuitting { get; private set; }

        [RuntimeInitializeOnLoadMethod]
        private static void RuntimeInitializeOnLoadMethodAttribute()
        {
            _ = CreateInstance();
        }

        private void OnApplicationQuit()
        {
            IsApplicationQuitting = true;
        }
    }
}