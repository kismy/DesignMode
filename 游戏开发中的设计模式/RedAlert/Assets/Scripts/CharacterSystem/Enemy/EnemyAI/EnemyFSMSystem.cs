using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyFSMSystem
{

    private List<IEnemyState> mStates = new List<IEnemyState>();
    private IEnemyState mCurrentState;
    public IEnemyState currentState { get { return mCurrentState; } }

    public void AddState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为Null"); return;
        }

        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            mCurrentState.DoBeforeEntering();

            return;
        }

        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("要添加的状态ID: [" + state.stateID + " ]已存在"); return;

            }
        }


        mStates.Add(state);
    }

    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState state in states) AddState(state);
    }
    public void DeleteState(EnemyStateID stateID)
    {
        if (stateID == EnemyStateID.NullState)
        {
            Debug.LogError("要删除的状态ID不能为Null ：" + stateID); return;
        }

        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == stateID)
            {
                mStates.Remove(s); return;
            }
        }

        Debug.LogError("要删除的状态ID不存在于集合中：" + stateID); return;

    }

    public void PerformTransition(EnemyTransition trans)
    {

        if (trans == EnemyTransition.NullTansition)
        {
            Debug.LogError("要执行的转换条件不能为Null"); return;
        }

        EnemyStateID nextStateID = mCurrentState.GetOutputState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("在转换条件 [" + trans + " ]下，没有对应的转换状态"); return;
        }

        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == nextStateID)
            {
                mCurrentState.DoBeforeEntering();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }
        }


    }
}