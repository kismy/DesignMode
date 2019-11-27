using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour {

    private Camera mainCamera;
    void Awake()
    {
        mainCamera = Camera.main;
    }
    void Start () {
		
	}

    //放大
    public void ZoomIn()
    {
        mainCamera.orthographicSize = 18;
        mainCamera.DOOrthoSize(13,0.5f);

    }    
    //缩小
    public void ZoomOut()
    {
        mainCamera.orthographicSize = 1000;
        mainCamera.DOOrthoSize(18, 0.5f);

    }




}
