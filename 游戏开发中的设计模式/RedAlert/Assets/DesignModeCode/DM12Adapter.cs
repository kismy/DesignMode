using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//适配器继承于接口，用NewPlugin的新方法实现设配器的方法
public class DM12Adapter:MonoBehaviour
{
    private void Start()
    {
        Adapter adapter = new Adapter(new NewPlugin());

        StandardInterface si = adapter;

        si.Request();
    }
}

 interface StandardInterface
{
    void Request();
}
//implement 工具，手段，措施
class StandardImplementA : StandardInterface
{
    public void Request()
    {
        Debug.Log("使用标准方法A 实现请求。");
    }
}
class StandardImplementB : StandardInterface
{
    public void Request()
    {
        Debug.Log("使用标准方法B 实现请求。");
    }
}

class Adapter : StandardInterface
{
    private NewPlugin mNewPlugin;
    public Adapter(NewPlugin newPlugin)  //之所以需要在外边赋值，是因为newPlugin可能有需要调整的参数。
    {
        mNewPlugin = newPlugin;
    }

    public void Request()
    {
        Debug.Log("使用Adapter适配器调用NewPlugin的方法。");
        mNewPlugin.SpecificRequest();
    }
}

class NewPlugin
{
    public void SpecificRequest()
    {
        Debug.Log("执行 NewPlugin.SpecificRequest()方法。");
    }
}