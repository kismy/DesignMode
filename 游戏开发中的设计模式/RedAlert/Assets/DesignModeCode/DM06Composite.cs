using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM06Composite:MonoBehaviour
{

    private void Start()
    {
        DMComponent A = new DMCommposite("A");
        DMComponent  B1= new DMCommposite("B1");
        DMComponent B2 = new DMCommposite("B2");
        DMComponent B3 = new DMCommposite("B3");
        A.AddChild(B1);
        A.AddChild(B2);
        A.AddChild(B3);

        DMComponent C1 = new DMCommposite("C1");
        DMComponent C2 = new DMCommposite("C2");
        DMComponent C3 = new DMCommposite("C3");
        DMComponent C4 = new DMCommposite("C4");
        DMComponent C5 = new DMCommposite("C5");
        DMComponent C6 = new DMCommposite("C6");
        B1.AddChild(C1);
        B1.AddChild(C2);
        B2.AddChild(C3);
        B2.AddChild(C4);
        B3.AddChild(C5);
        B3.AddChild(C6);
        DeepReadComponent(A);
    }

    private void WidthReadComponent(DMComponent component)
    {


    }
    private void DeepReadComponent(DMComponent component)
    {
        Debug.Log(component.name);
        List<DMComponent> children = component.GetChildren();
        if (children.Count == 0) return;

        foreach (DMComponent item in children)
        {
         
            DeepReadComponent(item);
        }

    }

}

public abstract class DMComponent
{
    protected List<DMComponent> mChildrenComponents;
    protected string mName;
    public string name { get { return mName; } }

    public DMComponent(string name)
    {
        mChildrenComponents = new List<DMComponent>();
        mName = name;
    }

    public abstract void AddChild(DMComponent c);
    public abstract void RemoveChild(DMComponent c);
    public abstract DMComponent GetChild(int index);
    public abstract List<DMComponent> GetChildren();

}

public class DMLeaf : DMComponent
{
    public DMLeaf(string name) : base(name)
    {
    }

    public override void AddChild(DMComponent c)
    {
        return;
    }

    public override DMComponent GetChild(int index)
    {
        return null;
    }

    public override List<DMComponent> GetChildren()
    {
        return null;
    }

    public override void RemoveChild(DMComponent c)
    {
        return;
    }
}

public class DMCommposite : DMComponent
{
    public DMCommposite(string name) : base(name)
    {
    }

    public override void AddChild(DMComponent c)
    {
        if(c != null && !mChildrenComponents.Contains(c))
            mChildrenComponents.Add(c);
    }

    public override DMComponent GetChild(int index)
    {
        if (mChildrenComponents.Count >= index + 1)
            return mChildrenComponents[index];

        else return null;
    }

    public override List<DMComponent> GetChildren()
    {
        return mChildrenComponents;
    }

    public override void RemoveChild(DMComponent c)
    {
        if (c!=null&&mChildrenComponents.Contains(c))
            mChildrenComponents.Remove(c);
    }
}