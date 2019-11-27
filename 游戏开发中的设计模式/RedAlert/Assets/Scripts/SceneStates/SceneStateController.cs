using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{

    private ISceneState mState;
    private AsyncOperation mAo;
    private bool mIsRunStart = false;
    public void SetState(ISceneState state,bool isLoadScene=true) {
        if (mState != null) {
            mState.StateEnd(); //让上一个场景做一下清理工作
        }
        mState = state;
        //SceneManager.LoadScene(mState.SceneName);
        if (isLoadScene)
        {
            mAo = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunStart = false;
        }
        else {
            mState.StateStart();
            mIsRunStart = true;
        }

    }

    public void StateUpdate() {
        if (mAo != null && mAo.isDone == false) return;

        if (mIsRunStart==false&& mAo != null && mAo.isDone) {
            mState.StateStart();
            mIsRunStart = true;
        }


        if (mState != null) {
            mState.StateUpdate();
        }

    }
}

