using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState {

    void Awake()
    {
        stateID = StateID.Menu;
        AddTransition(Transition.StartButtonClick,StateID.Play);
    }

    public override void DoBeforeEntering()
    {
        CTRL.view.ShowMenu();
        CTRL.cameraManager.ZoomOut();
    }

    public override void DoBeforeLeaving()
    {
        CTRL.view.HideMenu();


    }
    public void OnStartButtonClick()
    {
        FSM.PerformTransition(Transition.StartButtonClick);
    }

    public void OnRankButtonClick()
    {
        CTRL.audioManager.PlayCursor();
        CTRL.view.ShowRankUI(CTRL.model.Score, CTRL.model.HighScore, CTRL.model.NumbersGame);

    }

    public void OnRankUIClearButtonClick()
    {
        CTRL.model.ClearData();
        OnRankButtonClick();
    }

    public void OnRestartButtonClick()
    {
        CTRL.model.ReStart();
        CTRL.gameManager.ClearShape();
        FSM.PerformTransition(Transition.StartButtonClick);
    }
}
