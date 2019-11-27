using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {


        //string name = "";
        //int maxHP = 0;
        //float moveSpeed = 0;
        //string iconSprite = "";
        //string prefabName = "";

        //if (mType == typeof(SoldierCaptain))
        //{
        //    name = "上尉军官";
        //    maxHP = 100;
        //    moveSpeed = 3;
        //    iconSprite = "CaptainIcon";
        //    mPrefabName = "Soldier1";
        //}
        //else if (mType == typeof(SoldierSergeant))
        //{
        //    name = "中士士兵";
        //    maxHP = 90;
        //    moveSpeed = 3;
        //    iconSprite = "SergeantIcon";
        //    mPrefabName = "Soldier3";

        //}
        //else if (mType == typeof(SoldierRookie))
        //{
        //    name = "新手士兵";
        //    maxHP = 80;
        //    moveSpeed = 2.5f;
        //    iconSprite = "RookieIcon";
        //    mPrefabName = "Soldier2";
        //}
        //else
        //{
        //    Debug.LogError("类型" + mType + "不属于ISoldier,无法创建战士");
        //}

        //ICharacterAttr attr = new ICharacterAttr(new SoldierAtrrStrategy(), mLv, name, maxHP, moveSpeed, iconSprite, prefabName);
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mType);
        mPrefabName = baseAttr.prefabName;
        ICharacterAttr attr = new ICharacterAttr(new SoldierAtrrStrategy(), mLv, baseAttr);
        mCharacter.attr = attr;

   


    }

    public override void AddCharacterObject()
    {
        //创建角色的游戏物体
        //1.加载   2.实例化
        GameObject characterGO = FactoryManager.assetFactory.LoadSoldier(mPrefabName);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.gameobject = characterGO;
    }

    public override void AddCharacterWeapon()
    {
        //添加武器
        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(mWeaponType);
        mCharacter.weapon = weapon;
    }

    public override void AddInCharacterSystem()
    {
        GameFacade.Instance.AddSoldier(mCharacter as ISoldier);
    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }

    
}