using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSystem : MonoBehaviour
{

    [SerializeField] private LevelManager _levelManager = null;
    [SerializeField] private TextMeshProUGUI _levelCounter = null;
    [SerializeField] private TextMeshProUGUI _tryCounter = null;

    public GameData gameData = null;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (PlayerPrefs.HasKey("GameData"))
        {
            gameData = JsonUtility.FromJson<GameData>(PlayerPrefs.GetString("GameData"));
        }
        else
        {
            gameData = new GameData();
        }
    }
    private void Update()
    {
        _levelCounter.text = $"Level:{_levelManager.LevelNumber}";
        _tryCounter.text = $"Try number {_levelManager.TryNumber}";
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
