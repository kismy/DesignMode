using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//model 和 view 不直接交互，通过Ctrl为中介交互
public class Ctrl : MonoBehaviour {

    [HideInInspector]
    public Model model;

    [HideInInspector]
    public View view;

    [HideInInspector]
    public CameraManager cameraManager;
    [HideInInspector]
    public GameManager gameManager;
    [HideInInspector]
    public AudioManager audioManager;


    private FSMSystem fsm;

    private void Awake()
    {

        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
        cameraManager = GetComponent<CameraManager>();
        gameManager = GetComponent<GameManager>();
        audioManager = GetComponent<AudioManager>();
    }

    void Start () {
        MakeFSM();

    }

    // Update is called once per frame
    void Update () {
		
	}

    void MakeFSM()
    {
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>();
        foreach (var state in states)
        {
            fsm.AddState(state,this);
        }
        MenuState defualtState = GetComponentInChildren<MenuState>();
        fsm.SetCurrentState(defualtState);
        
    }
}
