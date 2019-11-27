using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierCamp:ICamp
{
    private  const  int MAX_LV = 4; 
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;

    public SoldierCamp(GameObject GO, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime,WeaponType weaponType=WeaponType.Gun,int lv=1)
        : base(GO, name, icon, soldierType, position,trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType;

        energyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();

    }

    public override int lv { get { return mLv; } }

    public override WeaponType weaponType { get { return mWeaponType; } }


    private IEnergyCostStrategy mEnergyCostStrategy;
    protected override IEnergyCostStrategy energyCostStrategy
    {
        get
        {
            if(mEnergyCostStrategy==null)
                mEnergyCostStrategy = new SoldierEnergyCostStrategy();
            return mEnergyCostStrategy;
        }

        set
        {
            mEnergyCostStrategy = value;
        }
    }

    public override int energyCostUpgradeCamp
    {
        get
        {
            if (mLv == MAX_LV)
                return -1;
            else
                return mEnergyCostUpgradeCamp; 
        }
    }

    public override int energyCostUpgradeWeapon
    {
        get
        {
            if ((mWeaponType+1) == WeaponType.MAX)
                return -1;
            else
                return mEnergyCostUpgradeWeapon;
        }
    }

    public override int energyCostTrianCharacter
    {
        get
        {
            return mEnergyCostTrianCharacter;
        }
    }

    public override void Train()
    {
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType,mWeaponType,mPosition,mLv);
        mCommands.Add(cmd);

    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostUpgradeCamp = energyCostStrategy.GetCampUpgradeCost(mSoldierType,mLv);
        mEnergyCostUpgradeWeapon = energyCostStrategy.GetWeaponUpgradeCost(mWeaponType);
        mEnergyCostTrianCharacter = energyCostStrategy.GetSoldierTrainCost(mSoldierType,mLv
            );
    }

    public override void UpgradeCamp()
    {
        //升级兵营操作
        mLv++;
        UpdateEnergyCost();
    }

    public override void UpgradeWeapon()
    {
        //升级武器操作
        mWeaponType++;

        UpdateEnergyCost();
    }
}