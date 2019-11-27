using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public enum EnemyTransition
{
    NullTansition = 0,
    CanAttack,
    LostSoldier

}

public enum EnemyStateID
{
    NullState,
    Chase,
    Attack

}
public abstract class IEnemyState
{

    protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mStateID;
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFSM;

    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        this.mFSM = fsm;
        mCharacter = character;

    }
    public EnemyStateID stateID
    {
        get { return mStateID; }
      
    }


    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {

        if (trans == EnemyTransition.NullTansition)
        {
            Debug.LogError("EnemyState Error: EnemyTransition不能为空"); return;
        }

        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyState Error: EnemyStateID不能为空"); return;
        }

        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("EnemyState Error: " + trans + " 已经添加上了"); return;

        }

        mMap.Add(trans, id);
    }

    public void DeleteTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (!mMap.ContainsKey(trans))
        {
            Debug.LogError("删除转换条件的时候，转换条件: " + trans + " 不存在"); return;

        }
        mMap.Remove(trans);
    }

    public EnemyStateID GetOutputState(EnemyTransition trans)
    {
        EnemyStateID id = EnemyStateID.NullState;

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