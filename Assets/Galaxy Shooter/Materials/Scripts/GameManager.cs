using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public bool Gameover = true;
	
	private UIManager _uimanager;

	public GameObject player;

	private void Start()
	{
		_uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	void Update ()
	{
		if (Gameover == true) 
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Instantiate (player, Vector3.zero, Quaternion.identity);
				Gameover = false;
				_uimanager.HideTitleScreen ();
			}

		}

		
	}
}
