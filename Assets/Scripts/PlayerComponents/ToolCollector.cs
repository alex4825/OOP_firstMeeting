using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _hand;
    public Tool CurrentTool { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CurrentTool == null)
            {
                Debug.LogWarning("” игрока нет инструмента дл€ использовани€.");
                return;
            }
            else
            {
                CurrentTool.UseBy(_player);
                CurrentTool = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Tool collidedTool = other.GetComponent<Tool>();

        if (collidedTool == null)
            return;

        if (CurrentTool == null && collidedTool.IsPickedUp == false)
        {
            collidedTool.PickUp(_hand);
            CurrentTool = collidedTool;
        }
    }
}
