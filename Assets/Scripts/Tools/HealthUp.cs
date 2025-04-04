using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : Tool
{
    [SerializeField] private int _healthCoint = 10;

    public override void UseBy(Player player)
    {
        player.Health.Add(_healthCoint);

        Debug.Log($"Аптечка применена. Здоровье игрока: {player.Health.Value}");

        Destroy(gameObject);
    }
}
