using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool isPuase = true; //游戏是否暂停
    private Ctrl ctrl;
    public Shape[] shapes;
    public Color[] colors;
    private Shape currentShape = null;
    private Transform blockHolder;
    void Awake()
    {
        ctrl = GetComponent<Ctrl>();
        blockHolder = transform.Find("BlockHolder");
    }
    void Start () {
		
	}
	

	void Update () {
        if (isPuase==true) return;

        if (currentShape == null) SpawnShape();
		
	}

    public void ClearShape()
    {
        if (currentShape != null)
        {
            Destroy(currentShape.gameObject);
            currentShape = null;
        }
    }
    public void StartGame()
    {
        isPuase = false;
        if (currentShape != null)
            currentShape.Resume();
    }

    public void PuaseGame()
    {
        isPuase = true;
        if (currentShape != null)
            currentShape.Puase();

    }
    void SpawnShape()
    {
        int indexShape = Random.Range(0,shapes.Length);
        int indexColor = Random.Range(0,colors.Length);
        currentShape = GameObject.Instantiate(shapes[indexShape]);
        currentShape.Init(colors[indexColor],ctrl);

        currentShape.transform.parent = blockHolder;

    }
    public void FallDown()
    {
        currentShape = null;
        if (ctrl.model.isDataUpdate)
        {
            ctrl.view.UpdateGameUI(ctrl.model.Score, ctrl.model.HighScore);
            ctrl.model.isDataUpdate = false;
        }

        foreach (Transform shape in blockHolder)
        {
            if (shape.childCount <= 1)
            {
                Destroy(shape.gameObject);
            }
        }

        if (ctrl.model.IsGameOver())
        {
            PuaseGame();
            ctrl.view.ShowGameOverUI(ctrl.model.Score);
        }
    }
}
