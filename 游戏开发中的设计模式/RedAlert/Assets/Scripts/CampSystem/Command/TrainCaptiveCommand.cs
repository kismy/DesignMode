using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLv;

    public TrainCaptiveCommand(EnemyType enemyType, WeaponType weaponType, Vector3 position, int lv=1)
    {
        mEnemyType = enemyType;
        mWeaponType = weaponType;
        mPosition = position;
        mLv = lv;
    }

    public override void Excute()
    {
        IEnemy enemy = null;

        switch (mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyElf>(mWeaponType,mPosition,mLv) as IEnemy;
                break;

            case EnemyType.Ogre:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPosition, mLv) as IEnemy;
                break;

            case EnemyType.Troll:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPosition, mLv) as IEnemy;
                break;

            default:
                Debug.LogError("无法创建EnemyType："+mEnemyType+"的敌人");
                break;
        }
        //角色被创建时会自动被加入到角色系统的敌人阵营，所以需要移除
        GameFacade.Instance.RemoveEnemy(enemy);
        SoldierCaptive captive = new SoldierCaptive(enemy);
        GameFacade.Instance.AddSoldier(captive);

    }
}