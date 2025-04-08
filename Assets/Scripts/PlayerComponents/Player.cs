using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Health _health;
    [SerializeField] private Speed _speed;

    public Mover Mover => _mover;
    public Health Health => _health;
    public Speed Speed => _speed;
}
