using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
	
	public static int wavesLeft = 3;
	public float timeBetweenWaves = 5f; 
	private float countdown = 3f; //countdown before the next wave spawns
	public Text waveCountDownText;
	private int waveNumber = 0;
    private int numberOfEnemies = 0;

    void Update ()
	{
		if (countdown <= 0f) //when countdown reaches 0, spawn a wave and reset countdown
		{
			waveCountDownText.text = "Press Space for next wave!";
			if (Input.GetKey(KeyCode.Space))
			{	
				if (wavesLeft <= 0)
				{
					return;
				}
				else
				{
					StartCoroutine(SpawnWave());
					SpawnWave();
					countdown = timeBetweenWaves;
				}
				
			}
		}
		else
		{			
			countdown -= Time.deltaTime; //reduce countdown by 1 every second
			
			waveCountDownText.text = Mathf.Round(countdown).ToString();
		}
	}
	
	IEnumerator SpawnWave()
	{
		waveNumber++;

		for (int i =0; i < waveNumber; i++)
		{
			SpawnEnemy();
			numberOfEnemies++;
			yield return new WaitForSeconds(2f);
		}
		wavesLeft--;			
	}
	
	void SpawnEnemy()
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
	
}
