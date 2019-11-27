using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM11Visitor:MonoBehaviour
{
    private void Start()
    {
        DMSphere sphere1 = new DMSphere();
        DMCylinder cylinder1 = new DMCylinder();
        DMCube cube1 = new DMCube();
        DMCube cub2 = new DMCube();

        DMShapeContainer container = new DMShapeContainer();
        container.AddShape(sphere1);
        container.AddShape(cylinder1);
        container.AddShape(cube1);
        container.AddShape(cub2);

        //int count = container.GetShapeCount();  //需求扩展，不符合开闭原则
        //int cubeCount=container.GetCubeCount() //需求扩展，不符合开闭原则

        //符合开闭原则
        AmountVisitor amountVisitor = new AmountVisitor();
        container.RunVisitor(amountVisitor);
        print("图形数量："+amountVisitor.amount);

        CubeAmountVisitor cubeAmount = new CubeAmountVisitor();
        container.RunVisitor(cubeAmount);
        print("cube数量："+cubeAmount.amount);

        EdgeVisitor edgeVisitor = new EdgeVisitor();
        container.RunVisitor(edgeVisitor);
        print("edge数量：" + edgeVisitor.count);
    }
}


//形状的集合.....................................
class DMShapeContainer
{
    private List<IDMShape> mShapes = new List<IDMShape>();

    public void AddShape(IDMShape shape)
    {
        mShapes.Add(shape);
    }

    //public int GetShapeCount()
    //{
    //    return mShapes.Count;
    //}

    //public int GetCubeCount()
    //{
    //    int count = 0;
    //    foreach (IDMShape shape in mShapes)
    //    {
    //        if(shape.GetType() == typeof(DMCube)) count++;
    //    }

    //    return count;
    //}

    //public int GetVolume()
    //{
    //    int temp = 0;
    //    foreach (IDMShape item in mShapes)
    //    {
    //        temp += item.GetVolume();
    //    }
    //    return temp;
    //}

    public void RunVisitor(IShapeVisitor visitor)  //把所有Shape数据保存在visitor中。
    {
        foreach (IDMShape shape in mShapes)
        {
            shape.RunVisitor(visitor);
        }
    }
}



//各种Shape类型..................................
abstract class IDMShape
{
    //public abstract  int GetVolume();
    public int edges;

    public abstract void RunVisitor(IShapeVisitor visitor);
}
class DMSphere : IDMShape
{
    //public override int GetVolume()
    //{
    //    return 30;
    //}

    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitSphere(this);

    }
}
class DMCylinder : IDMShape
{
    //public override int GetVolume()
    //{
    //    return 20;
    //}

    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCylinder(this);
    }
}
class DMCube : IDMShape
{
    //public override int GetVolume()
    //{
    //    return 10;
    //}

    public override void RunVisitor(IShapeVisitor visitor)
    {
        visitor.VisitCube(this);
    }
}



//Shape访问者，IShapeVisitor是访问抽象访问接口....................................
abstract class IShapeVisitor
{
    public abstract void VisitSphere(DMSphere sphere);  //获取sphere对象的数据
    public abstract void VisitCylinder(DMCylinder cylinder); //获取cylinder对象的数据
    public abstract void VisitCube(DMCube cube);        //获取cube对象的数据
}
class AmountVisitor : IShapeVisitor
{

    public   int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        amount++;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        amount++;
    }
}
class CubeAmountVisitor : IShapeVisitor
{
    public int amount = 0;
    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        return;
    }

    public override void VisitSphere(DMSphere sphere)
    {
        return;
    }
}
class EdgeVisitor : IShapeVisitor
{
    public int count = 0;
    public override void VisitCube(DMCube cube)
    {
        //count += cube.edges;  有12
        count += 12;

    }

    public override void VisitCylinder(DMCylinder cylinder)
    {
        //count += cylinder.edges; 假设有2
        count += 2;


    }

    public override void VisitSphere(DMSphere sphere)
    {
        //count += sphere.edges;假设有1
        count += 1;

    }
}

