using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NewStageObserverArchievement : IGameEventObserver
{
    private NewStageSubject mSubject;
    private AchievementSystem mArchievementSystem;


    public NewStageObserverArchievement(AchievementSystem archievementSystem)
    {
        mArchievementSystem = archievementSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as NewStageSubject;
    }

    public override void Update()
    {
        mArchievementSystem.SetMaxStageLv(mSubject.stageCount);
    }
}