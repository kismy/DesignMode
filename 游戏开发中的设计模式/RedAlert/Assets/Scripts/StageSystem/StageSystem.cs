using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class StageSystem:IGameSystem
{

    private int mLv = 1;
    private List<Vector3> mPosList = new List<Vector3>();
    private IStageHandler mRootHandler;
    private Vector3 mTargetPosition;
    private int mCountOfEnemyKilled = 0;

    public Vector3 targetPosition { get { return mTargetPosition; }}


    public override void Init()
    {
        base.Init();
        InitPos();
        InitStageChain();

        mFacade.RegisterObserver(GameEventType.EnemyKilled,new EnemyKilledObserverStageSystem(this));
    }

    public override void Update()
    {
        base.Update();
        mRootHandler.Handle(mLv);
    }

    private void InitPos()
    {
        int i = 0;
        while (true)
        {
            i++;
            
            GameObject go = GameObject.Find("Position"+i);
            if (go != null)
            {
                mPosList.Add(go.transform.position);
                go.SetActive(false);
            }
            else
            {
                Debug.LogError("查找不到名为Position"+i+"的物体！");
                break;
            }
        }

       
        mTargetPosition= GameObject.Find("TargetPosition").transform.position;

    }

    private void InitStageChain()
    {
        int lv = 1;
        NormalStageHandler handler1 = new NormalStageHandler(this,lv++, 3,EnemyType.Elf,WeaponType.Gun,3, GetRandomPos());
        NormalStageHandler handler2 = new NormalStageHandler(this,lv++,6,EnemyType.Elf,WeaponType.Rifle,3, GetRandomPos());
        NormalStageHandler handler3 = new NormalStageHandler(this,lv++,9,EnemyType.Elf,WeaponType.Rocket,3, GetRandomPos());
        NormalStageHandler handler4 = new NormalStageHandler(this,lv++,14,EnemyType.Ogre,WeaponType.Gun,4, GetRandomPos());
        NormalStageHandler handler5 = new NormalStageHandler(this,lv++,18,EnemyType.Ogre, WeaponType.Rifle,4, GetRandomPos());
        NormalStageHandler handler6 = new NormalStageHandler(this,lv++,22,EnemyType.Ogre, WeaponType.Rocket,4, GetRandomPos());
        NormalStageHandler handler7 = new NormalStageHandler(this,lv++,27,EnemyType.Troll,WeaponType.Gun,5, GetRandomPos());
        NormalStageHandler handler8 = new NormalStageHandler(this,lv++,32,EnemyType.Troll, WeaponType.Rifle,5, GetRandomPos());
        NormalStageHandler handler9 = new NormalStageHandler(this, lv++, 37,EnemyType.Troll, WeaponType.Rocket,5, GetRandomPos());

        handler1.nextHandler = handler2;
        handler2.nextHandler = handler3;
        handler3.nextHandler = handler4;
        handler4.nextHandler = handler5;
        handler5.nextHandler = handler6;
        handler6.nextHandler = handler7;
        handler7.nextHandler = handler8;
        handler8.nextHandler = handler9;

        mRootHandler = handler1;


    }

    private Vector3 GetRandomPos() { return mPosList[UnityEngine.Random.Range(0, mPosList.Count)]; }

    public int countOfEnemyKilled
    {
        //get { return mCountOfEnemyKilled; }
        set {
            mCountOfEnemyKilled = value;
        }

    }

    public int GetCountofEnemyKilled()
    {

        return mCountOfEnemyKilled;
    }

    public void EnterNextStage()
    {
        mLv++;
        mFacade.NotifySubjects(GameEventType.NewStage);

    }


}
