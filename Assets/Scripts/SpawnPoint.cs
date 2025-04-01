using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsEmpty { get; private set; } = true;

    public void Occupy()
    {
        IsEmpty = false;
    }

    public void Release()
    {
        IsEmpty = true;
    }
}
