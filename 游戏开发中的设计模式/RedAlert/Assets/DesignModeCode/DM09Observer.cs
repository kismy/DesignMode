using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM09Observer:MonoBehaviour
{
    private void Start()
    {
        //WeatherStation weather = new global::WeatherStation();

        //BillBoardA a = new BillBoardA();
        //BillBoardB b = new BillBoardB();
        //BillBoardC c = new BillBoardC();

        //weather.Update(a,b,c);

        ////不符合开闭原则 ：对修改关闭，对扩展开放
        ////当需求变更，我们需要扩展显示布告板D,E，F....我们就得必须修改 WeatherStation的Update（）


        ConcreteSubject1 sub1 = new ConcreteSubject1();
        sub1.RegisterObserver(new  ConcreteObserver1(sub1));
        sub1.RegisterObserver(new  ConcreteObserver2(sub1));

        sub1.subjectState = "温度 27，湿度 18，气候 多云";
        sub1.subjectState = "温度 32，湿度 24，气候 晴天";

    }
}

//public class WeatherStation
//{
//    public void Update(BillBoardA a,BillBoardB b,BillBoardC c)
//    {
//        a.Show();
//        b.Show();
//        c.Show();
//    }

//}

//public class BillBoardA
//{

//    public void Show()
//    {
//        Debug.Log("布告板A显示的气象信息");
//    }
//}

//public class BillBoardB
//{

//    public void Show()
//    {
//        Debug.Log("布告板B显示的气象信息");
//    }
//}

//public class BillBoardC
//{

//    public void Show()
//    {
//        Debug.Log("布告板C显示的气象信息");
//    }
//}

public abstract class Subject
{
    List<Observer> mObservers = new List<Observer>();
    public void RegisterObserver(Observer observer)
    {
        mObservers.Add(observer);
    }
    public void RemoveObserver(Observer observer)
    {
        mObservers.Remove(observer);
    }

    public void NotifyObserver()
    {
        foreach (Observer observer in mObservers)
        {
            observer.Update();
        }

    }
}
public class ConcreteSubject1 : Subject
{
    private string mSubjectState;
    public string subjectState
    {
        set {
            mSubjectState = value;
            NotifyObserver();  //在字段发生变化时被调用

        }
        get { return mSubjectState; }
    }

}

public abstract class Observer
{
    public abstract void Update();

}
public class ConcreteObserver1 : Observer
{
    public ConcreteSubject1 mSub1;

    public ConcreteObserver1(ConcreteSubject1 sub1)
    {
        mSub1 = sub1;
    }

    public override void Update()
    {
        Debug.Log("Observer1更新显示 "+mSub1.subjectState);
    }
}
public class ConcreteObserver2 : Observer
{
    public ConcreteSubject1 mSub2;

    public ConcreteObserver2(ConcreteSubject1 sub2)
    {
        mSub2 = sub2;
    }

    public override void Update()
    {
        Debug.Log("Observer2更新显示 " + mSub2.subjectState);
    }
}

