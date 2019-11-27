using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, Type t, WeaponType weaponType, Vector3 spawnPosition, int lv) : base(character, t, weaponType, spawnPosition, lv)
    {
    }

    public override void AddCharacterAttr()
    {
        //string name = "";
        //int maxHP = 0;
        //float moveSpeed = 0;
        //string iconSprite = "";

        //if (mType == typeof(EnemyElf))
        //{
        //    name = "小精灵";
        //    maxHP = 100;
        //    moveSpeed = 3;
        //    iconSprite = "ElfIcon";
        //    mPrefabName = "Enemy1";
        //}
        //else if (mType == typeof(EnemyOgre))
        //{
        //    name = "怪物";
        //    maxHP = 120;
        //    moveSpeed = 4;
        //    iconSprite = "OgreIcon";
        //    mPrefabName = "Enemy2";

        //}
        //else if (mType == typeof(EnemyTroll))
        //{
        //    name = "巨魔";
        //    maxHP = 200;
        //    moveSpeed = 1f;
        //    iconSprite = "TrollIcon";
        //    mPrefabName = "Enemy3";
        //}
        //else
        //{
        //    Debug.LogError("类型" + mType + "不属于IEnemy,无法创建战士");
        //}

        //ICharacterAttr attr = new ICharacterAttr(new SoldierAtrrStrategy(), mLv, name, maxHP, moveSpeed, iconSprite, mPrefabName);
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mType);
        mPrefabName = baseAttr.prefabName;
        ICharacterAttr attr = new ICharacterAttr(new EnemyAttrStrategy(), mLv, baseAttr);

        mCharacter.attr = attr;
    }

    public override void AddCharacterObject()
    {
        //创建角色的游戏物体
        //1.加载   2.实例化
        GameObject characterGO = FactoryManager.assetFactory.LoadEnemy(mPrefabName);
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
        GameFacade.Instance.AddEnemy(mCharacter as IEnemy);

    }

    public override ICharacter GetResult()
    {
        return mCharacter;
    }
}