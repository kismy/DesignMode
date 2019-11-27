using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI:IBaseUI
{

    private Image mCampIcon;

    private Text mCampName;
    private Text mCampLevel;
    private Text mWeaponLevel;

    private Button mCampUpgradeBtn;
    private Button mWeaponUpgradeBtn;
    private Button mTrainBtn;
    private Text mTrainBtnText;
    private Button mCancelTrainBtn;

    private Text mAliveCount;
    private Text mTrainCount;
    private Text mTrainTime;

    private ICamp mCurrentCamp;


    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas,"CampInfoUI");

        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UITool.FindChild<Text>(mRootUI, "CampLv");
        mWeaponLevel = UITool.FindChild<Text>(mRootUI, "WeaponLv");

        mCampUpgradeBtn = UITool.FindChild<Button>(mRootUI, "CampUpgradeBtn");
        mWeaponUpgradeBtn = UITool.FindChild<Button>(mRootUI, "WeaponUpgradeBtn");
        mTrainBtn = UITool.FindChild<Button>(mRootUI, "TrainBtn");
        mTrainBtnText = UITool.FindChild<Text>(mRootUI, "TrainCostText");
        mCancelTrainBtn = UITool.FindChild<Button>(mRootUI, "CancelTrainBtn");

        mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
        mTrainCount = UITool.FindChild<Text>(mRootUI, "TrainCount");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");

        mTrainBtn.onClick.AddListener(OnTrainClick);
        mCancelTrainBtn.onClick.AddListener(OnCancelTrainClick);
        mCampUpgradeBtn.onClick.AddListener(OnCampUpgradeClick);
        mWeaponUpgradeBtn.onClick.AddListener(OnWeaponUpgradeClick);

        Hide();
    }


    public override void Update()
    {
        base.Update();
        if (mCurrentCamp != null)
            ShowTrainingInfo();
    }


    public void ShowCampInfo(ICamp camp)
    {
        mCurrentCamp = camp;
        Show();
        mCampIcon.sprite = FactoryManager.assetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        mCampLevel.text = camp.lv.ToString();
        mTrainBtnText.text = "训练\n消耗" + mCurrentCamp.energyCostTrianCharacter+"点能量";

        ShowWeaponLevel(camp.weaponType);
        ShowTrainingInfo();

    }

    private void ShowTrainingInfo()
    {
        mTrainCount.text = mCurrentCamp.trainCount.ToString();
        mTrainTime.text = mCurrentCamp.trainRemainTime.ToString("0.00");
        if (mCurrentCamp.trainCount == 0)
        {
            mCancelTrainBtn.interactable = false;

        }
        else
        {
            mCancelTrainBtn.interactable = true;

        }

    }


    private void ShowWeaponLevel(WeaponType type)
    {
        switch (type)
        {
            case WeaponType.Gun:
                mWeaponLevel.text = "短枪";
                break;
            case WeaponType.Rifle:
                mWeaponLevel.text = "长枪";

                break;
            case WeaponType.Rocket:
                mWeaponLevel.text = "火箭";

                break;
            case WeaponType.MAX:
                mWeaponLevel.text = "";

                break;
            default:
                break;
        }

    }


    private void OnTrainClick()
    {
        int energyCost = mCurrentCamp.energyCostTrianCharacter;

        //判断能力是否足够     //消耗能量 TODO
        if (GameFacade.Instance.TakeEnergy(energyCost))
        {
            mCurrentCamp.Train();
        }
        else
        {
            GameFacade.Instance.ShowMsg("能量不足，无法训练新的士兵！！！");
        }

    
    }


    private void OnCancelTrainClick()
    {
        //回收能量 TODO
        mFacade.ResycleEnergy(mCurrentCamp.energyCostTrianCharacter);

        mCurrentCamp.CancelTrainCommand();
    }


    private void OnCampUpgradeClick()
    {
        int energyCost = mCurrentCamp.energyCostUpgradeCamp;
        if (energyCost < 0)
        {
            //提示信息：不能升级Camp  TODO
            mFacade.ShowMsg("兵营已是最大等级，无法继续升级！");
            return;
        }

        //能量消耗   TODO
        if (mFacade.TakeEnergy(energyCost))
        {
            mCurrentCamp.UpgradeCamp();

            //更新界面
            ShowCampInfo(mCurrentCamp);
        }
        else
        {
            mFacade.ShowMsg("升级兵营需要能量:"+energyCost+"：能量不足，无法继续升级兵营！");

        }

    }

    private void OnWeaponUpgradeClick()
    {
        int energyCost = mCurrentCamp.energyCostUpgradeWeapon;
        if (energyCost < 0)
        {
            //提示信息：不能升级Weapon  TODO
            mFacade.ShowMsg("武器已是最大等级，无法继续升级！");
            return;
        }

        //能量消耗   TODO
        if (mFacade.TakeEnergy(energyCost))
        {
            mCurrentCamp.UpgradeWeapon();

            //更新界面
            ShowCampInfo(mCurrentCamp);
        }
        else
        {
            mFacade.ShowMsg("升级武器需要能量:" + energyCost + "：能量不足，无法继续升级武器！");
        }

    }
}
