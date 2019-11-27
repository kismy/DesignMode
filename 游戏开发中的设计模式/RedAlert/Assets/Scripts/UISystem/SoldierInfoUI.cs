using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SoldierInfoUI:IBaseUI
{
    private Image mSoldierIcon;
    private Slider mHPSlider;

    private Text mSoldierName;
    private Text MHPText;
    private Text mLV;
    private Text mAtk;
    private Text mATKRange;
    private Text mMoveSpeed;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");


        mSoldierIcon = UITool.FindChild<Image>(mRootUI, "SoldierIcon");
        mHPSlider = UITool.FindChild<Slider>(mRootUI, "HPSlider");

        mSoldierName = UITool.FindChild<Text>(mRootUI, "SoldierName");
        MHPText = UITool.FindChild<Text>(mRootUI, "HP");
        mLV = UITool.FindChild<Text>(mRootUI, "LV");
        mAtk = UITool.FindChild<Text>(mRootUI, "ATK");
        mATKRange = UITool.FindChild<Text>(mRootUI, "ATKRange");
        mMoveSpeed = UITool.FindChild<Text>(mRootUI, "MoveSpeed");


        Hide();
    }
}
