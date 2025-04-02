using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Tool
{
    [SerializeField] private int _speedCoint = 3;

    public override void UseBy(Player player)
    {
        player.Mover.Speed.Add(_speedCoint);

        Destroy(gameObject);
    }
}
