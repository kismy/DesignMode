using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IGameEventObserver
{
    public abstract void Update();

    //设置想要观察的主题，甚至可以通过Add Sub到LIst<>同时观察多个主题
    public abstract void SetSubject(IGameEventSubject sub);
}