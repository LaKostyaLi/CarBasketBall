using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{

    [SerializeField] private LevelManager _levelManager = null;

    public GameData gameData = new GameData();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            gameData = JsonUtility.FromJson<GameData>(PlayerPrefs.GetString("GameData"));
        }
    }
    private void OnApplicationQuit()
    {
        gameData.Level = _levelManager.LevelNumber;
        gameData.Try = _levelManager.TryNumber;
        string json = JsonUtility.ToJson(gameData, true);
        PlayerPrefs.SetString("GameData", json);
    }
}
[System.Serializable]
public class GameData
{
    public int Level;
    public int Try;
    public GameData()
    {
        Level = 1;
        Try = 1;
    }

}
