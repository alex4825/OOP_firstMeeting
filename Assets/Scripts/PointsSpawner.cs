using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnPointPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private int _spawnPointsCountX = 5;
    [SerializeField] private int _spawnPointsCountZ = 5;
    [SerializeField] private int _spacing = 5;

    public List<SpawnPoint> InstantiatePoints()
    {
        List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        float halfCountX = _spawnPointsCountX % 2 == 0 ? _spawnPointsCountX / 2f - 0.5f : _spawnPointsCountX / 2;
        float halfCountZ = _spawnPointsCountZ % 2 == 0 ? _spawnPointsCountZ / 2f - 0.5f : _spawnPointsCountZ / 2;

        for (float x = -halfCountX; x <= halfCountX; x++)
            for (float z = -halfCountZ; z <= halfCountZ; z++)
            {
                Vector3 position = new(x * _spacing, 0, z * _spacing);

                SpawnPoint point = Instantiate(_spawnPointPrefab, _container);
                point.transform.localPosition = position;
                spawnPoints.Add(point);
            }

        return spawnPoints;
    }
}
