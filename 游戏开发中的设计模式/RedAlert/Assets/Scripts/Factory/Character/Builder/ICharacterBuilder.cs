using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter;
    protected System.Type mType;
    protected WeaponType mWeaponType;
    protected Vector3 mSpawnPosition;
    protected int mLv;
    protected string mPrefabName="";

    public ICharacterBuilder(ICharacter character, System.Type t,WeaponType weaponType,Vector3 spawnPosition,int lv)
    {
        mCharacter = character;
        mType = t;
        mWeaponType = weaponType;
        mSpawnPosition = spawnPosition;
        mLv = lv;
    }

    public abstract void AddCharacterAttr();

    public abstract void AddCharacterObject();

    public abstract void AddCharacterWeapon();
    public abstract void AddInCharacterSystem();

    public abstract ICharacter GetResult();
}