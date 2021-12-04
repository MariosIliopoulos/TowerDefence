using UnityEngine;
using UnityEngine.UI;

public class StartWave : MonoBehaviour
{
    public Text waveCountdownText;

    public void StartNextWave()
    {
        WaveSpawner.countdown = 0;
        waveCountdownText.text = string.Format("{0:00}", WaveSpawner.countdown);
    }

}
