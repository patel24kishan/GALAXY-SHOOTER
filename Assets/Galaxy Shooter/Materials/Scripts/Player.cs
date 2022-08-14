using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//cantripleshot

	public bool canTripleShot=false;

	public bool speedboost=false;

	public bool shieldup=false;

	public int lives=3;

	[SerializeField]
	private GameObject Player_ExplosionPrefab;

	[SerializeField]
	private GameObject LaserPrefab;

	[SerializeField]
	private GameObject TripleshotPrefab;

	[SerializeField]
	private GameObject shieldgameObject;

	[SerializeField]
	private float _firerate=0.25f;

	private float _canfire=0.0f;

	[SerializeField]
	private float _speed= 5.0f;

	[SerializeField]
	private GameObject[] _engFail;

	private UIManager _UImanager;

	private GameManager _gameManager;

	private SpawnManager _spawnmanager;

	private AudioSource _audiosource;

	private int hitCount = 0;

	void Start ()
	{
		transform.position = new Vector3 (0, 0, 0);
	
		_UImanager = GameObject.Find ("Canvas").GetComponent<UIManager> ();

		if (_UImanager != null)
		{
			_UImanager.UpdateLives (lives);
		} 

		_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		_spawnmanager = GameObject.Find ("Spawn_Manager").GetComponent<SpawnManager> ();

		if (_spawnmanager != null) 
		{
			_spawnmanager.StartSpawnManager ();
		}

		_audiosource = GetComponent<AudioSource> ();

		hitCount = 0;
	}
	

	void Update () 
	{
		movement();

		// laser movemnet
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
		{
			shoot();
		}
	}

//MOVEMENT

private void shoot()
	{
			if (Time.time > _canfire)
		{	
			_audiosource.Play ();
			if (canTripleShot == true) 
			{                                       // 3 laser shoot
				
				Instantiate (TripleshotPrefab, transform.position + new Vector3 (0, 0.2f, 0), Quaternion.identity);

			} 
			else
			{
  				Instantiate (LaserPrefab, transform.position + new Vector3 (0, 0.95f, 0), Quaternion.identity);
			}
		_canfire = Time.time + _firerate;
		}
	}

private void movement()
{
	float hInput = Input.GetAxis ("Horizontal");
	float vInput = Input.GetAxis ("Vertical");


		if (speedboost == true) 
		{
			// increase by speed of player 2.5x	
			transform.Translate (Vector3.up * Time.deltaTime * _speed *2.5f* vInput);
			transform.Translate (Vector3.right * Time.deltaTime * _speed *2.5f* hInput);
		}
		else
		{
				transform.Translate (Vector3.up*Time.deltaTime*_speed*vInput);
				transform.Translate (Vector3.right*Time.deltaTime*_speed*hInput);
		}


	//setting player bound on y for greater tha n0
	if(transform.position.y > 0)
	{
		transform.position = new Vector3 (transform.position.x,0,0);
	}
	else if(transform.position.y < -4.2f)
	{
		transform.position = new Vector3 (transform.position.x,-4.2f,0);
	}

	//for player exiting the screen
	if(transform.position.x >= 9.4f)
	{
		transform.position = new Vector3 (-9.4f,transform.position.y,0);
	}
	else if(transform.position.x <= -9.4f)
	{
		transform.position = new Vector3 (9.4f,transform.position.y,0);		
	}
			
}

	public void Damage()
	{


		if (shieldup == true)
		{
			shieldup = false;
			shieldgameObject.SetActive (false);
			return;
		}

		hitCount++;

		if (hitCount == 1) 
		{
			_engFail [0].SetActive (true);
		}
		else if (hitCount == 2)  
		{
			_engFail [1].SetActive (true);
		}


		lives--;
		_UImanager.UpdateLives (lives);
		if (lives < 1)
		{
			Instantiate (Player_ExplosionPrefab, transform.position, Quaternion.identity);

			//set game over to true
			_gameManager.Gameover=true;
			_UImanager.ShowTitlescreen ();

			Destroy (this.gameObject);
		}
	}

	//shieldUp method
	public void shieldActive()
	{
		shieldup = true;
		shieldgameObject.SetActive (true);
	}

	//powerup method
	public void TripleShotPowerUp()
	{
		canTripleShot = true;
		StartCoroutine (TripleShotPowerDown());
	}
	//powerdown method
	public IEnumerator TripleShotPowerDown()
	{
		yield return new WaitForSeconds(5.0f);
		canTripleShot=false;
	}

	//speedup method
	public void SpeedBoostOn()
	{
		speedboost = true;
		StartCoroutine (SpeedBoostOff ());
	}

	public IEnumerator SpeedBoostOff()
	{
		yield return new WaitForSeconds (5.0f);
		speedboost = false;
	}
}


