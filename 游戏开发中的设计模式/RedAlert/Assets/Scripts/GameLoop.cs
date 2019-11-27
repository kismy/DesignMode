using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    private SceneStateController controller;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start () {
        controller = new SceneStateController();
        controller.SetState(new StartState(controller),false);

    }

	void Update () {
        if(controller!=null)
            controller.StateUpdate();


    }
}
