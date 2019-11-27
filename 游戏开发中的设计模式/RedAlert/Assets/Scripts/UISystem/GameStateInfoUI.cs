using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInfoUI:IBaseUI
{

    private List<GameObject> mHearts = new List<GameObject>();
    private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mCurrentStage;
    private Text mMessage;
    private Button mPauseBtn;
    private Button mBackMenuBtn;
    private GameObject mGameOverUI;
    private Slider mEnergySlider;
    private Text mEnergyText;
    private float mMsgTimer = 0;
    private float mMsgTime = 2;
    private AliveCountVisitor mAliveCountVisitor=new AliveCountVisitor();

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GameStateUI");
        GameObject heart1 = UnityTool.FindChild( mRootUI,"Heart1");
        GameObject heart2 = UnityTool.FindChild( mRootUI,"Heart2");
        GameObject heart3 = UnityTool.FindChild( mRootUI,"Heart3");
        mHearts.Add(heart1);
        mHearts.Add(heart2);
        mHearts.Add(heart3);

        mSoldierCount = UITool.FindChild<Text>(mRootUI, "SoldierCount");
        mEnemyCount = UITool.FindChild<Text>(mRootUI, "EnemyCount");
        mCurrentStage = UITool.FindChild<Text>(mRootUI, "StageCount");
        mMessage = UITool.FindChild<Text>(mRootUI, "Message");


        mPauseBtn = UITool.FindChild<Button>(mRootUI, "PauseBtn");
        mBackMenuBtn = UITool.FindChild<Button>(mRootUI, "BackMenuBtn");

        mGameOverUI = UnityTool.FindChild(mRootUI, "GameOver");
        mEnergySlider = UITool.FindChild<Slider>(mRootUI, "EnergySlider");
        mEnergyText = UITool.FindChild<Text>(mRootUI, "EnergyText");

        mMessage.text = "";
        mGameOverUI.SetActive(false);
    }

    public override void Update()
    {
        base.Update();

        if (mMsgTimer > 0)
        {
            mMsgTimer -= Time.deltaTime;
            if (mMsgTimer <= 0)
            {
                mMessage.text = "";
                mMessage.gameObject.SetActive(false);
            }
        }

        UpdateAliveCount();
    }

    public void ShowMsg(string msg)
    {
        mMessage.gameObject.SetActive(true);
        mMessage.text = msg;
        mMsgTimer = mMsgTime;
    }

    public void UpdateEnergySlider(int currentEnergy,int maxEnergy)
    {
        mEnergySlider.value = (float)currentEnergy / maxEnergy;
        mEnergyText.text = "("+currentEnergy+"/ "+maxEnergy+")";
    }


    public void UpdateAliveCount()
    {
        mAliveCountVisitor.Reset();
        mFacade.RunVisitor(mAliveCountVisitor);
        mSoldierCount.text = mAliveCountVisitor.soldierCount.ToString();
        mEnemyCount.text = mAliveCountVisitor.enemyCount.ToString();

    }
}
