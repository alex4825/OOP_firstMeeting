using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : Item
{
    [SerializeField] private int _healthCount = 10;

    public override bool CanUseBy(Transform ownerTransform)
        => ownerTransform.GetComponent<Health>() != null;


    public override void UseBy(Transform ownerTransform)
    {
        Health objectHealth = ownerTransform.GetComponent<Health>();

        objectHealth.Add(_healthCount);

        Debug.Log($"Аптечка применена. Здоровье игрока: {objectHealth.Value}");

        Destroy(gameObject);
    }


}
