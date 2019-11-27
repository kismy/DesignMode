using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ICamp
{
    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;
    protected Vector3 mPosition; //集合点


    protected List<ITrainCommand> mCommands = new List<ITrainCommand>();
    protected float mTrainTime;
    private float mTrainTimer = 0;

    protected abstract IEnergyCostStrategy energyCostStrategy { get; set; }
    protected int mEnergyCostUpgradeCamp;
    protected int mEnergyCostUpgradeWeapon;
    protected int mEnergyCostTrianCharacter;



    public ICamp(GameObject GO,string name,string icon,SoldierType soldierType,Vector3 position,float trainTime)
    {
        mGameObject = GO;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mPosition = position;
        mTrainTime = trainTime;
        mTrainTimer = mTrainTime;

    }

    public virtual void Update()
    {
        UpdateCommand();

    }
    private void UpdateCommand()
    {
        if (mCommands.Count <= 0) return;
        mTrainTimer -= Time.deltaTime;
        if (mTrainTimer <= 0)
        {
            mCommands[0].Excute();
            mCommands.RemoveAt(0);

            mTrainTimer = mTrainTime;
        }

    }

    protected abstract void UpdateEnergyCost();


    public GameObject gameObject { get { return mGameObject; } }
    public string name { get { return mName; } }
    public string iconSprite { get { return mIconSprite; } }
    public SoldierType soldierType { get { return mSoldierType; } }
    public Vector3 position { get { return mPosition; } }
    public float trainTime { get { return mTrainTime; } }

    public abstract int lv { get; }
    public abstract WeaponType weaponType { get; }
    public abstract int energyCostUpgradeCamp { get; }
    public abstract int energyCostUpgradeWeapon { get; }
    public abstract int energyCostTrianCharacter { get; }


    public abstract void Train();
    public abstract void UpgradeCamp();
    public abstract void UpgradeWeapon();


    public void CancelTrainCommand()
    {

        if (mCommands.Count > 0)
        {
            mCommands.RemoveAt(mCommands.Count-1);

            if (mCommands.Count == 0)
            {
                mTrainTimer = mTrainTime;
            }
        }
    }


    public int trainCount { get { return mCommands.Count; } }


    public float trainRemainTime
    { get
        {
            return mTrainTimer;
            //return mTrainTimer+mTrainTime*(mCommands.Count-1);
        }
    }

}