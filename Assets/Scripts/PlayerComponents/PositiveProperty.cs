using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PositiveProperty : MonoBehaviour
{
    [SerializeField] private int _initialValue;

    public float Value { get; private set; }

    public void Awake()
    {
        Value = _initialValue;

        if (_initialValue < 0)
            Value = 0;
    }

    public void Add(float value)
    {
        Value += value;

        if (value < 0)
            Value = 0;
    }
}
