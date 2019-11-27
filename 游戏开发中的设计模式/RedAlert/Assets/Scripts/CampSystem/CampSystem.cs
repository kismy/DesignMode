using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();
    private Dictionary<EnemyType, CaptiveCamp> mCaptiveCamps = new Dictionary<EnemyType, CaptiveCamp>();

    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);

        InitCamp(EnemyType.Elf);

    }



    private void InitCamp(SoldierType soldierType)
    {
        GameObject GO;
        string GOName="";
        string name="";
        string icon="";
        Vector3 position=Vector3.zero;
        float trainTime=5;

        switch (soldierType)
        {
            case SoldierType.Rookie:
                GOName = "SoldierCamp_Rookie";
                name = "新手兵营";
                icon = "RookieCamp";
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                GOName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                icon = "SergeantCamp";
                trainTime = 4;

                break;
            case SoldierType.Captain:
                GOName = "SoldierCamp_Captain";
                name = "上尉兵营";
                icon = "CaptainCamp";
                trainTime = 5;
                break;

            default:
                Debug.LogError("无法根据战士类型："+soldierType+"初始化兵营。");
                break;
        }

        GO = GameObject.Find(GOName);
        position = UnityTool.FindChild(GO,"TrainPoint").transform.position;
        SoldierCamp soldierCamp = new SoldierCamp(GO,name,icon,soldierType,position,trainTime);

        //CampOnClick campOnclick = GO.AddComponent<CampOnClick>();
        //campOnclick.camp = soldierCamp;
        GO.AddComponent<CampOnClick>().camp = soldierCamp;


        mSoldierCamps.Add(soldierType, soldierCamp);
    }
    private void InitCamp(EnemyType enemyType)
    {
        GameObject GO;
        string GOName = "";
        string name = "";
        string icon = "";
        Vector3 position = Vector3.zero;
        float trainTime = 5;

        switch (enemyType)
        {
            case EnemyType.Elf:
                GOName = "CaptiveCamp_Elf";
                name = "小精灵俘兵营";
                icon = "CaptiveCamp";
                trainTime = 3;
                break;


            default:
                Debug.LogError("无法根据敌人类型：" + enemyType + "初始化兵营。");
                break;
        }

        GO = GameObject.Find(GOName);
        position = UnityTool.FindChild(GO, "TrainPoint").transform.position;
        //SoldierCamp soldierCamp = new SoldierCamp(GO, name, icon, soldierType, position, trainTime);
        CaptiveCamp camp = new CaptiveCamp(GO, name, icon, enemyType, position, trainTime);

        //CampOnClick campOnclick = GO.AddComponent<CampOnClick>();
        //campOnclick.camp = soldierCamp;
        GO.AddComponent<CampOnClick>().camp = camp;


        //mSoldierCamps.Add(soldierType, soldierCamp);
        mCaptiveCamps.Add(enemyType, camp);
    }

    public override void Update()
    {
        foreach (SoldierCamp camp in mSoldierCamps.Values)
        {
            camp.Update();
        }
        foreach (CaptiveCamp camp in mCaptiveCamps.Values)
        {
            camp.Update();
        }


    }

}
