using UnityEngine;

namespace DesignPatterns.Structurals.Adapters
{
    public class LoggerClient : MonoBehaviour
    {
        private ILoggerAdapter loggerAdapter = new LoggerAdapter();

        private void Start()
        {
            loggerAdapter.LogMessage("Test");
        }
    }
}
