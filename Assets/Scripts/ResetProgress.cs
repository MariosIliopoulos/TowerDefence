using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetProgress : MonoBehaviour
{

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LevelSelect");
    }

}
