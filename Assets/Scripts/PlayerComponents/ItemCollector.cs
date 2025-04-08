using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _hand;
    public Item CurrentItem { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CurrentItem != null && CurrentItem.CanUseBy(transform))
            {
                CurrentItem.UseBy(transform);
                CurrentItem = null;
            }
            else
            {
                Debug.LogWarning("” игрока нет инструмента дл€ использовани€.");
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Item collidedItem = other.GetComponent<Item>();

        if (collidedItem == null)
            return;

        if (CurrentItem == null && collidedItem.IsPickedUp == false)
        {
            collidedItem.PickUp(_hand);
            CurrentItem = collidedItem;
        }
    }
}
