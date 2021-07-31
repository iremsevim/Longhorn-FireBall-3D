using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Game Data",menuName ="Resources/Game Data")]
public class GameData : ScriptableObject
{
    public Prefabs prefabs;
    [Header("All levels datas info")]
    public LevelDatas levelDatas;
    [System.Serializable]
    public struct Prefabs
    {
        public GameObject fireBall;
    }
    [System.Serializable]
    public struct LevelDatas
    {
        public List<LevelData> levelDatas;
       
    }

}
