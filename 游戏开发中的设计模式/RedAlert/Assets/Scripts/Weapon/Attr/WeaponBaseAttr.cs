using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponBaseAttr
{
    private string mName;
    private int mAtk;
    private float mAttackRange;
    protected string mAssetName;


    public WeaponBaseAttr(string name, int atk,float attackRange,string assetName)
    {
        mName = name;
        mAtk = atk;
        mAttackRange = attackRange;
        mAssetName = assetName;
    }

    public string name { get { return name; } }
    public int atk { get { return mAtk; } }
    public float attackRange { get { return mAttackRange; } }
    public string assetName { get { return mAssetName; } }

}