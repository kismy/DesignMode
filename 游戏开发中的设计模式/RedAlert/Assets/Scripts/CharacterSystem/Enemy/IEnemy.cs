using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum EnemyType
{
    Elf,
    Ogre,
    Troll
}

public abstract class IEnemy:ICharacter
{
   protected EnemyFSMSystem mFSMSystem;

    public IEnemy()
    {
        MakeFSM();
    }

    public override void UpdateFSMAI(List<ICharacter> characters)
    {
        if (mIsKilled) return;
        mFSMSystem.currentState.Reason(characters);
        mFSMSystem.currentState.Act(characters);
    }

    private void MakeFSM()
    {
        mFSMSystem = new global::EnemyFSMSystem();

        EnemyChaseState chaseState = new global::EnemyChaseState(mFSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attackState = new global::EnemyAttackState(mFSMSystem,this);
        attackState.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);


        mFSMSystem.AddState(chaseState,attackState);

    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitorEnemy(this);
    }

    public override void UnderAttack(int damage)
    {
        if (mIsKilled) return;
        base.UnderAttack(damage);
        PlayEffect();
        if (mAttr.currentHP <= 0) Killed();
    }

    public abstract void PlayEffect();

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifySubjects(GameEventType.EnemyKilled);


    }





}