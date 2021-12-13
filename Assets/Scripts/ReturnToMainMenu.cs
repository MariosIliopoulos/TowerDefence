using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnToMainMenu : MonoBehaviour
{
    public string menuSceneName = "MainMenu";


    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

}
