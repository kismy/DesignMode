using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM10Memento:MonoBehaviour
{

    private void Start()
    {
        CareTaker careTaker = new CareTaker();

        Originator originator = new Originator();
        originator.SetState("state1");
        originator.ShowState();

        Memento memento = originator.CreateMemento();
        careTaker.AddMemento("v1.0",memento);

        originator.SetState("state2");
        originator.ShowState();
        memento= originator.CreateMemento();
        careTaker.AddMemento("v2.0", memento);

        originator.SetState("state3");
        originator.ShowState();
        memento = originator.CreateMemento();
        careTaker.AddMemento("v3.0", memento);



        originator.RecoverFromMemento(careTaker.GetMemento("v1.0"));
        originator.ShowState();
        originator.RecoverFromMemento(careTaker.GetMemento("v2.0"));
        originator.ShowState();
        originator.RecoverFromMemento(careTaker.GetMemento("v3.0"));
        originator.ShowState();
    }
}

class Originator
{
    private string mState;
    public void SetState(string state)
    {
        mState = state;
    }

    public void ShowState()
    {
        Debug.Log("Originator state :"+mState);
    }

    public Memento CreateMemento()
    {
        Memento memento = new Memento();
        memento.SetState(mState);
        return memento;
    }

    public void RecoverFromMemento(Memento memento)
    {
        SetState(memento.GetState());
    }
}

class Memento
{
    private string mState;
    public void SetState(string state)
    {
        mState = state;
    }

    public string GetState()
    {
        return mState;
    }
}

class CareTaker
{
    Dictionary<string, Memento> mMementoDict = new Dictionary<string, Memento>();
    public void AddMemento(string vision,Memento memento)
    {
        mMementoDict.Add(vision, memento);
    }

    public Memento GetMemento(string vision)
    {
        if(mMementoDict.ContainsKey(vision))
            return  mMementoDict[vision];
        return null;
    }
}