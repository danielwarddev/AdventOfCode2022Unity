using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private float _visualizerInterval = 0.1f;
    public float VisualizerInterval { get => _visualizerInterval; }

    private void Awake()
    {
        var challenge = new AdventChallenge8b();
        var result = challenge.PerformChallenge();
    }
}