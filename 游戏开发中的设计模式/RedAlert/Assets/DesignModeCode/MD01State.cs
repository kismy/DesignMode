using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD01State : MonoBehaviour {
    private void Start()
    {

        Context context = new Context();
        context.SetState(new ConcreteStateA(context));

        context.Handle(5);
        context.Handle(20);
        context.Handle(30);
        context.Handle(5);


    }


}


public class Context  {
    private IState mstate;
    public void SetState(IState state) {
        this.mstate = state;
    }

    public void Handle(int arg) {
        mstate.Handle(arg);
    }


}

public interface IState {

    void Handle(int arg);
}

public class ConcreteStateA : IState
{
    private Context mContext;
    public ConcreteStateA(Context context) {
        this.mContext = context;
    }


    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateA.Handle "+arg);
        if (arg > 10) {
            mContext.SetState(new ConcreteStateB(mContext));
        }
    }
}

public class ConcreteStateB : IState
{
    private Context mContext;
    public ConcreteStateB(Context context)
    {
        this.mContext = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateB.Handle " + arg);
        if (arg <=10)
        {
            mContext.SetState(new ConcreteStateA(mContext));

        }

    }
}
