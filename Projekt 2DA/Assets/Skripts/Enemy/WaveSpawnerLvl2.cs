using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerLvl2 : MonoBehaviour
{
	public bool spawnWave = false;

	public enum SpawnState { SPAWNING, WAITING, COUNTING, DONE };

	[System.Serializable]
	public class Wave
	{
		public string name;
		public GameObject DownerPrefab;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;
	public int NextWave
	{
		get { return nextWave + 1; }
	}

	public Transform[] spawnPoints;


	private float searchCountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;
	public SpawnState State
	{
		get { return state; }
	}

	void Start()
	{
		if (spawnPoints.Length == 0)
		{
			Debug.LogError("No spawn points referenced.");
		}
	}

	void Update()
	{
		if (state != SpawnState.DONE)
		{
			if (state == SpawnState.WAITING)
			{
				if (!EnemyIsAlive())
				{
					WaveCompleted();
				}
				else
				{
					return;
				}
			}

			if (spawnWave)
			{
				if (state != SpawnState.SPAWNING)
				{
					StartCoroutine(SpawnWave(waves[nextWave]));
				}
			}
		}
	}

	void WaveCompleted()
	{
		Debug.Log("Wave Completed!");

		state = SpawnState.COUNTING;
		spawnWave = false;

		if (nextWave + 1 > waves.Length - 1)
		{

			state = SpawnState.DONE;
			
			nextWave = 0;
			Debug.Log("ALL WAVES COMPLETE! Looping...");
			
		}
		else
		{
			nextWave++;
		}
	}

	bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave _wave)
	{
		Debug.Log("Spawning Wave: " + _wave.name);
		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++)
		{
			SpawnEnemy(_wave.DownerPrefab);
			yield return new WaitForSeconds(1f / _wave.rate);
		}

		state = SpawnState.WAITING;

		yield break;
	}

	void SpawnEnemy(GameObject _enemy)
	{
		Debug.Log("Spawning Enemy: " + _enemy.name);

		Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Instantiate(_enemy, _sp.position, _sp.rotation);
	}
}
