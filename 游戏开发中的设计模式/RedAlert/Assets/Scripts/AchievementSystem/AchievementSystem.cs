using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AchievementSystem : IGameSystem
{
    private int mEnemyKilledCount = 0;
    private int mSoldierKilledCount = 0;
    private int mMaxStageLv = 1;

    public override void Init()
    {
        base.Init();

        mFacade.RegisterObserver(GameEventType.EnemyKilled,new EnemyKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.SoldierKilled,new SoldierKilledObserverArchievement(this));
        mFacade.RegisterObserver(GameEventType.NewStage,new NewStageObserverArchievement(this));
    }

    public void AddEnemyKilledCount(int num = 1)
    {
        mEnemyKilledCount += num;
        Debug.Log("EnemyKilled:" + mEnemyKilledCount);

    }

    public void AddSoldierKilledCount(int num = 1)
    {
        mSoldierKilledCount += num;
        Debug.Log("SoldierKilled:" + mSoldierKilledCount);

    }

    public void SetMaxStageLv(int currentStageLv)
    {
        if (currentStageLv > mMaxStageLv)
        {
            mMaxStageLv = currentStageLv;
            Debug.Log("CurrentStage:"+ mMaxStageLv);
        }
    }

    //应该新建一个数据保存的模块，因为数据保存于加载不只有成就信息，当这些信息分散保存于加载，不利于后期维护，不符合单一职责原则。
    public AchievementMemento CreateMemento()
    {
        //PlayerPrefs.SetInt("EnemyKilledCount", mEnemyKilledCount);
        //PlayerPrefs.SetInt("SoldierKilledCount", mSoldierKilledCount);
        //PlayerPrefs.SetInt("MaxStageLv", mMaxStageLv);

        AchievementMemento memento = new AchievementMemento();
        memento.enemyKilledCount = mEnemyKilledCount;
        memento.soldierKilledCount = mSoldierKilledCount;
        memento.maxStageLv = mMaxStageLv;
        return memento;
    }

    public void RecoveFromMemento(AchievementMemento memento)
    {
        //mEnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
        //mSoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        //mMaxStageLv = PlayerPrefs.GetInt("MaxStageLv");

        mEnemyKilledCount = memento.enemyKilledCount;
        mSoldierKilledCount = memento.soldierKilledCount;
        mMaxStageLv = memento.maxStageLv;
    }





}
