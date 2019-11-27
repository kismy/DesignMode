using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AttrFactory : IAttrFactory
{
    private static Dictionary<Type, CharacterBaseAttr> mCharacterBaseAttr = new Dictionary<Type, CharacterBaseAttr>();
    private static Dictionary<WeaponType, WeaponBaseAttr> mWeaponBaseAttr = new Dictionary<WeaponType, WeaponBaseAttr>();
    public AttrFactory()
    {
        InitCharacterBaseAttr();
        InitWeaponBaseAttr();
    }



    private void InitCharacterBaseAttr()
    {
        mCharacterBaseAttr.Add(typeof(SoldierRookie), new CharacterBaseAttr("新手士兵",80,2.5f,"RookieIcon","Soldier2",0));
        mCharacterBaseAttr.Add(typeof(SoldierSergeant), new CharacterBaseAttr("中士士兵",90,3,"SergeantIcon","Soldier3",0));
        mCharacterBaseAttr.Add(typeof(SoldierCaptain), new CharacterBaseAttr("上尉士兵",100,3,"CaptainIcon","Soldier1",0));

        mCharacterBaseAttr.Add(typeof(EnemyElf), new CharacterBaseAttr("小精灵",100,3, "ElfIcon", "Enemy1", 0.2f));
        mCharacterBaseAttr.Add(typeof(EnemyOgre), new CharacterBaseAttr("怪物",120,2, "OgreIcon", "Enemy2", 0.3f));
        mCharacterBaseAttr.Add(typeof(EnemyTroll), new CharacterBaseAttr("巨魔",200,1, "TrollIcon", "Enemy3", 0.4f));

    }

    private void InitWeaponBaseAttr()
    {
        mWeaponBaseAttr.Add(WeaponType.Gun,new WeaponBaseAttr("手枪",20,5,"WeaponGun"));
        mWeaponBaseAttr.Add(WeaponType.Rifle,new WeaponBaseAttr("手枪",30,7,"WeaponRifle"));
        mWeaponBaseAttr.Add(WeaponType.Rocket,new WeaponBaseAttr("手枪",40,8,"WeaponRocket"));
    }

    //public override CharacterBaseAttr GetCharacterBaseAttr(Type t)
    //{
    //    if (!mCharacterBaseAttr.ContainsKey(t))
    //    {
    //        Debug.LogError("无法根据类型："+t+ "获取角色基础属性（GetCharacterBaseAttr())");
    //        return null;
    //    }
    //    return mCharacterBaseAttr[t];
    //}

    public CharacterBaseAttr GetCharacterBaseAttr(Type t)
    {
        if (!mCharacterBaseAttr.ContainsKey(t))
        {
            Debug.LogError("无法根据类型：" + t + "获取角色基础属性（GetCharacterBaseAttr())");
            return null;
        }
        return mCharacterBaseAttr[t];
    }

    public WeaponBaseAttr GetWeaponBaseAttr(WeaponType weaponType)
    {
        if (!mWeaponBaseAttr.ContainsKey(weaponType))
        {
            Debug.LogError("无法根据类型：" + weaponType + "获取武器基础属性（GetWeaponBaseAttr())");
            return null;
        }
        return mWeaponBaseAttr[weaponType];
    }
}