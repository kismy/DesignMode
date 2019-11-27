using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierEnergyCostStrategy : IEnergyCostStrategy
{
    public override int GetCampUpgradeCost(SoldierType soldierType, int campLv)
    {
        int energyCost = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                energyCost = 60;
                break;

            case SoldierType.Sergeant:
                energyCost = 65;
                break;

            case SoldierType.Captain:
                energyCost = 70;
                break;

            default:
                Debug.LogError("无法获取升级"+soldierType+"兵营所需的能量值！");
                break;
        }

        energyCost += (campLv - 1)*2;
        if (energyCost >= 100) return 100;

        return energyCost;
    }

    

    public override int GetSoldierTrainCost(SoldierType soldierType, int soldierLv)
    {
        int energyCost = 0;
        switch (soldierType)
        {
            case SoldierType.Rookie:
                energyCost = 10;
                break;

            case SoldierType.Sergeant:
                energyCost = 15;
                break;

            case SoldierType.Captain:
                energyCost = 20;
                break;

            case SoldierType.Captive:
                energyCost = 10;
                break;

            default:
                Debug.LogError("无法获取士兵类型为：" + soldierType + "训练所需的能量值！");
                break;
        }

        energyCost += (soldierLv - 1) * 2;
        if (energyCost >= 100) return 100;

        return energyCost;
    }

    public override int GetWeaponUpgradeCost(WeaponType weaponType)
    {
        int energyCost = 0;
        switch (weaponType)
        {
            case WeaponType.Gun:
                energyCost = 30;
                break;
            case WeaponType.Rifle:
                energyCost = 40;
                break;


            //case WeaponType.Rocket:
            //    break;
            //case WeaponType.MAX:
            //    break;


            default:
                //Debug.LogError("当前武器"+weaponType+"已是最高等级无法再继续升级——>无法获取升级消耗的能量值！");
                break;
        }

        return energyCost;
    }
}