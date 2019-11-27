using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MD07Command:MonoBehaviour
{
    private void Start()
    {
        DMInvoker invoker = new DMInvoker();
        ConcreteCommand1 cmd1 = new ConcreteCommand1(new DMReceiver1());
        invoker.AddCommand(cmd1);
        invoker.ExecuteCommand();
    }
}


public class DMInvoker
{
    private List<DMICommand> commands = new List<DMICommand>();
    public void AddCommand(DMICommand cmd)
    {
        commands.Add(cmd);
    }

    public void ExecuteCommand()
    {
        foreach (DMICommand cmd in commands)
        {
            cmd.Execute();
        }
        commands.Clear();
    }

}

//不同的具体的command都可以添加到invoker里面统一管理，有点像委托事件
public abstract class DMICommand
{
    public abstract void Execute();

}
public class ConcreteCommand1 : DMICommand
{
    DMReceiver1 receiver1;
    public ConcreteCommand1(DMReceiver1 receiver)
    {
        receiver1 = receiver;
    }

    public override void Execute()
    {
        receiver1.Action("Command1");
    }
}
public class ConcreteCommand2 : DMICommand
{
    DMReceiver2 receiver2;
    public ConcreteCommand2(DMReceiver2 receiver)
    {
        receiver2 = receiver;
    }

    public override void Execute()
    {
        receiver2.Action("Command2");
    }
}

public class DMReceiver1
{
    public void Action(string cmd)
    {
        Debug.Log("Receiver1执行了命令："+cmd);
    }
}
public class DMReceiver2
{
    public void Action(string cmd)
    {
        Debug.Log("Receiver2执行了命令：" + cmd);
    }
}