using System;
using UnityEngine;

namespace DesignPatterns
{
    public static class ApplicationManager
    {
        [RuntimeInitializeOnLoadMethod]
        private static void Initialization()
        {
            Debug.Log($"{Application.productName}, {Application.version}, {DateTime.Now}");
        }
    }
}