using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//IShape拥有IRenderEngine
public class DM02Bridge:MonoBehaviour
{

    private void Start()
    {
        //Sphere sphere = new global::Sphere();
        //sphere.Draw();

        //Cube cube = new Cube();
        //cube.Draw();

        //Capsule capsule = new Capsule();
        //capsule.Draw();

        //IRenderEngine renderEngine = new OpenGL();
        //Sphere sphere = new Sphere(renderEngine);
        //sphere.Draw();

        //ICharacter character = new SoldierCaptain();
        //character.Weapon = new WeaponGun();
        //character.Attack(Vector3.zero);

    }
}

public class Sphere:IShape
{
    //public string name = "Sphere";
    ////让球体自我绘制功能
    //public OpenGL openGL = new OpenGL();
    //public DirectX directX = new DirectX();
    //public void Draw() {
    //    openGL.Render(name);
    //}

    //public void DrawDX()
    //{
    //    directX.Render(name);
    //}

    public Sphere(IRenderEngine renderEngine) : base(renderEngine)
    {
        this.renderEngine = renderEngine;

        name = "Sphere";
    }
    public override void Draw()
    {
        renderEngine.Render(name);
    }
}
public class Cube:IShape
{
    //public string name = "Cube";
    ////让球体自我绘制功能
    //public OpenGL openGL = new OpenGL();
    //public DirectX directX = new DirectX();

    //public void Draw()
    //{
    //    openGL.Render(name);
    //}
    //public void DrawDX()
    //{
    //    directX.Render(name);
    //}

    public Cube(IRenderEngine renderEngine) : base(renderEngine)
    {
        this.renderEngine = renderEngine;

        name = "Cube";
    }
    public override void Draw()
    {
        renderEngine.Render(name);
    }
}
public class Capsule:IShape
{
    //public string name = "Capsule";
    ////让球体自我绘制功能
    //public OpenGL openGL = new OpenGL();
    //public DirectX directX = new DirectX();

    //public void Draw()
    //{
    //    openGL.Render(name);
    //}
    //public void DrawDX()
    //{
    //    directX.Render(name);
    //}

    public Capsule(IRenderEngine renderEngine):base(renderEngine) 
    {
        this.renderEngine = renderEngine;
        name = "Capsule";
    }

    public override  void  Draw()
    {
      
        renderEngine.Render(name);
    }
}

 /////////////////以下为渲染引擎
public class OpenGL:IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("OpenGL绘制出来了："+name);
    }
}
public class DirectX:IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("DirectX绘制出来了：" + name);
    }
}
public class SuperEngine : IRenderEngine  //不存在的引擎，假设其存在
{
    public override void Render(string name)
    {
        Debug.Log("SuperEngine绘制出来了：" + name);
    }
}

/////////////////////////////////////////以下为桥接模式
public class IShape {
    public string name;
    public IRenderEngine renderEngine;
    public  IShape(IRenderEngine renderEngine) {
       this. renderEngine = renderEngine;
    }

    public virtual void Draw()
    {
        renderEngine.Render(name);
    }

}
public  abstract class IRenderEngine {
    public virtual void Render(string name) { }
}

