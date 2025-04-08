using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private float _pickUpScale = 0.25f;
    [SerializeField] private ItemAnimator _itemAnimator;

    public bool IsPickedUp { get; private set; }

    private void Awake()
    {
        _itemAnimator.PlayAnimation();
    }

    public void PickUp(Transform parent)
    {
        transform.SetParent(parent);
        transform.SetLocalPositionAndRotation(Vector3.zero, parent.localRotation);
        transform.localScale = new Vector3(_pickUpScale, _pickUpScale, _pickUpScale);

        IsPickedUp = true;
        _itemAnimator.StopAnimation();
    }

    public abstract void UseBy(Transform ownerTransform);
    public abstract bool CanUseBy(Transform ownerTransform);

}
