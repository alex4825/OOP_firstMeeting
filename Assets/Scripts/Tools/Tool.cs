using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public abstract class Tool : MonoBehaviour
{
    [SerializeField] private float _pickUpScale = 0.25f;
    [SerializeField] private ToolAnimator _toolAnimator;

    public bool IsPickedUp { get; protected set; }

    private void Awake()
    {
        _toolAnimator.PlayAnimation();
    }

    public void PickUp(Transform parent)
    {
        transform.SetParent(parent);
        transform.SetLocalPositionAndRotation(Vector3.zero, parent.localRotation);
        transform.localScale = new Vector3(_pickUpScale, _pickUpScale, _pickUpScale);

        IsPickedUp = true;
        _toolAnimator.StopAnimation();
    }

    public abstract void UseBy(Player player);

}
