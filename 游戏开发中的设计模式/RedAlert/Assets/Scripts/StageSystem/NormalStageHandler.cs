using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NormalStageHandler : IStageHandler
{
    public override IStageHandler nextHandler
    {
        set
        {
            mNextHandler = value;
        }
    }

    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private int mCount;  //当前关卡需要生成角色个数。
    private Vector3 mPosition;
    private int mSpawnTime = 3;
    private float mSpawnTimer = 0;
    private int mCountSpawned=0;

    public NormalStageHandler(StageSystem stageSystem,int level, int countForFinish, EnemyType enemyType, WeaponType weaponType, int count, Vector3 position) 
        : base(stageSystem,level, countForFinish)
    {
        mEnemyType = enemyType;
        mWeaponType = weaponType;
        mCount = count;
        mPosition = position;

        mSpawnTimer = mSpawnTime;
    }

    protected override void UpdateStage()
    {
        if (mCountSpawned < mCount)
        {
            mSpawnTimer -= Time.deltaTime;
            if (mSpawnTimer <= 0)
            {
                SpawnEnemy();
                mSpawnTimer = mSpawnTime;
            }
        }

    }

    void SpawnEnemy()
    {
        mCountSpawned++;

        switch (mEnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.enemyFactory.CreateCharacter<EnemyElf>(mWeaponType,mPosition);
                break;

            case EnemyType.Ogre:
                FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPosition);
                break;

            case EnemyType.Troll:
                FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPosition);
                break;

            default:
                Debug.LogError("无法生成类型为："+mEnemyType+"的敌人！");
                break;
        }

    }

}