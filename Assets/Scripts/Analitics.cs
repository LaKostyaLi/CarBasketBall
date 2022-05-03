using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Analitics : MonoBehaviour
{
   //на каком уровне чаще всего проигрывает игрок
   public void OnPlayerDead(int _levelNumber, string player)
    {
        Analytics.CustomEvent("Player Dead", new Dictionary<string, object>()
        {
            {"Level", _levelNumber},
            {"Player", player}
        }
        );
    }
}
