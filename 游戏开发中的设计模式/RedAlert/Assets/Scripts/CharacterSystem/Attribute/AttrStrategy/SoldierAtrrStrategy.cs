using System;
using System.Collections.Generic;
using System.Text;

public class SoldierAtrrStrategy : IAttrStrategy
{
    public int GetCritDmg(float critRate)
    {
        return 0;
    }

    public int GetDmgDescValue(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetEXtraHPValue(int lv)
    {
        return (lv - 1) * 10;
    }
}
