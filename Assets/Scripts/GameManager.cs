using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PointsSpawner _pointsSpawner;
    [SerializeField] private ItemsSpawner _itemsSpawner;

    private List<SpawnPoint> _points;

    private void Awake()
    {
        _points = _pointsSpawner.InstantiatePoints();
        _itemsSpawner.BeginSpawnIn(_points);
    }
}
