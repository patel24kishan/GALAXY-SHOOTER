using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour 
{

	[SerializeField]
	private float _Enemyspeed = 3.0f;

	[SerializeField]
	private GameObject Enemy_ExplosionPrefab;

	private UIManager _uiManager;

	[SerializeField]
	private AudioClip _clip;

	void Start ()
	{
		_uiManager=GameObject.Find("Canvas").GetComponent<UIManager>();
	

	}
	

	void Update ()
	{
		transform.Translate (Vector3.down * _Enemyspeed * Time.deltaTime);
	

		if (transform.position.y < -7.0f) 
		{
			Destroy (this.gameObject);
			transform.position = new Vector3 (Random.Range (-7.97f, 7.51f), 7, 0);
		}
			
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Laser") 
		{
			if (other.transform.parent != null)
			{
				
				Destroy (other.transform.parent.gameObject);

			}

			Destroy (other.gameObject);

			Instantiate (Enemy_ExplosionPrefab, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint (_clip,transform.position);
			_uiManager.UpdateScore ();  //update score in th ui manager
			Destroy (this.gameObject);
		}
		else if (other.tag == "Player")
		{
			//damage the player
			Player player=other.GetComponent<Player>();

			if (player != null)
			{
				player.Damage ();
			}

			Instantiate (Enemy_ExplosionPrefab, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint (_clip,transform.position);

			Destroy (this.gameObject);
		}

	}

}
