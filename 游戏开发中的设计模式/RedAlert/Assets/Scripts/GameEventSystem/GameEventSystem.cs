using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public enum GameEventType
{
    NULL,
    EnemyKilled,
    SoldierKilled,
    NewStage
}
public class GameEventSystem : IGameSystem
{
    private Dictionary<GameEventType, IGameEventSubject> mGameEvents = new Dictionary<GameEventType, IGameEventSubject>();


    public override void Init()
    {
        base.Init();
    }


    public void InitGameEvents()
    {
        mGameEvents.Add(GameEventType.EnemyKilled,new EnemyKilledSubject() );
        mGameEvents.Add(GameEventType.SoldierKilled,new SoldierKilledSubject() );
        mGameEvents.Add(GameEventType.NewStage,new NewStageSubject() );
    }

    public void RegisterObserver(GameEventType eventType,IGameEventObserver observer)
    {
        //if (mGameEvents.ContainsKey(eventType))
        //{
        //    IGameEventSubject sub= mGameEvents[eventType];
        //    sub.RegisterObserver(observer);  //注册sub事件的观察者
        //    observer.SetSubject(sub); // 设置观察者观察的主题。
        //}
        //else
        //{
        //    Debug.LogError("没有对应被观察事件类型："+eventType+"的主题类！");

        //}

        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.RegisterObserver(observer);  //注册sub事件的观察者
        observer.SetSubject(sub); // 设置观察者观察的主题。


    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {

        //if (mGameEvents.ContainsKey(eventType))
        //{
        //    IGameEventSubject sub = mGameEvents[eventType];
        //    sub.RemoveObserver(observer);  //注册sub事件的观察者
        //    observer.SetSubject(null); // 设置观察者观察的主题。
        //}
        //else
        //{
        //    Debug.LogError("没有对应被观察事件类型：" + eventType + "的主题类！");

        //}

        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.RemoveObserver(observer);  //注册sub事件的观察者
        observer.SetSubject(null); // 设置观察者观察的主题。

    }

    public IGameEventSubject GetGameEventSub(GameEventType eventType)
    {
        IGameEventSubject sub = null;
        if (mGameEvents.ContainsKey(eventType))
        {
            sub = mGameEvents[eventType];
        }
        else
        {

            switch (eventType)
            {
                case GameEventType.EnemyKilled:
                    sub = new EnemyKilledSubject();
                    mGameEvents.Add(GameEventType.EnemyKilled, sub);
                    break;

                case GameEventType.SoldierKilled:
                    sub = new SoldierKilledSubject();
                    mGameEvents.Add(GameEventType.SoldierKilled, sub);
                    break;

                case GameEventType.NewStage:
                    sub = new NewStageSubject();

                    mGameEvents.Add(GameEventType.NewStage, sub);
                    break;

                default:
                    Debug.LogError("没有对应被观察事件类型：" + eventType + "的主题类！");
                    break;
            }

        }
        return sub;
    }


    public void NotifySubjects(GameEventType eventType)
    {
        IGameEventSubject sub = GetGameEventSub(eventType);
        if (sub == null) return;
        sub.NotifyObserver();
    }
}
