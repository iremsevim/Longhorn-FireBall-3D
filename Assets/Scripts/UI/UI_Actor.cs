using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Actor : SingletonActorBase<UI_Actor>
{

    public Text circleCounter;
    public Text score;
    public GameObject failPanel;
    public GameObject succesPanel;
    public GameObject gamePlaying;
    public void UpdateCircleAmount(int amount)
    {
        circleCounter.text = amount.ToString();

    }
    public void UpdateScore(int amount)
    {
        score.text = amount.ToString();
    }
    [GE(BaseGameEvents.StartGame)]
    public void OnLevelStarted()
    {
        failPanel.SetActive(false);
        succesPanel.SetActive(false);
        gamePlaying.SetActive(true);

    }
    [GE(BaseGameEvents.WinGame)]
    public void WinGame()
    {
        failPanel.SetActive(false);
        succesPanel.SetActive(true);
        gamePlaying.SetActive(false);
    }
    [GE(BaseGameEvents.LoseGame)]
    public void Losegame()
    {
        failPanel.SetActive(true);
        succesPanel.SetActive(false);
        gamePlaying.SetActive(false);
    }

    public void  ButonListener(int ID)
    {
        switch(ID)
        {
            case 0:
                GameManager.Instance.Nextlevel();

                break;
            case 1:
                GameManager.Instance.Restartlevel();

                break;
        }
    }
    [GE(BaseGameEvents.RestartGame)]
    public void OnRestartGame()
    {
        UpdateScore(0);
       
    }
    [GE(BaseGameEvents.NextLevel)]
    public void OnNextlevel()
    {
        UpdateScore(0);

    }




}
