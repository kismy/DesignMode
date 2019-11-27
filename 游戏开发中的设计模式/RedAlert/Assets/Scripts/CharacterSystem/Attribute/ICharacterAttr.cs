using System;
using System.Collections.Generic;
using System.Text;

public  class ICharacterAttr
{
    //实例化之后值不会改变的一类属性，可以让某一类角色共享一组这些数据，就不会占用重复的内存——享元模式
    //protected string mName;
    //protected int mMaxHP;
    //protected float mMoveSpeed;
    //protected string mIconSprite;
    //protected string mPrefabName;
    //protected float mCritRate; //0-1  暴击率,随机增加伤害
    protected IAttrStrategy mStrategy;
    protected CharacterBaseAttr mBaseAttr;



    //实例化之后值会发生改变的一类属性
    protected int mCurrentHP;
    protected int mLv;
    protected int mDmgDescValue;

    //public ICharacterAttr(IAttrStrategy strategy,int lv, string name,int maxHP,float moveSpeed,string iconSprite,string prefabName)
    public ICharacterAttr(IAttrStrategy strategy,int lv, CharacterBaseAttr baseAttr)
    {
        mBaseAttr = baseAttr;
        mLv = lv;
        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHP = mBaseAttr.maxHP + mStrategy.GetEXtraHPValue(mLv);

        //mName = name;
        //mMaxHP = maxHP;
        //mMoveSpeed = moveSpeed;
        //mIconSprite = iconSprite;
        //mPrefabName = prefabName;
    }

    //策略模式：怎么根据玩家等级，改变玩家的最大血量，抵御伤害，以及对敌人暴击率。


    public int critValue { get { return mStrategy.GetCritDmg(mBaseAttr.critRate); } }

    public int currentHP { get { return mCurrentHP; } }

    public IAttrStrategy strategy { get { return mStrategy; } }

    public CharacterBaseAttr baseAttr { get { return mBaseAttr; } }

    public void TakeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5) damage = 5;
        mCurrentHP -= damage;
    }


}
