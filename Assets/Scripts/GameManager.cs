using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;


    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Level won!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }

}
