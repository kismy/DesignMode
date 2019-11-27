using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TrainSoldierCommand : ITrainCommand
{

    private SoldierType mSoldierType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLv;

 

    public TrainSoldierCommand(SoldierType soldierType, WeaponType weaponType, Vector3 position, int lv)
    {
        mSoldierType = soldierType;
        mWeaponType = weaponType;
        mPosition = position;
        mLv = lv;

    }



    public override void Excute()
    {
        switch (mSoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.soldierFactory.CreateCharacter<SoldierRookie>(mWeaponType,mPosition,mLv);
                break;

            case SoldierType.Sergeant:
                FactoryManager.soldierFactory.CreateCharacter<SoldierSergeant>(mWeaponType, mPosition, mLv);
                break;

            case SoldierType.Captain:
                FactoryManager.soldierFactory.CreateCharacter<SoldierCaptain>(mWeaponType, mPosition, mLv);
                break;

            default:
                Debug.LogError("无法执行命令，无法根据SoldierType:"+ mSoldierType+"创建角色。");
                break;
        }

    }
}