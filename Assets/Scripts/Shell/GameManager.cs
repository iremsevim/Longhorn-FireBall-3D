using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : EventBehaviour<GameManager>
{
    public GameData gameData;
    public RunTimeData runTimeData;

    private void Start()
    {
        Loadlevel();
    }

    public void Loadlevel()
    {
        if(runTimeData.currenloadedlevel)
        {
            Destroy(runTimeData.currenloadedlevel);
        }
        GameObject levelprefeb = gameData.levelDatas.levelDatas[runTimeData.currentLevelIndex % gameData.levelDatas.levelDatas.Count].levelprefab;
        runTimeData.currenloadedlevel=Instantiate(levelprefeb, Vector3.zero, Quaternion.identity);
        StartLevel();
    }
    
    public void StartLevel()
    {
        runTimeData.isGameStarted = true;
        runTimeData.isGameOver = false;
        PushEvent(BaseGameEvents.StartGame);
    }

    public void FinishLevel(bool result)
    {
        runTimeData.isGameStarted = false;
        runTimeData.isGameOver = true;
        PushEvent(BaseGameEvents.FinishGame);
        if(result)
        {
           PushEvent(BaseGameEvents.WinGame);
        }
        else
        {
            PushEvent(BaseGameEvents.LoseGame);
        }

    }
    public void EarnScore()
    {
        runTimeData.score++;
        UI_Actor.Instance.UpdateScore(runTimeData.score);
    }
    
    public void Nextlevel()
    {
        runTimeData.currentLevelIndex++;
        Loadlevel();
        PushEvent(BaseGameEvents.NextLevel);
    }
    public void Restartlevel()
    {
        Loadlevel();
        PushEvent(BaseGameEvents.RestartGame);
    }

    [System.Serializable]
    public class RunTimeData
    {
        public bool isGameStarted;
        public bool isGameOver;
        public int currentLevelIndex;
        public int score;
        [HideInInspector]
        public GameObject currenloadedlevel;
    }

}
