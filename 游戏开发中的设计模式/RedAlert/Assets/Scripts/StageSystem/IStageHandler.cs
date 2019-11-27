using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IStageHandler
{
    protected int mLv; //当前关卡
    private int mCountForFinish; //判断关卡是否结束
    protected StageSystem mStageSystem;

    protected IStageHandler mNextHandler;
    public abstract IStageHandler nextHandler { set; }

    public IStageHandler(StageSystem stageSystem,int level, int countForFinish)
    {
        mStageSystem = stageSystem;
        mLv = level;
        mCountForFinish = countForFinish;

    }

    public virtual void Handle(int level)
    {
        if (level == mLv)
        {
            UpdateStage();
            CheckIsFinished();
        }
        else
        {
            mNextHandler.Handle(level);
        }
    }

    protected abstract void UpdateStage();

    private void CheckIsFinished()
    {
        if (mStageSystem.GetCountofEnemyKilled() >= mCountForFinish)
        {
            mStageSystem.EnterNextStage();

        }
    }

}