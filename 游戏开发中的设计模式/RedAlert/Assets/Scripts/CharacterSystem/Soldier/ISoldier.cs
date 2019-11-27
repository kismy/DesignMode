using System;
using System.Collections.Generic;
using System.Text;

public enum SoldierType
{
    Rookie,
    Sergeant,
    Captain,
    Captive
}

public abstract class ISoldier:ICharacter
{
    protected SoldierFSMSystem mFSMSystem;

    public ISoldier():base()
    {
        MakeFSM();
    }

    public override void UpdateFSMAI(List<ICharacter> targrts)
    {
        if (mIsKilled) return;

        mFSMSystem.currentState.Reason(targrts);
        mFSMSystem.currentState.Act(targrts);
    }

    private void MakeFSM()
    {
        mFSMSystem = new SoldierFSMSystem();

        SoldierIdleState idleState = new global::SoldierIdleState(mFSMSystem,this);
        idleState.AddTransition(SoldierTransition.SeeEnemy,SoldierStateID.Chase);

        SoldierChaseState chaseState = new global::SoldierChaseState(mFSMSystem,this);
        chaseState.AddTransition(SoldierTransition.NoEnemy_LostEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);


        SoldierAttackState attactState = new global::SoldierAttackState(mFSMSystem,this);
        attactState.AddTransition(SoldierTransition.NoEnemy_LostEnemy, SoldierStateID.Idle);
        attactState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);



        //mFSMSystem.AddState(idleState);
        //mFSMSystem.AddState(chaseState);
        //mFSMSystem.AddState(attactState);
        mFSMSystem.AddState(idleState,chaseState,attactState);

    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitorSoldier(this);
    }

    public override void UnderAttack(int damage)
    {
        if (mIsKilled) return;

        base.UnderAttack(damage);
        if (mAttr.currentHP <= 0)
        {
            PlaySound();
            PlayEffect();

            Killed();
        }
    }

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifySubjects(GameEventType.SoldierKilled);

    }

    protected abstract void PlayEffect();

    protected abstract void PlaySound();



}