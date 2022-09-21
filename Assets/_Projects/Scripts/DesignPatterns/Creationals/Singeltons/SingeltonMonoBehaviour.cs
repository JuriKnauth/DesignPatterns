using DesignPatterns.Creationals.Singeltons.Managers;
using UnityEngine;

namespace DesignPatterns.Creationals.Singeltons
{
    public abstract class SingeltonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance;

        protected static readonly Object _lockObject = new();

        public static T Instance => CreateInstance();

        protected static T CreateInstance()
        {
            lock (_lockObject)
            {
                if (ApplicationQuittingManager.IsApplicationQuitting)
                {
                    return null;
                }

                if (_instance != null)
                {
                    return _instance;
                }

                GameObject gO = new();
                T singeltonMonoBehaviour = gO.AddComponent<T>();
                DontDestroyOnLoad(gO);

                _instance = singeltonMonoBehaviour;

#if UNITY_EDITOR
                gO.name = _instance.GetType().Name;
#endif

                return _instance;
            }
        }
    }
}