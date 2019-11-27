using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour {
    public const int NORMAL_ROWS = 20;
    public const int MAX_ROWS = NORMAL_ROWS + 3;
    public const int MAX_COLUMNS = 10;
    private Transform[,] map = new Transform[MAX_COLUMNS, MAX_ROWS];
    private int score = 0;
    private int highScore;
    private int numbersGame;
    public int Score { get { return score; } }
    public int HighScore { get { return highScore; } }
    public int NumbersGame { get { return numbersGame; } }
    public bool isDataUpdate = false;

    void Awake()
    {
        LoadData();
        
    }

    public bool IsValidMapPosition(Transform trans)
    {
      Transform[] children= trans.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();

            if (IsInsideMap(pos) == false) return false;
            if (map[(int)pos.x, (int)pos.y] != null) return false;

        }

        return true;

    }

    public bool IsGameOver() //当方块落下后，判断最上面三行是否有格子
    {
        for (int i = NORMAL_ROWS; i < MAX_ROWS; i++)
        {
            for (int j = 0; j < MAX_COLUMNS; j++)
            {
                if (map[j, i] != null)
                {
                    numbersGame++;
                    SaveData();
                    return true;
                }
            }
        }

        return false;
    }

    private bool IsInsideMap(Vector2 pos)
    {
        return pos.x >= 0 && pos.x < MAX_COLUMNS && pos.y >= 0;
    }

    public bool PlaceShape(Transform shape)
    {
        foreach (Transform child in shape)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            map[(int)pos.x, (int)pos.y] = child;

        }

       return CheckMap();
    }

    //检测消除
    private bool CheckMap()
    {
        int lineClear = 0; //表示消除多少行
        for (int i = 0; i < MAX_ROWS; i++)
        {
          bool isRowFull=  CheckIsRowFull(i);
            if (isRowFull)
            {
                DeleteRow(i);
                MoveDownRowsAbove(i+1);
                i--;  //继续判断这一行
                lineClear++;
            }
        }

        if (lineClear > 0)
        {
            score += lineClear * 100;
            if (score > highScore) highScore = score;
            isDataUpdate = true;

            return true;
        }
        else return false;
    }

    private bool CheckIsRowFull(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, row] == null) return false;
        }

        return true;
    }

    private void DeleteRow(int row)
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            Destroy(map[i, row].gameObject);
            map[i, row] = null;
        }

    }

    private void MoveDownRowsAbove(int row) //把行数>row的元素下移
    {
        for (int i = row; i < MAX_ROWS; i++)
        {
            MoveDownRow(i);
        }

    }

    private void MoveDownRow(int row)//把行数为row的元素下移
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            if (map[i, row] != null)
            {
                try
                {
                    if (row - 1 >= 0)
                    {
                        map[i, row - 1] = map[i, row];  //移动引用
                        map[i, row] = null;

                        map[i, row - 1].position += Vector3.down; //移动图像
                    }
         
                }
                catch (System.Exception e)
                {
                    Debug.Log("i:"+i);
                    Debug.Log("row:"+row);
                    throw e;
                }
            }
        }
    }


    private void LoadData()
    {
        highScore=PlayerPrefs.GetInt("HighScore",0);
        numbersGame=PlayerPrefs.GetInt("NumbersGame", 0);
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("NumbersGame", numbersGame);

    }

    private void OnDestroy()
    {
        SaveData();
    }

    public void ReStart()
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {

            for (int j = 0; j < MAX_ROWS; j++)
            {
                if (map[i, j] != null)
                {
                    Destroy(map[i, j].gameObject);
                    map[i, j] = null;

                }
            }

        }

        score = 0;

    }

    public void ClearData()
    {
        score = 0;
        highScore = 0;
        numbersGame = 0;
        SaveData();

    }
}
