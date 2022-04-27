using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;
    public List<GameObject> LifeIcons = new List<GameObject>();
    //Time Stamp
    public Text TimeStamp;


    public GameObject GameOverPanel;
    public GameObject StartGamePanel;
    public GameObject PausePanel;
    public GameObject WinningPanel;
    public GameObject DialoguesPanel;


    public void Start()
    {
        //GameOverPanel.SetActive(false);
        //PausePanel.SetActive(false);
        
        HideGameOver();
        HidePausePanel();
        HideWinningPanel();
        ShowStartGamePanel();
    }

    public void Update()
    {
        float TimeTimeTime = Mathf.Round(Time.time);
        TimeStamp.text = TimeTimeTime.ToString();
        //Debug.Log(TimeStamp);
    }



    public void UpdateScoreText(int _value)
    {
        ScoreText.text = _value.ToString();
    }
    public void UpdateLives(int _value)
    {
        for (int i = LifeIcons.Count -1; i >= 0; i--)
        {
            LifeIcons[i].SetActive(_value >= i);
        }

    }





    //show and tell
    public void ShowGameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void HideGameOver()
    {
        GameOverPanel.SetActive(false);
    }

    public void ShowStartGamePanel()
    {
        StartGamePanel.SetActive(true);
    }
    public void HideStartGamePanel()
    {
        StartGamePanel.SetActive(false);
    }
    public void ShowPausePanel()
    {
        PausePanel.SetActive(true);
    }
    public void HidePausePanel()
    {
        PausePanel.SetActive(false);
    }
    //Winning
    public void ShowWinningPanel()
    {
        WinningPanel.SetActive(true);
    }
    public void HideWinningPanel()
    {
        WinningPanel.SetActive(false);
    }


    //meta dialogues
    //public void ShowMetaDialogues()
    //{
    //    DialoguesPanel.SetActive(true);
    //}
}
