using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _toolLocation;
    [SerializeField] private int _healthValue = 100;

    public Health Health { get; private set; }
    public Tool CurrentTool { get; private set; }

    private void Awake()
    {
        Health = new(_healthValue);
    }

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
                CurrentTool.Use();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Tool collidedTool = other.GetComponent<Tool>();

        if (collidedTool == null)
            return;

        if (CurrentTool == null || collidedTool.IsPickedUp == false)
        {
            collidedTool.PickUp(_toolLocation);
            CurrentTool = collidedTool;
        }
    }
}
