using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour {

	[SerializeField]
	private float _speed = 3.0f;

	[SerializeField]
	private int _PowerId;

	[SerializeField]
	private AudioClip _clip;

	void Start ()
	{


	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.down *_speed*Time.deltaTime);

		if (transform.position.y < -7) 
		{
			Destroy (this.gameObject);
		}

		
	}

	private void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.tag == "Player") {

			//access player
			Player player = hit.GetComponent<Player> ();
			AudioSource.PlayClipAtPoint (_clip, transform.position);
			if (player != null) 
			{ //null checking for the component
				if (_PowerId == 0)
				{            //shoot triple shot
					//_audiosource.Play ();
					player.TripleShotPowerUp ();  
				} 
				else if (_PowerId == 1) 
				{     //speed up
					//_audiosource.Play ();
					player.SpeedBoostOn ();
				} 
				else if (_PowerId == 2) 
				{       //shield up
					// _audiosource.Play ();
					player.shieldActive();
					
				}
			
			}

			//destroy powerup
			Destroy (this.gameObject);
		}

	}

	 
		
}
