﻿using UnityEngine;

namespace DesignPatterns.Structurals.Adapters
{
    public class LoggerAdapter : ILoggerAdapter
    {
        public void LogMessage(string message)
        {
            Debug.Log(message);
        }
    }
}