using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class StartState:ISceneState
{
    private Image mLogo;
    private float mSmoothingTime = 1;
    private float mWaitTime = 2;

    public StartState(SceneStateController controller):base("01StartScene",controller)
    {


    }

    public override void StateStart()
    {
        mLogo = GameObject.Find("LOGO").GetComponent<Image>();
        mLogo.color = Color.black;
    }

    public override void StateUpdate()
    {
        mLogo.color = Color.Lerp(mLogo.color,Color.white,mSmoothingTime*Time.deltaTime);

        mWaitTime -= Time.deltaTime;
        if (mWaitTime <= 0) {
            //当切换到MainMenuState的场景，SatrtState是上一个场景的东西，就会被销毁
            mController.SetState(new MainMenuState(mController));
        }
    }
}
