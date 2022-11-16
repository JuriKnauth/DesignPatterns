using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DesignPatterns
{
    public class Tests : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(int.MinValue);
            Debug.Log($"-1, {(-1).TryParseNumber(out Number number0)} {number0}");
            Debug.Log($"0, {0.TryParseNumber(out Number number1)} {number1}");
            Debug.Log($"1, {1.TryParseNumber(out Number number2)} {number2}");
            Debug.Log($"2, {2.TryParseNumber(out Number number3)} {number3}");
            Debug.Log($"3, {3.TryParseNumber(out Number number4)} {number4}");
            Debug.Log($"4, {4.TryParseNumber(out Number number5)} {number5}");
            Debug.Log($"5, {5.TryParseNumber(out Number number6)} {number6}");
        }
    }

    public enum Number
    {
        One = 1,
        Three = 3,
        Four = 4
    }

    public static class NumberExtensions
    {
        public static bool TryParseNumber(this int integer, out Number number)
        {
            number = (Number)integer;
            return Enum.IsDefined(typeof(Number), number);
        }
    }
}
