using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Tool
{
    [SerializeField] private float _throwLifetime = 5;
    [SerializeField] private int _throwForce = 10;
    [SerializeField] private int _throwAngleInDegrees = 30;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;

    public override void UseBy(Player player)
    {
        transform.SetParent(null);

        Vector3 throwDirection = Quaternion.AngleAxis(-_throwAngleInDegrees, player.transform.right) * player.transform.forward;

        _collider.isTrigger = false;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(throwDirection * _throwForce, ForceMode.Impulse);


        Destroy(gameObject, _throwLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ground ground = collision.gameObject.GetComponent<Ground>();

        if (ground != null)
        {
            Destroy(gameObject);
        }
    }
}
