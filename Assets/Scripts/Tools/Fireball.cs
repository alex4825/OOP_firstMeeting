using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Tool
{
    [SerializeField] private float _throwLifetime = 5;
    [SerializeField] private int _throwForce = 10;
    [SerializeField] private int _throwAngleInDegrees = 30;
    [SerializeField] private Rigidbody _rigidbody;

    private void Update()
    {
        
    }

    public override void Use()
    {
        Vector3 throwDirection = Quaternion.AngleAxis(-_throwAngleInDegrees, transform.right) * transform.forward;

        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(throwDirection * _throwForce, ForceMode.Impulse);

        transform.SetParent(null);

        Destroy(gameObject, _throwLifetime);
    }
}
