using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _nextLVL;
    public void LoadNextLevel()
    {
        Instantiate(_nextLVL,Vector3.zero,Quaternion.identity);
        Destroy(gameObject);
    }
}
