using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class View : MonoBehaviour {
    private Ctrl ctrl;
    private RectTransform logoName;
    private RectTransform menuUI;
    private RectTransform gameUI;
    private RectTransform gameOverUI;
    private GameObject restartButton;
    private GameObject settingUI;

    private GameObject rankUI;
    private Text rankScore;
    private Text rankHighScore;
    private Text rankNumbersGame;

    private GameObject mute;

    private Text score;
    private Text highScore;

    void Awake () {
        ctrl = GameObject.Find("Ctrl").GetComponent<Ctrl>();

        logoName = transform.Find("Canvas/LogoName")as RectTransform;
        menuUI = transform.Find("Canvas/MenuUI") as RectTransform;
        gameUI = transform.Find("Canvas/GameUI") as RectTransform;
        gameOverUI = transform.Find("Canvas/GameOverUI") as RectTransform;
        restartButton = transform.Find("Canvas/MenuUI/ReStartButton").gameObject;
        settingUI= transform.Find("Canvas/SettingUI").gameObject;
        mute= transform.Find("Canvas/SettingUI/AudioButton/Mute").gameObject;

        rankUI = transform.Find("Canvas/RankUI").gameObject;
        rankScore = rankUI.transform.Find("ScoreLabel/Value").GetComponent<Text>();
        rankHighScore = rankUI.transform.Find("HighLabel/Value").GetComponent<Text>();
        rankNumbersGame = rankUI.transform.Find("NumberGamesLabel/Value").GetComponent<Text>();

        score = transform.Find("Canvas/GameUI/ScoreLabel/Value").GetComponent<Text>();
        highScore = transform.Find("Canvas/GameUI/HighScoreLabel/Value").GetComponent<Text>();


    }


    public void ShowMenu()
    {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(-94.59998f, 0.5f);

        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(60, 0.5f);

    }

    public void HideMenu()
    {
        logoName.DOAnchorPosY(94.59998f, 0.5f).OnComplete(()=> { logoName.gameObject.SetActive(false); });  
       
        menuUI.DOAnchorPosY(-60, 0.5f).OnComplete(() => { menuUI.gameObject.SetActive(false); });

    }
    public void UpdateGameUI(int score, int highScore)
    {
        this.score.text = score.ToString();
        this.highScore.text = highScore.ToString();

    }
    public void ShowGameUI(int score=0,int highScore=0)
    {

        this.score.text = score.ToString();
        this.highScore.text = highScore.ToString();
        gameUI.gameObject.SetActive(true);
        gameUI.DOAnchorPosY(-150, 0.5f);

    }

    public void HideGameUI()
    {


        gameUI.DOAnchorPosY(150, 0.5f).OnComplete(() => { gameUI.gameObject.SetActive(false); });

    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);

    }

    public void HideRestartButton()
    {
        restartButton.SetActive(false);

    }


    public void ShowGameOverUI(int score)
    {
        gameOverUI.gameObject.SetActive(true);
        gameOverUI.Find("ScoreLabel").GetComponent<Text>().text = score.ToString();


    }

    public void HideGameOverUI()
    {


        gameOverUI.gameObject.SetActive(false);

    }

    public void OnHomeButtonClick()
    {
        ctrl.audioManager.PlayCursor();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnSettingUIClick()
    {
        ctrl.audioManager.PlayCursor();
        settingUI.SetActive(true);
    }



    public void OnAudioButtonClick()
    {
        ctrl.audioManager. PlayCursor();
        ctrl.audioManager.isMute = !ctrl.audioManager.isMute;
        mute.SetActive(ctrl.audioManager.isMute);

    }

    public void CloseSettingUI()
    {
        ctrl.audioManager.PlayCursor();
        settingUI.SetActive(false);
    }



    public void ShowRankUI(int score,int highScore,int numbersGame)
    {
        rankUI.SetActive(true);
        rankScore.text = score.ToString();
        rankHighScore.text = highScore.ToString();
        rankNumbersGame.text = numbersGame.ToString();
    }

    public void OnRankUIClick()
    {
        rankUI.SetActive(false);
    }

}
