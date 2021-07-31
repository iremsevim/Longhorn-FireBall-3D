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
        GameObject levelprefeb = gameData.levelDatas.levelDatas[runTimeData.currentLevelIndex % gameData.levelDatas.levelDatas.Count].levelprefab;
        GameObject level = Instantiate(levelprefeb, Vector3.zero, Quaternion.identity);
    }

    [System.Serializable]
    public class RunTimeData
    {
        public bool isGameStarted;
        public bool isGameOver;
        public int currentLevelIndex;
    }

}
