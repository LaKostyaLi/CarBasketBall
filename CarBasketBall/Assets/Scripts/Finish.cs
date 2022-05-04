using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private LevelManager _levelManager = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _audioSource.Play();
            FindObjectOfType<Level>().LoadNextLevel();
            /*_levelManager.LevelComplete();
            _levelManager = null;*/
        }
    }
}
