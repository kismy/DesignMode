using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;


public class Shape : MonoBehaviour {
    private Transform pivot;
    Ctrl ctrl;
    private bool isPuase = false;
    private bool isSpeedUp = false;
    private float timer = 0;
    private float stepTime = 0.8f;
    private float multiple = 20;

    private SpriteRenderer[] renders;
	void Awake () {
        renders = GetComponentsInChildren<SpriteRenderer>();
        pivot = transform.Find("Pivot");

    }

    void Update()
    {
        if (isPuase) return;
        timer += Time.deltaTime;
        if (timer >= stepTime)
        {
            timer = 0;
            Fall();
        }

        InputControl();
    }

    public void Init(Color color,Ctrl ctrl)
    {
        this.ctrl = ctrl;


        foreach (var item in renders)
        {
            item.color = color;
        }
    }

    private void Fall()
    {
        transform.position = transform.position + Vector3.down;

        if (ctrl.model.IsValidMapPosition(this.transform) == false)
        {
            transform.position = transform.position + Vector3.up; //向上移动回去
            isPuase = true;
           bool isLineClear= ctrl.model.PlaceShape(this.transform);
            if(isLineClear)
                ctrl.audioManager.PlayLineClear();
            ctrl.gameManager.FallDown(); //生成新的图形

        }
        else ctrl.audioManager.PlayDrop();

    }
    private bool left, right, up, down;
    private void InputControl()
    {
        if (EasyTouch.current != null&& EasyTouch.current.type == EasyTouch.EvtType.On_SwipeEnd)
        {
            switch (EasyTouch.current.swipe)
            {
                case EasyTouch.SwipeDirection.Left:
                    left = true;
                    right = up = down = false;
                    break;

                case EasyTouch.SwipeDirection.Right:
                    right = true;
                   left =up = down = false;
                    break;

                case EasyTouch.SwipeDirection.Up:
                    up = true;
                    left = right = down = false;
                    break;

                case EasyTouch.SwipeDirection.Down:
                    down = true;
                    left = right = up = false;
                    break;

                default:
                    left = right = up = down = false;
                    break;
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A)||left)
        {
            transform.position += Vector3.left;
            if (ctrl.model.IsValidMapPosition(this.transform) == false)
            {
                transform.position += Vector3.right;
            }
            else ctrl.audioManager.PlayControl();

            isSpeedUp = false;
            stepTime = 0.8f;
            left = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || right)
        {
            transform.position += Vector3.right;
            if (ctrl.model.IsValidMapPosition(this.transform) == false)
            {
                transform.position += Vector3.left;
            }
            else ctrl.audioManager.PlayControl();

            isSpeedUp = false;
            stepTime = 0.8f;
            right = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || up)
        {
            transform.RotateAround(pivot.position, Vector3.forward, -90);
            if (ctrl.model.IsValidMapPosition(this.transform) == false)
            {
                transform.RotateAround(pivot.position,Vector3.forward, 90);
            }
            else ctrl.audioManager.PlayControl();

            isSpeedUp = false;
            stepTime = 0.8f;
            up = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || down)
        {
            isSpeedUp = !isSpeedUp;
            if (isSpeedUp)
            {
                stepTime /= multiple;
            }else
            {
                stepTime = 0.8f;
            }

            down = false;
        }
        
    }
    public void Puase()
    {
        isPuase = true;
    }

    public void Resume()
    {
        isPuase = false;

    }
}
