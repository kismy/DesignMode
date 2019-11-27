using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();

        //string name = "";
        //int maxHP = 0;
        //float moveSpeed = 0;
        //string iconSprite = "";
        //string prefabName = "";
        ////System.Type t = typeof(T);
        //System.Type t = character.GetType();
        //if (t == typeof(EnemyElf))
        //{
        //    name = "小精灵";
        //    maxHP = 100;
        //    moveSpeed = 3;
        //    iconSprite = "ElfIcon";
        //    prefabName = "Enemy1";
        //}
        //else if (t == typeof(EnemyOgre))
        //{
        //    name = "怪物";
        //    maxHP = 120;
        //    moveSpeed = 4;
        //    iconSprite = "OgreIcon";
        //    prefabName = "Enemy2";

        //}
        //else if (t == typeof(EnemyTroll))
        //{
        //    name = "巨魔";
        //    maxHP = 200;
        //    moveSpeed = 1f;
        //    iconSprite = "TrollIcon";
        //    prefabName = "Enemy3";
        //}
        //else
        //{
        //    Debug.LogError("类型" + t + "不属于IEnemy,无法创建战士");
        //    return null;
        //}

        //ICharacterAttr attr = new ICharacterAttr(new SoldierAtrrStrategy(), lv, name, maxHP, moveSpeed, iconSprite, prefabName);
        //character.attr = attr;

        ////创建角色的游戏物体
        ////1.加载   2.实例化
        //GameObject characterGO = FactoryManager.assetFactory.LoadEnemy(prefabName);
        //characterGO.transform.position = spawnPosition;
        //character.gameobject = characterGO;

        ////添加武器
        //IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(weaponType);
        //character.weapon = weapon;

        ICharacterBuilder builder = new EnemyBuilder(character, typeof(T), weaponType, spawnPosition, lv);
        character = CharacterBuilderDirector.Construct(builder);


        return character;
    }
}