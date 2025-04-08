using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Item
{
    [SerializeField] private int _speedCoint = 3;

    public override bool CanUseBy(Transform ownerTransform)
        => ownerTransform.GetComponent<Speed>() != null;

    public override void UseBy(Transform ownerTransform)
    {
        Speed objectSpeed = ownerTransform.GetComponent<Speed>();

        objectSpeed.Add(_speedCoint);

        Debug.Log($"Ускоритель применен. Скорость игрока: {objectSpeed.Value}");

        Destroy(gameObject);
    }
}
