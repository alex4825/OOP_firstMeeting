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

        do
        {
            SpawnPoint randomPoint = _points[Random.Range(0, _points.Count)];

            if (randomPoint.IsEmpty)
            {
                Tool newTool = Instantiate(randomTool, randomPoint.transform);
                _toolQueue.Enqueue(newTool);
                randomPoint.OccupyWith(newTool);
                break;
            }
        }
        while (_toolQueue.Count < _points.Count);
    }

    private void DestroyFirstCreatedTool()
    {
        while (_toolQueue.Peek().IsPickedUp)
            _toolQueue.Dequeue();

        if (_toolQueue.Count > 0)
            Destroy(_toolQueue.Dequeue().gameObject);
    }
}
