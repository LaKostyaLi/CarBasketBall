using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelPrefab;

    private void OnButtonClick()
    {
        Instantiate(_levelPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
