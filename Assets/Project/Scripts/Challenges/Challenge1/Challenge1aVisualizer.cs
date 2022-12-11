using DG.Tweening;
using System;
using UnityEngine;

public class Challenge1aVisualizer : MonoBehaviour
{
    [SerializeField] private BasicSpawner _spawner;
    private AdventChallenge1a _challenge = new AdventChallenge1a();
    private StopwatchQueue<int> _queue;
    private float _scaleNormalizer = 3000;
    private float _interval => GameManager.Instance.VisualizerInterval;

    private void Awake()
    {
        _queue = new StopwatchQueue<int>(_interval * 1000);

        _challenge.NewCalorieValueReceived += NewCalorieValueReceived;
        _challenge.ElfTotalCaloriesUpdated += ElfCaloriesUpdated;
        _challenge.ElfCaloriesCompleted += ElfCaloriesCompleted;

        StartVisualization();
    }

    public void StartVisualization()
    {
        _challenge.PerformChallenge();
        _queue.StartTimer();
    }

    private void Update()
    {
        if (_challenge.IsComplete && _queue.IsEmpty)
        {
            return;
        }

        var success = _queue.TryDequeueAndRestartTimer(out int value);
        if (success)
        {
            VisualizeValue(value);
        }
    }

    private void VisualizeValue(int value)
    {
        var apple = _spawner.Get();
        apple.transform.position = new Vector3(11, 3, 0);

        var scale = value / _scaleNormalizer;
        apple.transform.localScale = new Vector3(scale, scale, scale);

        DOTween.Sequence()
            .Append(apple.transform.DOMove(new Vector3(0, 3, 0), _interval * 10))
            .Append(apple.transform.DOMove(new Vector3(-11, 3, 0), _interval * 10))
            .OnComplete(() => _spawner.Release(apple))
            .Play();
    }

    private void NewCalorieValueReceived(object sender, int value)
    {
        _queue.Enqueue(value);
    }

    private void ElfCaloriesUpdated(object sender, int value)
    {
        //throw new NotImplementedException();
    }

    private void ElfCaloriesCompleted(object sender, int value)
    {
        //throw new NotImplementedException();
    }
}