using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Item _item;
    public bool IsEmpty => _item == null || _item.gameObject == null;

    public void OccupyWith(Item Item)
    {
        _item = Item;
    }
}
