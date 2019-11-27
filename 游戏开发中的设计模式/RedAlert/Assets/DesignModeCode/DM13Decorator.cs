using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM13Decorator:MonoBehaviour
{
    private void Start()
    {
        Coffee coffee = new Espresso();

        coffee=coffee.AddDecorator(new Mocha());
        coffee=coffee.AddDecorator(new Mocha());
        coffee =coffee.AddDecorator(new Whip());
        coffee =coffee.AddDecorator(new Whip());
        coffee =coffee.AddDecorator(new Whip());

        Debug.Log(coffee.Cost());
        Debug.Log(coffee.Capacity());
    }
}

//咖啡类基类
public abstract class Coffee
{
   public abstract float Cost();
   public abstract float Capacity();

    public Coffee AddDecorator(Decorator decorator)
    {
        decorator.coffee = this;
        return decorator;
    }
}
public class Espresso : Coffee
{
    public override float Capacity()
    {
        return 10;
    }

    public override float Cost()
    {
        return 2.5f;
    }
}
public class Decaf : Coffee
{
    public override float Capacity()
    {
        return 10;
    }

    public override float Cost()
    {
        return 2f;
    }
}

//装饰类基类
public  class Decorator : Coffee
{
    public Coffee coffee { get; set; }

    public override float Capacity()
    {
        return coffee.Capacity();
    }

    public override float Cost()
    {
        return coffee.Cost();
    }
}
public class Mocha : Decorator
{
    private float exTraCost=0.1f;
    private float exTraCapcity=0.2f;

    public override float Capacity()
    {
        return coffee.Capacity()+exTraCapcity;
    }

    public override float Cost()
    {
        return  (coffee.Cost() + exTraCost) ;
    }
}
public class Whip : Decorator
{
    private float exTraCost = 0.5f;
    private float exTraCapcity = 0.2f;

    public override float Capacity()
    {
        return coffee.Capacity() + exTraCapcity;
    }

    public override float Cost()
    {
        return (coffee.Cost() + exTraCost);
    }
}

//心得：这种实现很垃圾，代码很乱，不易理解。
//我更愿意在Coffee类里面添加 List<Decorator> ,然后把Mocha和Whip添加进去。在不需要装饰时，移除装饰的实现也简单。