using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isMoving;

    public bool IsMovementAllowed { get; set; } = true;

    private void Awake()
    {
        _isMoving = false;
    }

    private void Update()
    {
        if (IsMovementAllowed)
        {

        }
        else
        {
            _isMoving = false;
        }

    }
}
