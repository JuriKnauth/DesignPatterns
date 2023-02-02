using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Behavioral.Commands.LoadingSliders
{
    [BurstCompile]
    public readonly struct LoadingCommand
    {
        private readonly LoadingStep[] _loadingSteps;

        public LoadingStep[] LoadingSteps => _loadingSteps;

        public LoadingCommand(LoadingStep[] loadingSteps)
        {
            _loadingSteps = loadingSteps;
        }
    }

    [BurstCompile]
    public readonly struct LoadingStep
    {
        private readonly string _name;
        private readonly float _duration;
        private readonly Action _action;
        private readonly Func<bool> _condition;

        public string Name => _name;
        public float Duration => _duration;
        public Action Action => _action;
        public Func<bool> Condition => _condition;

        public LoadingStep(string name, float duration, Action action = null, Func<bool> condition = null)
        {
            _name = name;
            _duration = duration;
            _action = action;
            _condition = condition;
        }
    }

    public class LoadingSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _name;

        private GameObject _gameObject;

        private Stack<LoadingCommand> _loadingCommands = new Stack<LoadingCommand>();

        private Coroutine _coroutine;

        private bool _loading;

        private void Awake()
        {
            _gameObject = _slider.gameObject;

            _gameObject.SetActive(false);
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            Push(new LoadingCommand(new LoadingStep[] { new LoadingStep("First Step", 2f, () => Debug.Log("First Finished"))}));
            Push(new LoadingCommand(new LoadingStep[] { new LoadingStep("Second Step", 2f, () => Debug.Log("Second Finished")), new LoadingStep("Third Step", 2f, () => Debug.Log("Third Finished"))}));

            yield return new WaitForSeconds(10f);

            Push(new LoadingCommand(new LoadingStep[] { new LoadingStep("Fourth Step", 2f, () => Debug.Log("Fourth Finished"))}));

            yield return new WaitForSeconds(4f);

            Push(new LoadingCommand(new LoadingStep[] { new LoadingStep("Fifth Step", 2f, () => Debug.Log("Fifth Finished"), () => Time.time >= 20f)}));
        }

        public void Push(LoadingCommand loadingCommand)
        {
            _loadingCommands.Push(loadingCommand);

            if (_loading)
            {
                return;
            }

            _loading = true;

            _coroutine = StartCoroutine(LoadingCoroutine());
        }

        public IEnumerator LoadingCoroutine()
        {
            _gameObject.SetActive(true);

            while (_loadingCommands.Count > 0)
            {
                LoadingCommand loadingCommand = _loadingCommands.Pop();

                if (loadingCommand.LoadingSteps == null)
                {
                    yield break;
                }

                int loadingCommandLoadingStepsLength = loadingCommand.LoadingSteps.Length;

                if (loadingCommandLoadingStepsLength == 0)
                {
                    yield break;
                }

                float startTime = Time.time;
                float totalDuration = loadingCommand.LoadingSteps.Select(x => x.Duration).Sum();

                float duration = 0f;

                for (int i = 0; i < loadingCommandLoadingStepsLength; i++)
                {
                    LoadingStep loadingStep = loadingCommand.LoadingSteps[i];

                    string name = loadingStep.Name;

                    _name.text = name;

                    Debug.Log($"Loading started {name} {i}");

                    duration += loadingStep.Duration;

                    Func<bool> condition = loadingStep.Condition;

                    while (true)
                    {
                        float time = Time.time - startTime;

                        _slider.value = time / totalDuration;

                        if (condition != null && condition.Invoke())
                        {
                            break;
                        }

                        if (time >= duration)
                        {
                            if (condition == null)
                            {
                                break;
                            }
                            else
                            {
                                startTime = Time.time;
                            }
                        }

                        yield return null;
                    }

                    Debug.Log($"Loading finished {name} {i}");

                    loadingStep.Action?.Invoke();

                    yield return null;
                }
            }

            _gameObject.SetActive(false);

            _loading = false;
        }

        private void OnDisable()
        {
            if (_coroutine == null)
            {
                return;
            }

            StopCoroutine(_coroutine);
        }
    }
}

public class Kata
{
    public static string AlphabetWar(string fight)
    {
        (char, int)[] left = new[] { ('w', 4), ('p', 3), ('b', 2), ('s', 1) };
        (char, int)[] right = new[] { ('m', 4), ('q', 3), ('d', 2), ('z', 1) };
        char[] leftLetters = left.Select(x => x.Item1).ToArray();
        char[] rightLetters = right.Select(x => x.Item1).ToArray();
        int leftPower = fight.Where(x => leftLetters.Contains(x)).Select(y => left[Array.IndexOf(leftLetters, y)].Item2).Sum();
        int rightPower = fight.Where(x => rightLetters.Contains(x)).Select(y => right[Array.IndexOf(rightLetters, y)].Item2).Sum();

        if (leftPower > rightPower)
        {
            return "Left side wins!";
        }
        else if (leftPower < rightPower)
        {
            return "Right side wins!";
        }

        return "Let's fight again!";
    }
}
