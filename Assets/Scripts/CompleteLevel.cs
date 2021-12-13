using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public string menuSceneName = "MainMenu";
    public string creditsSceneName = "Credits";

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(nextLevel);
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void Credits()
    {
        SceneManager.LoadScene(creditsSceneName);
    }
        
}
