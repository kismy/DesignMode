using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class DM05Builder:MonoBehaviour
{
    private void Start()
    {
        IBuilder fatBuilder = new FatPersonBuilder();
        IBuilder thinBuilder = new ThinPersonBuilder();

        Person fatPerson = Director.Condtruct(fatBuilder);
        Person thinPerson = Director.Condtruct(thinBuilder);

        fatPerson.Show();
        thinPerson.Show();
    }
}

class Person
{
    List<string> parts = new List<string>();
    public void AddPart(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        foreach (string part in parts)
        {
           Debug.Log(part);
        }
    }

}
class FatPerson : Person { }
class ThinPerson : Person { }

interface IBuilder
{
    void AddHead();
    void AddBody();
    void AddHand();
    void AddFeet();

    Person GetResult();

}
class FatPersonBuilder : IBuilder
{
    private Person person;

    public FatPersonBuilder()
    {
        person = new FatPerson();
    }
    public void AddBody()
    {
        person.AddPart("胖人身体");
    }

    public void AddFeet()
    {
        person.AddPart("胖人脚部");

    }

    public void AddHand()
    {
        person.AddPart("胖人手部");

    }

    public void AddHead()
    {
        person.AddPart("胖人头部");

    }

    public Person GetResult()
    {
        return person;
    }
}
class ThinPersonBuilder : IBuilder
{
    private Person person;

    public ThinPersonBuilder()
    {
        person = new ThinPerson();
    }
    public void AddBody()
    {
        person.AddPart("瘦人身体");
    }
    public void AddFeet()
    {
        person.AddPart("瘦人脚部");

    }

    public void AddHand()
    {
        person.AddPart("瘦人手部");

    }

    public void AddHead()
    {
        person.AddPart("瘦人头部");

    }

    public Person GetResult()
    {
        return person;
    }
}

class Director
{
    public static Person Condtruct(IBuilder builder)
    {
        builder.AddBody();
        builder.AddFeet();
        builder.AddHand();
        builder.AddHead();
        return builder.GetResult();
    }
}