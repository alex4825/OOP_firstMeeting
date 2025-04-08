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

        Debug.Log($"������� ���������. �������� ������: {objectHealth.Value}");

        Destroy(gameObject);
    }


}
