using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GameFacade
{
    private GameFacade() { }
    private static GameFacade _instance = new GameFacade();
    public static GameFacade Instance { get { return _instance; } }
    private bool mIsGameOver = false;
    public bool IsGameOver { get { return mIsGameOver; } }

    private AchievementSystem mArchievementSystem;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;

    private CampInfoUI mCampInfoUI;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;

    public void Init() {
        mArchievementSystem = new AchievementSystem();
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mArchievementSystem.Init();
        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();


        LoadMemento();

    }

    public void Update() {
        mArchievementSystem.Update();
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnergySystem.Update();

        mGameEventSystem.Update();
        mStageSystem.Update();
        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }

    public void Release() {
        mArchievementSystem.Release();
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnergySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();
        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();

        CreateMemento();
    }

    public Vector3 GetTargetPosition()
    {
      
        return mStageSystem.targetPosition;
    }

    public void ShowCampInfo(ICamp camp)
    {
        mCampInfoUI.ShowCampInfo(camp);
    }

    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSystem.AddSoldier(soldier);
    }

    public void AddEnemy(IEnemy enemy)
    {
        mCharacterSystem.AddEnemy(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        mCharacterSystem.RemoveEnemy(enemy);
    }

    public bool TakeEnergy(int value)
    {
      return  mEnergySystem.TakeEnergy( value);
    }

    public void ResycleEnergy(int value)
    {
         mEnergySystem.ResycleEnergy(value);

    }

    public void ShowMsg(string msg)
    {
        mGameStateInfoUI.ShowMsg(msg);
    }

    public void UpdateEnergySlider(int currentEnergy, int maxEnergy)
    {
        mGameStateInfoUI.UpdateEnergySlider(currentEnergy,maxEnergy);
    }

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RegisterObserver(eventType, observer);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mGameEventSystem.RemoveObserver(eventType, observer);

    }

    public void NotifySubjects(GameEventType eventType)
    {
        mGameEventSystem.NotifySubjects(eventType);

    }

    private void LoadMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        mArchievementSystem.RecoveFromMemento(memento);

    }

    private void CreateMemento()
    {
        AchievementMemento memento = mArchievementSystem.CreateMemento();
        memento.SaveData();
    }

    public void RunVisitor(ICharacterVisitor visitor)
    {
        mCharacterSystem.RunVisitor(visitor);
    }
}
