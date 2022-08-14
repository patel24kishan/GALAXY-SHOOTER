using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField]
	private GameObject enemyPrefab;

	[SerializeField]
	private GameObject[] powerups;

	private GameManager _gameManager;


	void Start ()
	{
		StartCoroutine(EnemySpawnRoutine());
		StartCoroutine (PowerUpSpawnRoutine ());

		_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		
	}

	public void StartSpawnManager()
	{
		StartCoroutine (EnemySpawnRoutine ());
		StartCoroutine (PowerUpSpawnRoutine ());
	}
	
	IEnumerator EnemySpawnRoutine()
	{
		while(_gameManager.Gameover == false)
		{
			Instantiate(enemyPrefab,new Vector3 (Random.Range (-7.97f, 7.51f), 7, 0),Quaternion.identity);
			yield return new WaitForSeconds (3.5f);
		}
	
	}
	
	IEnumerator PowerUpSpawnRoutine()
	{
		while (_gameManager.Gameover==false)
		{
			int powerupRandom = Random.Range (0,3);
			Instantiate (powerups [powerupRandom], new Vector3 (Random.Range (-7.97f, 7.51f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds (5.0f);
		}
	}
}
