using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


/// <summary>
/// 当主题mSubject发生变化,我们从mSubject取得数据，设置到mStageSystem
/// </summary>
public class EnemyKilledObserverStageSystem : IGameEventObserver
{
    private EnemyKilledSubject mSubject;
    private StageSystem mStageSystem;

    public EnemyKilledObserverStageSystem(StageSystem ss)
    {
        mStageSystem = ss;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyKilledSubject;
    }

    public override void Update()
    {

        mStageSystem.countOfEnemyKilled = mSubject.killedCount;
    }
}