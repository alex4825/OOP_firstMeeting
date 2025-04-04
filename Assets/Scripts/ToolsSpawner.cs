using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsSpawner : MonoBehaviour
{
    [SerializeField] private List<Tool> _toolPrefabs;
    [SerializeField] private float _timeToSpawn = 5;
    [SerializeField] private float _timeToDestroy = 8;

    private bool _isSpawnBegin;
    private float _timeToSpawnPassed = 0;
    private float _timeToDestroyPassed = 0;
    private Queue<Tool> _toolQueue;
    private List<SpawnPoint> _points;

    private void Awake()
    {
        _toolQueue = new Queue<Tool>();
    }

    private void Update()
    {
        if (_isSpawnBegin)
        {
            _timeToSpawnPassed += Time.deltaTime;

            if (_timeToSpawnPassed >= _timeToSpawn)
            {
                SpawnTool();
                _timeToSpawnPassed = 0;
            }

            _timeToDestroyPassed += Time.deltaTime;

            if (_timeToDestroyPassed >= _timeToDestroy)
            {
                DestroyFirstCreatedTool();
                _timeToDestroyPassed = 0;
            }
        }
    }

    public void BeginSpawnIn(List<SpawnPoint> points)
    {
        _isSpawnBegin = true;
        _points = points;
    }

    private void SpawnTool()
    {
        Tool randomTool = _toolPrefabs[Random.Range(0, _toolPrefabs.Count)];

        List<SpawnPoint> emptyPoints = GetEmptyPointsFrom(_points);

        if (emptyPoints.Count == 0)
            return;

        SpawnPoint randomPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

        Tool newTool = Instantiate(randomTool, randomPoint.transform);
        _toolQueue.Enqueue(newTool);
        randomPoint.OccupyWith(newTool);
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

    private void DestroyFirstCreatedTool()
    {
        while (_toolQueue.Peek().IsPickedUp)
            _toolQueue.Dequeue();

        if (_toolQueue.Count > 0)
            Destroy(_toolQueue.Dequeue().gameObject);
    }
}
