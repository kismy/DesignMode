using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CaptiveCamp : ICamp
{
    private WeaponType mWeaponType = WeaponType.Gun;
    private EnemyType mEnemyType;


    public CaptiveCamp(GameObject GO, string name, string icon, EnemyType enemyType, Vector3 position, float trainTime) 
        : base(GO, name, icon, SoldierType.Captive, position, trainTime)
    {
        energyCostStrategy = new SoldierEnergyCostStrategy();
        mEnemyType = enemyType;



    }


    public override int energyCostTrianCharacter
    {
        get
        {
            return mEnergyCostTrianCharacter ;
        }
    }

    public override int energyCostUpgradeCamp
    {
        get
        {
            return 0;
        }
    }

    public override int energyCostUpgradeWeapon
    {
        get
        {
            return 0;
        }
    }

    public override int lv
    {
        get
        {
            return 1;
        }
    }

    public override WeaponType weaponType
    {
        get
        {
            return mWeaponType;
        }
    }

    protected override IEnergyCostStrategy energyCostStrategy
    {
        get
        {
            return null;
        }

        set
        {
            
        }
    }

    public override void Train()
    {
        TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType,mWeaponType,mPosition,1);
        mCommands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        return;
    }

    public override void UpgradeWeapon()
    {
        return;
    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostTrianCharacter = energyCostStrategy.GetSoldierTrainCost(mSoldierType,1);
    }
}