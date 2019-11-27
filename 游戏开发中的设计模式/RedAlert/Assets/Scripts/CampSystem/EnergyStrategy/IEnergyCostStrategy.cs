using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


/// <summary>
/// 能量消耗策略
/// </summary>
public abstract class IEnergyCostStrategy
{
    public abstract int GetCampUpgradeCost( SoldierType soldierType, int campLv);
    public abstract int GetWeaponUpgradeCost(WeaponType weaponType);
    public abstract int GetSoldierTrainCost(SoldierType soldierType,int soldierLv);

}