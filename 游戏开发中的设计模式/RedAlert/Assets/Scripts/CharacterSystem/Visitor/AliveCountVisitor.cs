using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AliveCountVisitor : ICharacterVisitor
{
    public int enemyCount { get; private set; }
    public int soldierCount { get; private set; }

    public void Reset()
    {
        enemyCount = 0;
        soldierCount = 0;
    }

    public override void VisitorEnemy(IEnemy enemy)
    {
        if (!enemy.IsKilled) enemyCount++;
    }

    public override void VisitorSoldier(ISoldier soldier)
    {
        if (!soldier.IsKilled) soldierCount++;

    }
}