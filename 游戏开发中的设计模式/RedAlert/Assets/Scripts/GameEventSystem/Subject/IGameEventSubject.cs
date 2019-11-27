using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IGameEventSubject
{
    private List<IGameEventObserver> mObservers = new List<IGameEventObserver>();

    public void RegisterObserver(IGameEventObserver observer)
    {
        mObservers.Add(observer);
    }

    public void RemoveObserver(IGameEventObserver observer)
    {
        mObservers.Remove(observer);
    }

    public virtual void NotifyObserver()
    {
        foreach (IGameEventObserver observer in mObservers)
        {
            observer.Update();
        }
    }
}