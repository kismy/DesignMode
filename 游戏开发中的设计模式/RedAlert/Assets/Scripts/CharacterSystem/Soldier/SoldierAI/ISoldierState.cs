using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine; 

public enum SoldierTransition
{
NullTansition=0,
SeeEnemy,
NoEnemy_LostEnemy,
CanAttack

}

public enum SoldierStateID
{
    NullState,
    Idle,
    Chase,
    Attack

}

public abstract class ISoldierState
{

    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID mStateID;
    protected ICharacter mCharacter;
    protected SoldierFSMSystem mFSM;

    public ISoldierState(SoldierFSMSystem fsm,ICharacter character)
    {
        this.mFSM = fsm;
        mCharacter = character;

    }
    public SoldierStateID stateID
    {
        get { return mStateID; }
    }


    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {

        if (trans == SoldierTransition.NullTansition)
        {
            Debug.LogError("SoldierState Error: SoldierTransition不能为空"); return;
        }

        if (id == SoldierStateID.NullState)
        {
            Debug.LogError("SoldierState Error: SoldierStateID不能为空"); return;
        }

        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error: " + trans + " 已经添加上了"); return;

        }

        mMap.Add(trans, id);
    }

    public void DeleteTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (!mMap.ContainsKey(trans))
        {
            Debug.LogError("删除转换条件的时候，转换条件: " + trans + " 不存在"); return;

        }
        mMap.Remove(trans);
    }

    public SoldierStateID GetOutputState(SoldierTransition trans)
    {
        SoldierStateID id = SoldierStateID.NullState;

        if (mMap.ContainsKey(trans))
        {
            //mMap.TryGetValue(trans, out id);
            id = mMap[trans];
        }
        return id;
    }


    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }
    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}