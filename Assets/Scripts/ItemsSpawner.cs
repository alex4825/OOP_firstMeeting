using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _itemPrefabs;
    [SerializeField] private float _timeToSpawn = 5;
    [SerializeField] private float _timeToDestroy = 8;

    private bool _isSpawnBegin;
    private float _timeToSpawnPassed = 0;
    private float _timeToDestroyPassed = 0;
    private Queue<Item> _itemQueue;
    private List<SpawnPoint> _points;

    private void Awake()
    {
        _itemQueue = new Queue<Item>();
    }

    private void Update()
    {
        if (_isSpawnBegin)
        {
            _timeToSpawnPassed += Time.deltaTime;

            if (_timeToSpawnPassed >= _timeToSpawn)
            {
                SpawnItem();
                _timeToSpawnPassed = 0;
            }

            _timeToDestroyPassed += Time.deltaTime;

            if (_timeToDestroyPassed >= _timeToDestroy)
            {
                DestroyFirstCreatedItem();
                _timeToDestroyPassed = 0;
            }
        }
    }

    public void BeginSpawnIn(List<SpawnPoint> points)
    {
        _isSpawnBegin = true;
        _points = points;
    }

    private void SpawnItem()
    {
        Item randomItem = _itemPrefabs[Random.Range(0, _itemPrefabs.Count)];

        List<SpawnPoint> emptyPoints = GetEmptyPointsFrom(_points);

        if (emptyPoints.Count == 0)
            return;

        SpawnPoint randomPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

        Item newItem = Instantiate(randomItem, randomPoint.transform);
        _itemQueue.Enqueue(newItem);
        randomPoint.OccupyWith(newItem);
    }

    private List<SpawnPoint> GetEmptyPointsFrom(List<SpawnPoint> points)
    {
        List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

        foreach (SpawnPoint point in points)
        {
            if (point.IsEmpty)
                emptyPoints.Add(point);
        }

        return emptyPoints;
    }

    private void DestroyFirstCreatedItem()
    {
        while (_itemQueue.Peek().IsPickedUp)
            _itemQueue.Dequeue();

        if (_itemQueue.Count > 0)
            Destroy(_itemQueue.Dequeue().gameObject);
    }
}
