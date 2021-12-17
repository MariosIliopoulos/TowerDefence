using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    public Button startNextWaveButton;

    public GameManager gameManager;

    public static int temp = 0;

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            startNextWaveButton.interactable = false;
            return;
        }

        if (waveIndex == waves.Length && PlayerStats.Lives > 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        startNextWaveButton.interactable = true;

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        temp = 0;
        for (int j = 0; j < wave.enemies.Length; j++)
        {
            temp = temp + wave.enemies[j].count;
        }

        EnemiesAlive = temp;

        for (int j = 0; j < wave.enemies.Length; j++)
        {
            for (int i = 0; i < wave.enemies[j].count; i++)
            {
                SpawnEnemy(wave.enemies[j].enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }

        waveIndex++;

        

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }

    public void StartNextWave()
    {
        countdown = 0;
        waveCountdownText.text = string.Format("{0:00}", countdown);
    }

}
