using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public int Value {  get; private set; }

    public Health(int value)
    {
        Value = value;
    }

    public void Add(int value)
    {
        Value += value;
    }
}
