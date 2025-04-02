using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Tool _tool;
    public bool IsEmpty => _tool == null || _tool.gameObject == null;

    public void OccupyWith(Tool tool)
    {
        _tool = tool;
    }
}
