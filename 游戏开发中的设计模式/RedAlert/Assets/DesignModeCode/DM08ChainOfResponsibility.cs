using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM08ChainOfResponsibility:MonoBehaviour
{
    private void Start()
    {
        char problem = 'a';
        //switch (problem)  //当需求变更，还有c,d,e,f....类问题，需要修改Switch代码，不符合开闭原则。
        //{
        //    case 'a':
        //        new DMHandlderA().Handle();
        //        break;

        //    case 'b':
        //        new DMHandlderB().Handle();
        //        break;

        //    default:
        //        break;
        //}

        IDMHandler handler = new DMHandlderA();
        handler.Handle(problem);

        problem = 'b';
        handler.Handle(problem);

        problem = 'c';
        handler.Handle(problem);


        problem = 'd';
        handler.Handle(problem);


    }
}



//class DMHandlderA
//{
//    public void Handle()
//    {
//        Debug.Log("处理完了A问题。");
//    }
//}

//class DMHandlderB
//{
//    public void Handle()
//    {
//        Debug.Log("处理完了B问题。");
//    }
//}

public abstract class IDMHandler
{
    protected IDMHandler mNextHandler = null;
    public abstract IDMHandler nextHandler{get;}  

    public abstract void Handle(char problem);

}

class DMHandlderA:IDMHandler
{
    public override IDMHandler nextHandler
    {
        get
        {
            if (mNextHandler == null)
                mNextHandler = new DMHandlderB();
            return mNextHandler;
        }
    }

    public override void Handle(char problem)
    {
        if (problem == 'a')
            Debug.Log("处理完了A问题。");
        else
        {
            nextHandler.Handle(problem);
        }
    }
}

class DMHandlderB:IDMHandler
{
    public override IDMHandler nextHandler
    {
        get
        {
            if (mNextHandler == null)
                mNextHandler = new DMHandlderC();
            return mNextHandler;
        }
    }

    public override void Handle(char problem)
    {
        if (problem == 'b')
            Debug.Log("处理完了B问题。");
        else
        {
            nextHandler.Handle(problem);
        }
    }
}

class DMHandlderC : IDMHandler
{
    public override IDMHandler nextHandler
    {
        get
        {
            //if (mNextHandler == null)
            //    mNextHandler = new DMHandlderC();
            //return mNextHandler;
            return null;
        }
    }

    public override void Handle(char problem)
    {
        if (problem == 'c')
            Debug.Log("处理完了C问题。");
        else
        {
            Debug.LogError( "问题："+problem+"无法解决！");
            //nextHandler = new DMHandlderC();
            //nextHandler.Handle(problem);
        }
    }
}