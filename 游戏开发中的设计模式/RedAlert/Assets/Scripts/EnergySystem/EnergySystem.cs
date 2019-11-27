using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnergySystem : IGameSystem
{
    private const int MAX_Energy = 100;
    private float mCurrentEnergy = MAX_Energy;
    private float mRecoverSpeed =3;


    public override void Init()
    {
        base.Init();

    }

    public override void Update()
    {
        base.Update();
        mFacade.UpdateEnergySlider((int)mCurrentEnergy, MAX_Energy);

        if (mCurrentEnergy >= MAX_Energy) return;
        mCurrentEnergy += mRecoverSpeed * Time.deltaTime;
        //if (mCurrentEnergy >= MAX_Energy)
        //    mCurrentEnergy = MAX_Energy;
        mCurrentEnergy = Mathf.Min(mCurrentEnergy,MAX_Energy);

    }


    public bool TakeEnergy(int value)
    {
        if (mCurrentEnergy >= value)
        {
            mCurrentEnergy -= value;
            return true;
        }
        return false;
    }

    public void ResycleEnergy(int value)
    {
        mCurrentEnergy += value;
        Mathf.Min(mCurrentEnergy,MAX_Energy);
    }

}
