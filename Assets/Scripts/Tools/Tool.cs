using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public abstract class Tool : MonoBehaviour
{
    [SerializeField] protected ParticleSystem ParticlesOnUse;


    public bool IsPickedUp { get; protected set; }

    public void PickUp(Transform parent)
    {
        transform.SetParent(parent);
        transform.SetLocalPositionAndRotation(Vector3.zero, parent.localRotation);

        IsPickedUp = true;
    }

    public abstract void Use();

}
