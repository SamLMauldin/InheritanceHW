using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    [SerializeField] int _treasureAmount = 1;
    protected override void Collect(Player player)
    {
        //Adds treasure to UI
        player.IncreaseTreasure(_treasureAmount);
    }
}
