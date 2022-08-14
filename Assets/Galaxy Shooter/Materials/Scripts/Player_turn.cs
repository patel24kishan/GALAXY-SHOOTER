using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_turn : MonoBehaviour {

	private Animator _anime;
	// Use this for initialization
	void Start ()
	{
		_anime = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			_anime.SetBool ("turn_left", true);
			_anime.SetBool ("turn_right", false);
		}

		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			_anime.SetBool ("turn_right", true);
			_anime.SetBool ("turn_left", false);
		}

		if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow)) {
			_anime.SetBool ("turn_right", false);
			_anime.SetBool ("turn_left", false);	
		}
	}
}
