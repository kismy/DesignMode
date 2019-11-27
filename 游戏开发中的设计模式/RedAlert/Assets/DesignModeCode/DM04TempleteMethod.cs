using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class DM04TempleteMethod:MonoBehaviour
{

    private void Start()
    {
        IPeople people = new SouthPeople();
        people.Eat();

    }
}


public abstract class IPeople
{
    public void Eat()
    {
        OrderFoods();
        EatSomething();
        PalBill();

    }

    private void OrderFoods() {
        Debug.Log("点单");
    }

    protected virtual void EatSomething() { }

    private void PalBill()
    {
        Debug.Log("买单");
    }

}

public class NorthPeople : IPeople
{

    protected override void EatSomething()
    {
        Debug.Log("我在吃面条");
    }

}

public class SouthPeople : IPeople
{

    protected override void EatSomething()
    {
        Debug.Log("我在吃米饭");
    }

}
