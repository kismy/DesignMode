using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class EnemyChaseState : IEnemyState
{
    private Vector3 mTargetPosition;
    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = EnemyStateID.Chase;
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
            mCharacter.MoveTo(targets[0].position);
        else
            mCharacter.MoveTo(mTargetPosition);
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            float distance = Vector3.Distance(mCharacter.position,targets[0].position);
            if(distance<=mCharacter.atkRange)
                mFSM.PerformTransition(EnemyTransition.CanAttack);
        }

    
    }

    public override void DoBeforeEntering()
    {
        mTargetPosition = GameFacade.Instance.GetTargetPosition();
    }
}