using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "LevelSelect";

    public void Play()
    {
        WaveSpawner.EnemiesAlive = 0;
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }

}
