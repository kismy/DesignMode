using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierKilledObserverArchievement : IGameEventObserver
{
    private AchievementSystem mArchievementSystem;

    public SoldierKilledObserverArchievement(AchievementSystem archievementSystem)
    {
        mArchievementSystem = archievementSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        return;
    }

    public override void Update()
    {
        mArchievementSystem.AddSoldierKilledCount();
    }
}