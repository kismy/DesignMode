using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState {
    void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PuaseButtonClick, StateID.Menu);

    }

    public override void DoBeforeEntering()
    {
        CTRL.view.ShowGameUI(CTRL.model.Score, CTRL.model.HighScore);
        CTRL.cameraManager.ZoomIn();
        CTRL.gameManager.StartGame();

    }

    public override void DoBeforeLeaving()
    {
        CTRL.view.HideGameUI();
        CTRL.view.ShowRestartButton();
        CTRL.gameManager.PuaseGame();



    }
    public void OnPuaseButtonClick()
    {
        CTRL.audioManager.PlayCursor();
        FSM.PerformTransition(Transition.PuaseButtonClick);
    }

    public void OnRestartButtonClick()
    {
        CTRL.view.HideGameOverUI();
        CTRL.model.ReStart();
        CTRL.gameManager.StartGame();
        CTRL.view.UpdateGameUI(0,CTRL.model.HighScore);
    }
}
