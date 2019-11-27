using System;
using System.Collections.Generic;
using System.Text;

public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(float critRate)
    {
        if (UnityEngine.Random.Range(0, 1f) < critRate) {
            return (int)(UnityEngine.Random.Range(0.5f, 1f));
        }
        return 0;
    }

    public int GetDmgDescValue(int lv)
    {
        return 0;
    }

    public int GetEXtraHPValue(int lv)
    {
        return 0;
    }
}