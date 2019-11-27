using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 观察模式的观察者命名规则：被观察者+观察者
/// </summary>
public class EnemyKilledObserverArchievement : IGameEventObserver
{
    //private EnemyKilledSubject mSubject;
    private AchievementSystem mArchievementSystem;

    public EnemyKilledObserverArchievement(AchievementSystem archievementSystem)
    {
        mArchievementSystem = archievementSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
       // mSubject = sub as  EnemyKilledSubject;
    }

    public override void Update()
    {
        mArchievementSystem.AddEnemyKilledCount();

    }
}