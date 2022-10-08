using UnityEngine;

namespace DesignPatterns.Structurals.Adapters
{
    public class LoggerClient : MonoBehaviour
    {
        private readonly ILoggerAdapter loggerAdapter = new LoggerAdapter();

        private void Start()
        {
            loggerAdapter.LogMessage("Test");
        }
    }
}