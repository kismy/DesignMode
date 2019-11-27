using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : ISceneState
{

    public MainMenuState(SceneStateController controller) : base("02MainMenuScene", controller)
    {

    }

    public override void StateStart()
    {
        GameObject.Find("StartButton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick() {
        //当切换到BattleState的场景，MainMenuState是上一个场景的东西，就会被销毁

        mController.SetState(new BattleState(mController));
    }

}
