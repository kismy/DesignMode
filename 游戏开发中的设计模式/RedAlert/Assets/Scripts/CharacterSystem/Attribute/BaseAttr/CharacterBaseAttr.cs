using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CharacterBaseAttr
{
    private string mName;
    private int mMaxHP;
    private float mMoveSpeed;
    private string mIconSprite;
    private string mPrefabName;
    private float mCritRate; //0-1  暴击率,随机增加伤害

    public CharacterBaseAttr(string name, int maxHP, float moveSpeed, string iconSprite, string prefabName, float critRate)
    {
        mName = name;
        mMaxHP = maxHP;
        mMoveSpeed = moveSpeed;
        mIconSprite = iconSprite;
        mPrefabName = prefabName;
        mCritRate = critRate;

    }

    public string name { get { return mName; } }
    public int maxHP { get { return mMaxHP; } }
    public float moveSpeed { get { return mMoveSpeed; } }
    public string iconSprite { get { return mIconSprite; } }
    public string prefabName { get { return mPrefabName; } }
    public float critRate { get { return mCritRate; } }

}