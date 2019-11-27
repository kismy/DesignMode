using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierKilledSubject:IGameEventSubject
{
    private int mKilledCount = 0;
    public int killedCount { get { return mKilledCount; } }

    public override void NotifyObserver()
    {
        mKilledCount++;
        base.NotifyObserver();
    }

}