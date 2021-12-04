using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    
    public static float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        
        for (int j = 0; j < wave.enemies.Length; j++)
        {
            for (int i = 0; i < wave.enemies[j].count; i++)
            {
                SpawnEnemy(wave.enemies[j].enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level won!");
            this.enabled = false;
        }

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
