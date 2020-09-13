using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private int _numberOfEnemies = 0;
    private Enemy[] _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
        _numberOfEnemies = _enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
       // int numberOfEnemiesLeft = 0;
        foreach (Enemy enemy in _enemies)
        {
           // numberOfEnemiesLeft++;
            if (enemy != null) { return; }
        }
       // if (numberOfEnemiesLeft >= 1) return;

        //_levelScore
        // Debug.Log("You killed all enemies");

        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        Invoke("LoadNextLevel", 5f);
        //SceneManager.LoadScene(nextLevelName);
    }

    public void LoadNextLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
