using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mover : MonoBehaviour
{
    [SerializeField] private Speed _speed;

    private const string NameAxisX = "Horizontal";
    private const string NameAxisZ = "Vertical";

    public Vector3 MoveDirection { get; private set; }

    private void Update()
    {
        SetMoveDirection();

        ProcessMovement();
    }

    private void ProcessMovement()
    {
        transform.Translate(MoveDirection * _speed.Value * Time.deltaTime, Space.World);
    }

    private void SetMoveDirection()
    {
        float verticalInput = Input.GetAxisRaw(NameAxisZ);
        float horizontalInput = Input.GetAxisRaw(NameAxisX);

        MoveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
    }
}
